using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class GameState : MonoBehaviour
    {
        private UiFactory _uiFactory;
        private GroupMovement _groupMovement;
        private CrowdAnimator _crowdAnimator;
        private bool _activeGame;

        [Inject]
        private void Construct(UiFactory uiFactory, GroupMovement groupMovement, CrowdAnimator crowdAnimator)
        {
            _uiFactory = uiFactory;
            _groupMovement = groupMovement;
            _crowdAnimator = crowdAnimator;
        }
        
        private void Start()
        {
            _uiFactory.SpawnStartUi();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && !_activeGame) 
                StartGame();
        }

        private void StartGame()
        {
            ActivateMovement();
            ResetAnimations();
            DestroyCurrentActiveUI();
        }
        
        private void ActivateMovement()
        {
            _activeGame = true;
            _groupMovement.canMove = true;
        }

        private void ResetAnimations() => 
            _crowdAnimator.PlayRun();

        private void DestroyCurrentActiveUI() => 
            Destroy(_uiFactory.activeUI);
    }
}