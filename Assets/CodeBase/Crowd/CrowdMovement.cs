using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Crowd
{
    public class CrowdMovement : MonoBehaviour
    {
        public float speed = 5f;
        public float horizontalSpeed = 2f;
        public float minX;
        public float maxX;
        
        [HideInInspector] public bool canMove;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService input)
        {
            _inputService = input;
        }

        private void Update()
        {
            MoveForward();
            if (Input.GetMouseButton(0))
                MoveSides();
        }

        private void MoveSides()
        {
            float moveX = _inputService.Axis.x * horizontalSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(moveX, 0, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            if (canMove)
                transform.Translate(newPosition - transform.position);
        }

        private void MoveForward()
        {
            if (canMove)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void ActivateMovement() => 
            canMove = true;
        
        public void DisableMovement() => 
            canMove = false;
        
    }
}