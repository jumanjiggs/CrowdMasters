using System.Collections;
using CodeBase.Gates;
using CodeBase.Helpers;
using CodeBase.Infrastructure.Services.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Crowd
{
    public class CrowdInteract : MonoBehaviour
    {
        [Inject] private CrowdAnimator _crowdAnimator;
        [Inject] private CrowdMovement _crowdMovement;
        [Inject] private UiFactory _uiFactory;
        [Inject] private CashManager _cashManager;
        [Inject] private CrowdControl _crowdControl;
        
        [SerializeField] private float gateCollisionTime;
        private float _gateCollisionTimePassed;
        private bool _canCollideGates = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.Finish)) 
                StartCoroutine(FinishSettings());
            
            if (other.gameObject.TryGetComponent(out Gate gate) && _canCollideGates)
            {
                StartCoroutine(CollisionGateCooldown());
                int count = gate.typeGate == TypeGate.Increase
                    ? gate.increaseCrowd
                    : _crowdAnimator.crowd.Count * gate.multiplierCrowd -
                      _crowdAnimator.crowd.Count;
                    _crowdControl.SpawnAroundPoint(count);
                _crowdAnimator.PlayRun();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Gate gate)) 
                _crowdControl.ResetPositions();
        }
        
        private IEnumerator CollisionGateCooldown()
        {
            _gateCollisionTimePassed = 0f;
            _canCollideGates = false;
            while (_gateCollisionTimePassed <= gateCollisionTime)
            {
                _gateCollisionTimePassed += Time.deltaTime;
                yield return null;
            }
            _canCollideGates = true;
        }


        private IEnumerator FinishSettings()
        {
            _uiFactory.DisableCount();
            _crowdMovement.DisableMovement();
            _crowdAnimator.PlayWin();
            yield return new WaitForSeconds(2f);
            _uiFactory.SpawnWinUI();
            UpdateEarnCoins();
            _cashManager.WinLevel(_cashManager.LevelReward);
        }

        private void UpdateEarnCoins() => 
            _uiFactory.activeUI.GetComponent<UIScreen>().textCoinsEarn.text = _cashManager.LevelReward.ToString();
    }
}