
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
namespace TestMod
{
    class GuiActions
    {

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



                if (menuController.activeAvatar.releaseStatus == "private")
                {

                    MelonLogger.Error("Avatar ID " + avatarID + " is private! ");
                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };

                    MelonLogger.Msg("{" + "avatar_name:" + avatarName + "," + "avatar_id:" + avatarID + "," + "avatarurl:" + avatarURL + "}");
                    
                }
                else
                {
                    MelonLogger.Error("Avatar ID " + avatarID + " is public!");

                    avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                    MelonLogger.Msg("{" + "avatar_name:" + avatarName + "," + "avatar_id:" + avatarID + "," + "avatarurl:" + avatarURL + "}");
                    avatarPage.ChangeToSelectedAvatar();
                }

            });
        }
    }
}
