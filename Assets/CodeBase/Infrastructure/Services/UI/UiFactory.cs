using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Services.UI
{
    public class UiFactory : MonoBehaviour
    {
        public TextMeshProUGUI money;
        
        [SerializeField] private GameObject startUI;
        [SerializeField] private UIScreen winUI;
        [SerializeField] private GameObject loseUI;
        [SerializeField] private TextMeshPro countCrowd;
        [SerializeField] private Transform canvas;
        [SerializeField] private GameObject countUI;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextLevelButton;

        [HideInInspector] public GameObject activeUI;
        
        public void SpawnStartUi()
        {
            activeUI = Instantiate(startUI, canvas);
        }

        public void SpawnLoseUi()
        {
            activeUI = Instantiate(loseUI, canvas);
            restartButton = activeUI.GetComponentInChildren<Button>();
            restartButton.onClick.AddListener(ReloadScene);
        }

        public void SpawnWinUI()
        {
            activeUI = Instantiate(winUI.gameObject, canvas);
            nextLevelButton = activeUI.GetComponentInChildren<Button>();
            nextLevelButton.onClick.AddListener(LoadNextScene);
        }

        public void UpdateCrowdCount(int count) => 
            countCrowd.text = count.ToString();
        
        public void DisableCount() => 
            countUI.SetActive(false);

        private void LoadNextScene()
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene(0);
        }

        private void ReloadScene() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }
}