using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class UiSpawnFactory : MonoInstaller
    {
        [SerializeField] private UiFactory uiFactory;
        
        public override void InstallBindings()
        {
            BindUiFactory();
        }

        private void BindUiFactory() => 
            Container.Bind<UiFactory>().FromInstance(uiFactory).AsSingle().NonLazy();
    }
}