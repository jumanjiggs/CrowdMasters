using CodeBase.Crowd;
using CodeBase.Infrastructure.Services.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Helpers
{
    public class GameState : MonoBehaviour
    {
        private UiFactory _uiFactory;
        private CrowdMovement _crowdMovement;
        private CrowdAnimator _crowdAnimator;
        private bool _activeGame;

        [Inject]
        private void Construct(UiFactory uiFactory, CrowdMovement crowdMovement, CrowdAnimator crowdAnimator)
        {
            _uiFactory = uiFactory;
            _crowdMovement = crowdMovement;
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
            _crowdMovement.ActivateMovement();
        }

        private void ResetAnimations() => 
            _crowdAnimator.PlayRun();

        private void DestroyCurrentActiveUI() => 
            Destroy(_uiFactory.activeUI);
    }
}