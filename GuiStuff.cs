using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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



        public IEnumerator OnFirstButton()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingFirstButtonTitle);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.ModFirstButton;
        }

        public IEnumerator OnSecondButton()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingSecondButtonTitle);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.AviInfo;
        }

        public IEnumerator OnThirdButton()
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            Transform Main_Menu_title = GameObject.Find("UserInterface").transform.Find(Const.LeftwingThirdButton);
            Main_Menu_title.GetComponent<TMPro.TextMeshProUGUI>().text = Const.Graphing;
        }




    }
}
