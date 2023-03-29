using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class RegisterAnimator : MonoInstaller
    {
        [SerializeField] private CrowdAnimator crowdAnimator;

        public override void InstallBindings()
        {
            BindAnimator();
        }

        private void BindAnimator() => 
            Container.Bind<CrowdAnimator>().FromInstance(crowdAnimator).AsSingle().NonLazy();
    }
}