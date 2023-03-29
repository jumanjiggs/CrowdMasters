using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 Axis => 
            new(UnityEngine.Input.GetAxis(Constants.MouseX), 0);
    }
}