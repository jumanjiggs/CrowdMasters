using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.Player
{
    public class RegisterSpawner : MonoInstaller
    {
        [SerializeField] private CrowdSpawner crowdSpawner;

        public override void InstallBindings()
        {
            BindSpawner();
        }

        private void BindSpawner() => 
            Container.Bind<CrowdSpawner>().FromInstance(crowdSpawner).AsSingle().NonLazy();
    }
}