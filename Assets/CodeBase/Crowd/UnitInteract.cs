using System.Collections.Generic;
using CodeBase.Helpers;
using CodeBase.Infrastructure.Services.UI;
using GPUInstancer;
using UnityEngine;
using Zenject;

namespace CodeBase.Crowd
{
    public class UnitInteract : MonoBehaviour
    {
        [Inject] private CrowdAnimator _crowdAnimator;
        [Inject] private FXHolder _fxHolder;
        [Inject] private UiFactory _uiFactory;
        [Inject] private CrowdMovement _crowdMovement;
        [Inject] private CrowdControl _crowdControl;
        
        private bool _isTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.Obstacle) && !_isTriggered)
            {
                _isTriggered = true;
                var currentChar = gameObject.GetComponent<GPUInstancerPrefab>();
                _crowdAnimator.RemoveFromList(gameObject.GetComponent<Animator>());
                _fxHolder.SpawnDeathFx(gameObject.transform);
                _uiFactory.UpdateCrowdCount(_crowdAnimator.crowd.Count);
                _crowdControl.RemovePrefab(currentChar);
                Destroy(gameObject);
                
                if (NotAliveUnits())
                {
                    _crowdMovement.DisableMovement();
                    _uiFactory.SpawnLoseUi();
                }
            }
        }

        private bool NotAliveUnits() => 
            _crowdAnimator.crowd.Count <= 0;
    }
}
