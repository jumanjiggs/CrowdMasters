﻿using CodeBase.Helpers;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.FX
{
    public class FXRegister : MonoInstaller
    {
        [SerializeField] private FXHolder fxHolder;

        public override void InstallBindings() => 
            BindFX();

        private void BindFX() => 
            Container.Bind<FXHolder>().FromInstance(fxHolder).AsSingle().NonLazy();
    }
}