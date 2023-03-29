using UnityEngine;

namespace CodeBase
{
    public class UiFactory : MonoBehaviour
    {
        [SerializeField] private GameObject startUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private GameObject loseUI;
        [SerializeField] private Transform canvas;

        [HideInInspector] public GameObject activeUI;

        public void SpawnStartUi()
        {
            activeUI = Instantiate(startUI, canvas);
        }
        
    }
}