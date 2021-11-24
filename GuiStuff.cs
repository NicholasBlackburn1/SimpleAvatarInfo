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


        //TODO: get a window to dislay mod infox
        public IEnumerator OnModInfoButtonPress()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIModButton);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            //modinfoButton.GetComponent<Button>().onClick.AddListener();
        }


        // this will dump avatar info and should display it 
        // TODO: get data to be displayed from avatar
        public IEnumerator OnAvatarInfoButtonPress()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
            Transform modinfoButton = GameObject.Find("UserInterface").transform.Find(Const.GUIAvatarButton);

            modinfoButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            modinfoButton.GetComponent<Button>().onClick.AddListener(GuiActions.DumpAvatarInfo());
        }



    }
}


  




