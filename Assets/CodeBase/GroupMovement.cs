using UnityEngine;

namespace CodeBase
{
    public class GroupMovement : MonoBehaviour
    {
        public float speed = 5f; 
        public float horizontalSpeed = 2f; 
        
        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            if (Input.GetMouseButton(0))
            {
                float horizontalInput = Input.GetAxis(Constants.MouseX) * horizontalSpeed;
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
            }
        }
    }
}