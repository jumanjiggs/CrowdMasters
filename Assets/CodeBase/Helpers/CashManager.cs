using CodeBase.Infrastructure.Services.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Helpers
{
    public class CashManager : MonoBehaviour
    {
        [SerializeField] private string moneySaveKey = "money";
        [SerializeField] private float money;
        [SerializeField] private float levelReward;
        [SerializeField] private TextMeshProUGUI moneyCountUI;

        [Inject] private UiFactory _factory;
        
        public float Money
        {
            get => money;
            set => money = value;
        }

        public float LevelReward
        {
            get => levelReward;
        }

        private void Start()
        {
            moneyCountUI = _factory.money;
            LoadProgressSave();
            SetUI();
        }
        
        public void WinLevel(float reward)
        {
            levelReward = reward;
            Money += reward;
            SetUI();
            SaveProgress();
        }
        
        private void SetUI() => moneyCountUI.text = System.Math.Round(Money, 2).ToString();
        private void SaveProgress() => ES3.Save(moneySaveKey, Money);
        private void LoadProgressSave() => money = ES3.Load(moneySaveKey, money);
    }
}