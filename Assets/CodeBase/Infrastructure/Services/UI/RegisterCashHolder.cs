using CodeBase.Helpers;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI
{
    public class RegisterCashHolder : MonoInstaller
    {
        [SerializeField] private CashManager cashPrefab;

        public override void InstallBindings()
        {
           var cash =  Container.InstantiatePrefabForComponent<CashManager>(cashPrefab);
           Container.Bind<CashManager>().FromInstance(cash).AsSingle().NonLazy();
        }
    }
}