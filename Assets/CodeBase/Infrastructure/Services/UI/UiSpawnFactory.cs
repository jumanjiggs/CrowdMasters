using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI
{
    public class UiSpawnFactory : MonoInstaller
    {
        [SerializeField] private UiFactory uiFactory;
        [SerializeField] private UIScreen uiScreen;
        
        public override void InstallBindings() => 
            BindUiFactory();

        private void BindUiFactory()
        {
            Container.Bind<UiFactory>().FromInstance(uiFactory).AsSingle().NonLazy();
            Container.Bind<UIScreen>().FromInstance(uiScreen).AsSingle().NonLazy();
        }
    }
}