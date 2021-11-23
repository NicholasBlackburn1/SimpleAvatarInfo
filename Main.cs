﻿
/**
 * This is the main mod class for my amazing moddy 
 * TODO:  change text on the main menu based on waht shit is going to happen
 * UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/
 */
using MelonLoader;
using Mono.CSharp;
using System.Collections;
using UnityEngine;
using VRC.Core;
using VRC.UI;
using VRC.UI.Core;


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
    
        public const string dataHeader = "Captured Data ->";
        private AvatarStuff avatarstuff = new AvatarStuff();
        public override void OnApplicationStart() // Runs after Game Initialization.
        {
          
            ApiAvatar avt = new VRC.Core.ApiAvatar();
            MelonLogger.Msg("OnApplicationStart");
            MelonLogger.Warning("Starting Simple Data_Pasthrew");

            // Displays some info from vrc to show hey this works 
            MelonLogger.Msg("VRC ACCOUNT VERIFIED"+ "=> "+  VRC.Core.APIUser.IsAccountVerified);
            MelonLogger.Msg("VRC AVATAR Version" + "=> " + VRC.Core.ApiAvatar.VERSION.ToString());
            MelonLogger.Msg("VRC Avatar unity version" + "=> " + avt.unityVersion);


            

        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            

        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {

           

        }

        public override void OnUpdate() // Runs once per frame.
        {
            

        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {

        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {

          

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

        public IEnumerator Vrcguimod()
        {
            MelonLogger.Error("Please see this message for sanity");
            MelonLogger.Msg("running core rutiean...");

            Transform text = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title");
            MelonLogger.Msg("Gameobj Name ->" + " " + text.name.ToString());
            MelonLogger.Msg("Gameobj Type ->" + " " + text.GetType().ToString());


            while (UIManager.field_Private_Static_UIManager_0 == null) yield return null;
            MelonLogger.Msg("Early ui loading...");

            while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;


            text.GetComponent<TMPro.TextMeshPro>().text = "UWU what is this modded vrc";
            MelonLogger.Msg("Changed QuickMenu text");
    
            MelonLogger.Warning("Set the text stuff to active!");
        

        }
    }
}