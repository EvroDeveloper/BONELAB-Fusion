﻿using BoneLib.BoneMenu;
using LabFusion.BoneMenu;
using LabFusion.Utilities;

using UnityEngine;

namespace LabFusion.Network
{
    /// <summary>
    /// An empty networking layer for fallback. This does not implement any multiplayer functionality.
    /// </summary>
    public class EmptyNetworkLayer : NetworkLayer
    {
        public override string Title => "Empty";

        public override void Disconnect(string reason = "") { }

        public override void StartServer() { }

        public override void OnUpdateLobby() { }

        public override bool CheckSupported()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public override bool CheckValidation()
        {
            return true;
        }

        public override void OnInitializeLayer()
        {
            FusionLogger.Log("Initialized mod with an empty networking layer!", ConsoleColor.Magenta);
#if DEBUG
            FusionLogger.Log("This is for debugging purposes only, and will not allow multiplayer!", ConsoleColor.Magenta);
#else
            FusionLogger.Log("This usually means all other network layers failed to initialize, or you selected Empty in the settings.", ConsoleColor.Magenta);
#endif

            MatchmakingCreator.OnFillMatchmakingPage += OnFillMatchmakingPage;
        }

        public override void OnCleanupLayer() 
        {
            MatchmakingCreator.OnFillMatchmakingPage -= OnFillMatchmakingPage;
        }

        private void OnFillMatchmakingPage(Page page)
        {
            // Info for people incase this layer ends up being selected
            page.CreateFunction("You currently have no networking selected.", Color.white, null);

            if (!PlatformHelper.IsAndroid)
            {
                page.CreateFunction("This means you likely do not have Steam open.", Color.white, null);
                page.CreateFunction("Please install and open Steam.", Color.white, null);
            }
            else
            {
                page.CreateFunction("Please select a layer in settings.", Color.white, null);
            }
        }
    }
}