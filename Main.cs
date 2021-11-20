﻿using MelonLoader;
using UnityEngine;
using VRC.Core;
using VRC.UI;
namespace TestMod
{
    public static class BuildInfo
    {
        public const string Name = "SimplePassthrew"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for Testing"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Nicky Blackburn"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "BlakcburnSoftware"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class TestMod : MelonMod
    {
        
        
        public override void OnApplicationStart() // Runs after Game Initialization.
        {
            
            
            MelonLogger.Msg("OnApplicationStart");
            MelonLogger.Warning("Starting Simple Data_Pasthrew");

            // Displays some info from vrc to show hey this works 
            MelonLogger.Msg("VRC ACCOUNT VERIFIED"+ "= "+  VRC.Core.APIUser.IsAccountVerified);
            MelonLogger.Msg("VRC AVATAR Version" + "= " + VRC.Core.ApiAvatar.VERSION);
            MelonLogger.Msg("VRC Avatars UwU~" + " =" + VRC.Core.ApiAvatar.localAvatars.ToString());
        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
            



        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
           
        }

        public override void OnUpdate() // Runs once per frame.
        {
            MelonLogger.Msg("OnUpdate");
            
           
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            MelonLogger.Msg("OnLateUpdate");
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            MelonLogger.Msg("OnGUI");
            
            



        }   

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
            MelonLogger.Msg("OnApplicationQuit");
            MelonLogger.Error("By World mod closeing...");
        }

        public override void OnPreferencesSaved() // Runs when Melon Preferences get saved.
        {
            MelonLogger.Msg("OnPreferencesSaved");
        }

        public override void OnPreferencesLoaded() // Runs when Melon Preferences get loaded.
        {
            MelonLogger.Msg("OnPreferencesLoaded");
        }

        public override void BONEWORKS_OnLoadingScreen() // Runs when BONEWORKS shows the Loading Screen. Only runs if the Melon is used in BONEWORKS.
        {
            MelonLogger.Msg("BONEWORKS_OnLoadingScreen");
        }
    }
}