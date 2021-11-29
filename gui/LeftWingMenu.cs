﻿using MelonLoader;
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
using SimpleAvatarInfo.utils;
using VRChatUtilityKit.Ui;

/*
 This class is for handling all my gui goodies Uwu
 */
namespace SimpleAvatarInfo.gui

{
    class LeftWingMenu
    {


        public IEnumerator OnMainTitleRun(string message)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.MainMenuTitlePath);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = message;
        }

        public IEnumerator onSafty()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform saftey = GameObject.Find("UserInterface").transform.Find(Const.toggleSaftyPath);

            saftey.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            //saftey.GetComponent<Button>().onClick.AddListener(GuiActions.DumpAvatarInfo());
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



        public IEnumerator OnFourthButtonTitle()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            GameObject pub = GameObject.Find("UserInterface");

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingFourthButton);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.Path;

        }

        public IEnumerator stuff()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform pub = GameObject.Find("UserInterface").transform.Find(Const.QuickMenuParent);

            SubMenu sub = new SubMenu(pub,"name",pub.gameObject.name.ToString(),"header",null);
            sub.Text = "this is a dev screen ";
            sub.gameObject.SetActive(true);

        }



        //TODO: get a window to dislay mod infox
        public IEnumerator OnModInfoButtonPress()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIModButton);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(GuiActions.openModInfoMenu());
        }


        // this will dump avatar info and should display it 
        // TODO: get data to be displayed from avatar
        public IEnumerator OnAvatarCloneButtonPress(string download)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIClone);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(GuiActions.CloneAvatar(download));

          
            
        }


        public IEnumerator OnAvatarInfoButtonPress(string download)
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIAvatarButton);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(GuiActions.AvatarInfo(download));



        }



        public IEnumerator OnSetAvatarPathButtonPress()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIPath);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(GuiActions.changFileLocal());



        }



    }
}


  




