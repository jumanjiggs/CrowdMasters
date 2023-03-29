using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class RegisterGroupMovement : MonoInstaller
    {
        [SerializeField] private GroupMovement group;

        public override void InstallBindings()
        {
            BindGroup();
        }

        private void BindGroup() => 
            Container.Bind<GroupMovement>().FromInstance(group).AsSingle().NonLazy();
    }
}