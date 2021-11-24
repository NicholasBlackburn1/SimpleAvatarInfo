
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;

/*
 * this is the actions class for my gui UwU this will allow me to link certin stuff to my vrchat buttons 
 * **/
namespace TestMod.gui
{
    class GuiActions
    {

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

        // This allows me to dump public and private avi's to the console
        public static Action DumpAvatarInfo()
        {
            return new Action(() =>
            {
                Transform screens = GameObject.Find("UserInterface").transform.Find("MenuContent/Screens/").transform;
                PageWorldInfo pageWorldInfo = screens.Find("WorldInfo").GetComponent<PageWorldInfo>();
                MenuController menuController = pageWorldInfo.field_Public_MenuController_0;
                PageAvatar avatarPage = screens.Find("Avatar").GetComponent<PageAvatar>();

                string avatarID = menuController.activeAvatarId;
                string avatarURL = menuController.activeAvatar.assetUrl;
                string avatarName = menuController.activeAvatar.name;
                string avatarVersion= menuController.activeAvatar.assetVersion.ToString();



                if (menuController.activeAvatar.releaseStatus == "private")
                {
                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Private");
                 
                }
                else
                {

                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };

                    DisplayAvatarInfoInConsole(avatarID, avatarName, avatarURL, avatarVersion, "Public");
                    avatarPage.ChangeToSelectedAvatar();
                }

            });


         
        }

        // this should launch my new menu 
        public static Action openModInfoMenu()
        {
            return new Action(() =>
            {
               ModGuiWindow gui = new ModGuiWindow();
                // Mod menu Register
                gui.createNewMenu("OwO");

                MelonLogger.Msg("-------MOD INFORMATION---------");
                MelonLogger.Msg(" Version" + " " + "1.0.0");
            });
        }
    }
}
