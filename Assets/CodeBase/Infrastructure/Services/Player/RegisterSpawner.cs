using CodeBase.Crowd;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Infrastructure.Services.Player
{
    public class RegisterSpawner : MonoInstaller
    {
        [FormerlySerializedAs("crowdSpawner")] [SerializeField] private CrowdControl crowdControl;

        public override void InstallBindings() => 
            BindSpawner();

        private void BindSpawner() => 
            Container.Bind<CrowdControl>().FromInstance(crowdControl).AsSingle().NonLazy();
    }
}