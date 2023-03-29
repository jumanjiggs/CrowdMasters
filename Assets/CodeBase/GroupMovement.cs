using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class GroupMovement : MonoBehaviour
    {
        public float speed = 5f;
        public float horizontalSpeed = 2f;

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
            if (canMove)
                transform.Translate(Vector3.right * _inputService.Axis * horizontalSpeed * Time.deltaTime);
        }

        private void MoveForward()
        {
            if (canMove)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}