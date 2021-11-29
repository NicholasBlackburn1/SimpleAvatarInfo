using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using VRChatUtilityKit.Ui;
using UnityEngine;

/*
 * this class will hold all the big gui stuff like 
 * **/
namespace SimpleAvatarInfo.gui
{
    class ModGuiWindow
    {
        private List<IButtonGroupElement> buttonlist = new List<IButtonGroupElement>();
        // this will create and init all the new base part of the window 
        //TODO: acutally get all the menu to be layed out in code and working 
        public IEnumerator createNewMenu(string MenuTitleText )
        {
            
            // whenever the usermanage face is avctive 
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;
                
                // sets up base gui for allowing me to add data to it 
                Transform quickMenu = GameObject.Find("UserInterface").transform.Find(Const.QuickMenuSectionBody);

               
        }



    }
}
