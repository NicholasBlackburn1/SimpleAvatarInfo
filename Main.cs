﻿
/**
 * This is the main mod class for my amazing moddy 
 * TODO:  change text on the main menu based on waht shit is going to happen
 * UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/
 * 
 * 
 * 
 * TODO: got force cloner working but now need to get a acutally a button to force clone not just one button auto clone 
 */
using MelonLoader;
using Mono.CSharp;
using System;
using System.Collections;
using SimpleAvatarInfo.gui;
using SimpleAvatarInfo.utils;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.UI;
using VRC.UI.Core;
using VRC.UI.Elements;
using SimpleAvatarInfo.ripper;
using System.IO;

namespace SimpleAvatarInfo
{
    public static class BuildInfo
    {
        public const string Name = "Simple Avatar Data"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for Cloning and seeing avatars info "; // Description for the Mod.  (Set as null if none)
        public const string Author = "Nicky Blackburn"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "BlakcburnSoftware"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.1.11"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://vrchat.nicholasblackburn.space"; // Download Link for the Mod.  (Set as null if none)



    }

    public class SimpleAvatarInfo : MelonMod
    {

        public const string dataHeader = "Captured Data ->";
       
        private LeftWingMenu gui = new LeftWingMenu();
        public static MelonPreferences_Category settingsCategory;
        public static MelonPreferences_Entry<string> downloadpath;

        ModUpdater updater = new ModUpdater();
    

        public override void OnApplicationStart() // Runs after Game Initialization.
        {

            ApiAvatar avt = new VRC.Core.ApiAvatar();
            MelonLogger.Msg("OnApplicationStart");
            MelonLogger.Warning("Starting Simple Data_Pasthrew");

            // Displays some info from vrc to show hey this works 
            MelonLogger.Msg("VRC ACCOUNT VERIFIED" + "=> " + VRC.Core.APIUser.IsAccountVerified);
            MelonLogger.Msg("VRC AVATAR Version" + "=> " + VRC.Core.ApiAvatar.VERSION.ToString());
            MelonLogger.Msg("VRC Avatar unity version" + "=> " + avt.unityVersion);
            settingsCategory = MelonPreferences.CreateCategory("settings");
            downloadpath = (MelonPreferences_Entry<string>)settingsCategory.CreateEntry("downloadpath", "EnterPath");

            // simople 
            if (downloadpath == null)
            {
                MelonLogger.Msg("Saving config file to disk....");
                MelonLogger.LogWarning("OwO saved it");
                MelonPreferences.Save();


            }
            else
            {
                MelonLogger.Warning("Download path from config file is " + " " + SimpleAvatarInfo.downloadpath.Value);
                ; }

            MelonLogger.Warning($"Checking for Mod Updates");
           // updater.DownloadFromGitHub("SimpleAvatarInfo");

            MelonLogger.Msg(ConsoleColor.Green, "Updated Mod");
/**
            MelonLogger.Warning("Downloading RIPPER THIS PROB WILL LAG for a little bit ");

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + "vAssetRipperConsole_win64"))
            {
               DownloadRipper.downloadRipper();

            }
            else
            {
                MelonLogger.Warning("Ripper is already downloaded YAY~~~~ Time to continue startup");
            }
**/

            MelonLogger.Msg("Continuing with startup....");


            MelonLogger.Msg(ConsoleColor.DarkBlue,"Setting frame rate to 120hz...");
            Application.targetFrameRate = 120;
            MelonLogger.Msg(ConsoleColor.DarkBlue, "Set frame rate to 120hz... SUCCESSFULLY!");

        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {

        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {

            try
            {
                RegisterGuiLayout();
            } catch(Exception e)
            {
                MelonLogger.Msg(ConsoleColor.Red, e.Message);
            }

        }

        public override void OnUpdate() // Runs once per frame.
        {

            try
            {
                RegisterGuiActions();
            } catch(Exception e)
            {
                MelonLogger.Msg(ConsoleColor.Red, e.Message);
            }


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


        }

        // this holds the running stuff for my vrchat mod
        public void RegisterGuiLayout()
        {
            LeftWingMenu gui = new LeftWingMenu();
          


            MelonCoroutines.Start(gui.OnMainTitleRun("Nicky's Mod Loaded.."));
            MelonCoroutines.Start(gui.OnLeftWingTitle("text In left wing~...."));

            // Wing Gui Button's 
            MelonCoroutines.Start(gui.OnFirstButtonTitle());
            MelonCoroutines.Start(gui.OnSecondButtonTitle());
            MelonCoroutines.Start(gui.OnThirdButtonTitle());
            MelonCoroutines.Start(gui.OnFourthButtonTitle());




        }

        // this allows me to register button pressess and stuff
        public void RegisterGuiActions()
        {
            LeftWingMenu gui = new LeftWingMenu();
           
            MelonCoroutines.Start(gui.OnModInfoButtonPress());
            MelonCoroutines.Start(gui.OnAvatarInfoButtonPress(SimpleAvatarInfo.downloadpath.Value));
            MelonCoroutines.Start(gui.OnAvatarCloneButtonPress(SimpleAvatarInfo.downloadpath.Value));
            MelonCoroutines.Start(gui.OnSetAvatarPathButtonPress());


        }


        public void UpdateClient()
        {

        }


    } }


