using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/*
 * this class will hold all the big gui stuff like 
 * **/
namespace TestMod.gui
{
    class ModGuiWindow
    {
        // this will create and init all the new base part of the window 
        //TODO: acutally get all the menu to be layed out in code and working 
        public IEnumerator createNewMenu(string MenuTitleText )
        {
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

                // sets up base gui for allowing me to add data to it 
                Transform quickMenu = GameObject.Find("UserInterface").transform.Find(Const.QuickMenuParent);
                Transform quickTitle = GameObject.Find("UserInterface").transform.Find(Const.QuickMenuTitle);
                Transform quickSection= quickMenu.transform.Find(Const.QuickMenuSectionTitle);


                // sets title text up
                var menuTitle = quickTitle.GetComponent<TextMeshProUGUI>();
                    menuTitle.text = MenuTitleText;
                    menuTitle.rectTransform.localPosition.Set(0, 0, 0);
                   
        }
    }
}
