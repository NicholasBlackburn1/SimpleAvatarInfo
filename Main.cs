
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
            MelonLogger.Msg("VRC ACCOUNT VERIFIED" + "=> " + VRC.Core.APIUser.IsAccountVerified);
            MelonLogger.Msg("VRC AVATAR Version" + "=> " + VRC.Core.ApiAvatar.VERSION.ToString());
            MelonLogger.Msg("VRC Avatar unity version" + "=> " + avt.unityVersion);



        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {

        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            OnLoadGui();
            RegisterGuiRuns();


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

        // this allows me to easly call information from the game objects im pullign from
        public void getGameObjInfo(Transform text)
        {
            MelonLogger.Msg("Gameobj Name ->" + " " + text.name.ToString());
            MelonLogger.Msg("Gameobj Type ->" + " " + text.GetType().ToString());
            MelonLogger.Warning(text.name.ToString() + " " + "is active ->" + " " + text.gameObject.active.ToString());
        }
        // loading for mod 
        public void OnLoadGui()
        {
            // creates and finds the text title object
            Transform text = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title");
            getGameObjInfo(text);
              
            // shows info on the icon 
            Transform toggle_icon = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Toggle_SafeMode/Icon").transform;
            getGameObjInfo(toggle_icon);

            Transform toggle = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Toggle_SafeMode").transform;
            getGameObjInfo(toggle);


        }

        // this holds the running stuff for my vrchat mod
        public void RegisterGuiRuns()
        {
            GuiStuff gui = new GuiStuff();

            gui.OnMainTitleRun("text UwU~....");
            //gui.OnSettingsRun();
        }

     
    }
}

