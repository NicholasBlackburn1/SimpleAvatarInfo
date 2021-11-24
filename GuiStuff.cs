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
 This class is for handling all my gui goodies Uwu
 */
namespace TestMod
{
    class GuiStuff
    {


        public IEnumerator OnMainTitleRun(string message)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.MainMenuTitlePath);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = message;
        }

        public IEnumerator onSafty(MelonCoroutines routines)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform saftey = GameObject.Find("UserInterface").transform.Find(Const.toggleSaftyPath);
            //saftey.GetComponent<TMPro.TextMeshProUGUI>().StartCoroutine();

        }


        public IEnumerator OnLeftWingTitle(string message)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.Leftwingtitlepath);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.ModTitle;
        }



        public IEnumerator OnFirstButtonTitle()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingFirstButtonTitle);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.ModFirstButton;
        }

        public IEnumerator OnSecondButtonTitle()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingSecondButtonTitle);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.AviInfo;
        }

        public IEnumerator OnThirdButtonTitle()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            GameObject pub = GameObject.Find("UserInterface");

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingThirdButton);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.Graphing;

        }


        public IEnumerator OnModInfoButtonPress()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIModButton);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(DumpAvatarInfo());
        }


        public Action DumpAvatarInfo()
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


  




