using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class UiFactory : MonoBehaviour
    {
        [SerializeField] private GameObject startUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private GameObject loseUI;
        [SerializeField] private TextMeshPro countCrowd;
        [SerializeField] private Transform canvas;

        [HideInInspector] public GameObject activeUI;

        public void SpawnStartUi() => 
            activeUI = Instantiate(startUI, canvas);

        public void SpawnLoseUi() => 
            activeUI = Instantiate(loseUI, canvas);

        public void SpawnWinUI() => 
            activeUI = Instantiate(winUI, canvas);

        public void UpdateCrowdCount(int count)
        {
            countCrowd.text = count.ToString();
        }
    }
}