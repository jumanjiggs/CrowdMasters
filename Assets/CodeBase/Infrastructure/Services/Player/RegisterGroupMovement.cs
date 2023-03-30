using CodeBase.Crowd;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Infrastructure.Services.Player
{
    public class RegisterGroupMovement : MonoInstaller
    {
        [FormerlySerializedAs("group")] [SerializeField] private CrowdMovement crowd;

        public override void InstallBindings() => 
            BindGroup();

        private void BindGroup() => 
            Container.Bind<CrowdMovement>().FromInstance(crowd).AsSingle().NonLazy();
    }
}