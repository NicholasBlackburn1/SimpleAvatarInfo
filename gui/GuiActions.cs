
using MelonLoader;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;
using VRChatUtilityKit.Ui;
using AvatarList = Il2CppSystem.Collections.Generic.List<VRC.Core.ApiAvatar>;

/*
 * this is the actions class for my gui UwU this will allow me to link certin stuff to my vrchat buttons 
 * **/
namespace SimpleAvatarInfo.gui
{
    class GuiActions
    {


        // Allows me to easly create popup menu for input
        public static void ShowInputPopupWithCancel(this VRCUiPopupManager popupManager, string title, string preFilledText,
            InputField.InputType inputType, bool useNumericKeypad, string submitButtonText,
            Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> submitButtonAction,
            Action cancelButtonAction, string placeholderText = "Enter text....")
        {
            popupManager.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(
                    title,
                    preFilledText,
                    inputType, useNumericKeypad, submitButtonText, submitButtonAction, cancelButtonAction, placeholderText, true, null);
        }


        // This allows me to dump public and private avi's to the console
        public static Action CloneAvatar(string downloadlocal)
        {
            return new Action(() =>
            {
                Transform screens = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/").transform;
                PageWorldInfo pageWorldInfo = screens.Find("WorldInfo").GetComponent<PageWorldInfo>();
                MenuController menuController = pageWorldInfo.field_Public_MenuController_0;
                PageAvatar avatarPage = screens.Find("Avatar").GetComponent<PageAvatar>();

                // avatar info

                string avatarID = menuController.activeAvatarId;
                string avatarURL = menuController.activeAvatar.assetUrl;
                string avatarName = menuController.activeAvatar.name;
                string avatarVersion= menuController.activeAvatar.assetVersion.ToString();



                if (menuController.activeAvatar.releaseStatus == "private")
                {
                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Private"); 
                    
                    // Warning message for cloning a private avatar
                    VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0("Private Avatar!", "You really can't clone a Private avatar vrchat is not made that way. Download it insted", "OwO Do it ", new Action(() =>
                    {
                        MelonLogger.Msg("Downloading Private  Avi...");
                        Downloader(avatarURL, avatarName, downloadlocal);

                    }),null);

                } 
                else
                {

                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                    
                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Public");

                    // Warning message for cloning a private avatar
                    VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0("Public Avatar!", "Cloning a Public avatar is amazing, but be carefull you could get fucked by vrc admins!", "OwO Do it ", new Action(() =>
                    {
                        MelonLogger.Msg("Cloneing Avi...");
                        avatarPage.ChangeToSelectedAvatar();
                       
                    }), null);

                }

            });


         
        }

        public static Action AvatarInfo(string downloadlocal)
        {
            return new Action(() =>
            {
                Transform screens = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/").transform;
                PageWorldInfo pageWorldInfo = screens.Find("WorldInfo").GetComponent<PageWorldInfo>();
                MenuController menuController = pageWorldInfo.field_Public_MenuController_0;
                PageAvatar avatarPage = screens.Find("Avatar").GetComponent<PageAvatar>();
        

                // avatar info

                string avatarID = menuController.activeAvatarId;
                string avatarURL = menuController.activeAvatar.assetUrl;
                string avatarName = menuController.activeAvatar.name;
                string avatarVersion = menuController.activeAvatar.assetVersion.ToString();



                if (menuController.activeAvatar.releaseStatus == "private")
                {
                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Private");

                    // Warning message for cloning a private avatar
                    VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0("Avatar Info!", avatarInfoString(avatarID, avatarName, avatarURL, "Private"), "Download Avatar ", new Action(() =>
                    {
                        MelonLogger.Msg("Downloading avatar..");
                        Downloader(avatarURL, avatarName, downloadlocal);
                        
                    }), null);

                }
                else
                {

                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };

                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Public");

                    // Warning message for cloning a private avatar
                    VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0("Avatar Info!", avatarInfoString(avatarID,avatarName,avatarURL, "Public"), "Download Avatar", new Action(() =>
                    {
                        MelonLogger.Msg("Downloading avatar...");
                        Downloader(avatarURL, avatarName, downloadlocal);
                      

                    }), null);

                }

            });



        }


        // this should launch my new menu 
        public static Action openModInfoMenu()
        {
            return new Action(() =>
            {
                
                MelonLogger.Msg("-------MOD INFORMATION---------");
                MelonLogger.Msg(" Version" + " " + "1.0.0");

                VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_Single_1("Mod Info", modInfo());

            });
        }


        // Displays info in a nice way for avatars
        private static void DisplayAvatarInfoInConsole(string avatarID, string avatarName, string avatarURL, string avatarVersion, string avatarStatus)
        {

            MelonLogger.Warning("------------GRABBED AVATAR DATA-----------");
            MelonLogger.Error("AVATAR STATUS:" + " " + avatarStatus);
            MelonLogger.Msg("AVATAR ID:" + " " + avatarID);
            MelonLogger.Msg("AVATAR NAME:" + " " + avatarName);
            MelonLogger.Msg("AVATAR ASSET URL:" + " " + avatarURL);
            MelonLogger.Msg("AVATAR Asset Version:" + " " + avatarVersion);
            MelonLogger.Msg("{" + "avatar_name:" + " " + " ' " + avatarName + " ' " + "," + "avatar_id:" + " " + " ' " + avatarID + " ' " + "," + "avatarurl:" + " " + " ' " + avatarURL + " ' " + "}");
            MelonLogger.Warning("------------Done GRABBING AVATAR DATA-----------");


        }
        // Downloads vrc avatars 
        public static void Downloader(string avatarurl, string avatarname, string path)
        {
            using (var client = new WebClient())
            {

                if(SimpleAvatarInfo.downloadpath.Value == "EnterPath"){
                    MelonLogger.Msg("Need to set up the file download path time to to use gui to set it up~");

                    ShowInputPopupWithCancel(VRCUiPopupManager.prop_VRCUiPopupManager_0, "Goto Page", string.Empty, InputField.InputType.Standard, true, "Submit", (s, k, t) =>
                    {
                        

                    },
                    new Action(() => { 
                    
                    }));


                }

                MelonLogger.Warning("Starting Downloading File named" + " " + path + @"\" + avatarname + ".vrca");

                // sets and handles the vrca download with webclient 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                var startTime = DateTime.Now;
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0)");
                client.DownloadFileAsync(new Uri(avatarurl), path + @"\" + avatarname + ".vrca");
                var elapsedTime = (DateTime.Now - startTime).TotalSeconds;

                MelonLogger.Warning("It took about" + " " + elapsedTime + " " + " to download the avatar " + avatarname + "\n");
                MelonLogger.Msg("Done Downloading File named" + " " + path + @"\" + avatarname + ".vrca");
                client.Dispose();

                ShowInputPopupWithCancel(VRCUiManager.prop_VRCUiManager_0, "Avatar Save Path", "Please Enter a Path to your avatars","Save Avatar path");
            }
        }


        // Avatar uwu
        private static string avatarInfoString(string avatarID, string avatarName, string avatarURL, string status)
        {
            return  "Avtar Name: " + avatarName + ",\n" +"Shared Status:" + " "+ status+ ",\n" + "Avatar ID :" + " " + avatarID + ",\n" + "Avatar URL:" + " " + avatarURL;
        }

        // mod info
        private static string modInfo()
        {
            return "ModName: " + BuildInfo.Name + "\n" + " Author: " + BuildInfo.Author + "\n" + "Version: " + BuildInfo.Version + "\n" + "Mod Url: "+ BuildInfo.DownloadLink +  " \n";
        }

    
    }
 
}
