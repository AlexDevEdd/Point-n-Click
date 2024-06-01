using System;
using JetBrains.Annotations;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Utils;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class AuthService : IInitializable
    {
        public bool IsInitialized { get; private set; }

        public async void Initialize()
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (Exception e)
            {
                Log.ColorLogDebugOnly($"{e}");
                return;
            }
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
            catch (Exception e)
            {
                Log.ColorLogDebugOnly($"{e}");
                return;
            }

            IsInitialized = true;
        }
    }
}