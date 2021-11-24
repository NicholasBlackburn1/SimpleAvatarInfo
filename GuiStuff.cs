using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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
           
            // this should allow me to run when pressed
            if (modinfoButton.GetComponent<UnityEngine.UI.Button>().IsPressed())
            {
                MelonLogger.Msg("Gameobj ->" + modinfoButton.name.ToString() + " " + " is pressed" + modinfoButton.GetComponent<UnityEngine.UI.Button>().IsPressed().ToString());
                CloneAvatar(GameObject.Find("UserInterface").transform.Find("/Canvas_QuickMenu(Clone)"));
            }
        }


        // Clones avatars 
        private void CloneAvatar(Transform quickMenu)
        {
            Transform screens = GameObject.Find("UserInterface/MenuContent/Screens/").transform;
            PageWorldInfo pageWorldInfo = screens.Find("WorldInfo").GetComponent<PageWorldInfo>();

            MenuController menuController = pageWorldInfo.field_Public_MenuController_0;
            PageAvatar avatarPage = screens.Find("Avatar").GetComponent<PageAvatar>();

            Transform buttonParent = quickMenu.transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions");
            Utils.CreateDefaultButton("Force Clone Public Avatar", new Vector3(0, -25, 0), "Force the clone of this user's public avatar", Color.white, buttonParent,
                new Action(() => {
                    string avatarID = menuController.activeAvatarId;
                    string avatarName = menuController.activeAvatar.name;
                    string avatarURL = menuController.activeAvatar.assetUrl;

                    // Be carefull this may get you banned i dont know and im affaid to try
                    if (menuController.activeAvatar.releaseStatus == "private")
                    {
                        MelonLogger.Error("Avatar ID " + avatarID + " is private! BE CAREFULL");
                        avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };

                        MelonLogger.Msg("Avi info name ->"+ " "+ avatarName);
                        MelonLogger.Msg("Avi info Asset URL ->" + " " + avatarURL);
                        MelonLogger.Msg("Avo info id ->" + " " + avatarID);


                    }
                    else
                    {
                        MelonLogger.Warning("Cloneing avatar....");
                        avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };
                        avatarPage.ChangeToSelectedAvatar();


                        MelonLogger.Msg("Avi info name ->" + " " + avatarName);
                        MelonLogger.Msg("Avi info Asset URL ->" + " " + avatarURL);
                        MelonLogger.Msg("Avo info id ->" + " " + avatarID);
                    }
                }));
        }


    }





}
