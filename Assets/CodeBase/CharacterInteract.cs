using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class CharacterInteract : MonoBehaviour
    {
        [Inject] private CrowdAnimator _crowdAnimator;
        [Inject] private FXHolder _fxHolder;
        [Inject] private UiFactory _uiFactory;
        [Inject] private GroupMovement _groupMovement;

        private bool _isTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.Obstacle) && !_isTriggered)
            {
                _isTriggered = true;
                _crowdAnimator.RemoveFromList(gameObject.GetComponentInChildren<Animator>());
                _fxHolder.SpawnDeathFx(gameObject.transform);
                Destroy(gameObject);
                _uiFactory.UpdateCrowdCount(_crowdAnimator.crowd.Count);

                if (_crowdAnimator.crowd.Count <= 0)
                {
                    _uiFactory.SpawnLoseUi();
                    _groupMovement.enabled = false;
                }
            }
        }
    }
}
