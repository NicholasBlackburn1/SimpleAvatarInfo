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

        
    }
}
