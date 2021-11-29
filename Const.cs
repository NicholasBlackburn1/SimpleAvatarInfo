using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAvatarInfo
{
    class Const
    {

        public const string ModTogglesTitle= "Enable Data Out";


        //basic components
        public const string GuiPanal = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/Profile";
        public const string GuiPanalHeader = GuiPanal + "/WngHeader_H1";
        public const string GuiPanalText = GuiPanalHeader + "/LeftItemContainer/Text_QM_H2 (1)";
        public const string GUIInfoPanal = GuiPanal + "/ScrollRect/Viewport/VerticalLayoutGroup/InfoPanel";

        // status pane
        public const string GUIStatusPane = GUIInfoPanal + "/Status";
        public const string GUIStatusTextHeader = GUIStatusPane + "/Text_Header";
        public const string GUIStatusText = GUIStatusPane + "/Text_Status";

        //Buttons
        public const string GUIModButton = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile";
        public const string GUIAvatarButton = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Friends";
        public const string GUIClone="Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Avatars";
        public const string GUIPath = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emoji";
        // Main Quick Menu Object Locations 
        public const string QuickMenuParent = "Canvas_QuickMenu(Clone)";
        public const string QuickMenuDashBoad = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard";
        public const string QuickMenuTitle = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1";
        public const string QuickMenuSectionTitle = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks/LeftItemContainer/Text_Title";
        public const string QuickMenuSectionBody = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks";

        // Avatar Preview locals
        public const string AvatarPreviewRoot = "MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot";
        public const string AvatarPreviewModel = "MenuContent/Screens/Avatar/AvatarPreviewBase/MainModel";
        public const string AvatarPreviewAvatarPrefab = "MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel/AvatarPrefab(Clone)";


        // this is where all the Gui elements go for gui stuff
        public const string MainMenuTitlePath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title";
        public const string VoiceMenuPath = "MenuContent/Screens/Settings/VoiceOptionsPanel";
        public const string toggleSaftyPath = "Canvas_QuickMenu(Clone)/Container/Window/Toggle_SafeMode";


        //Names 
        public const string ModFirstButton = "Mod Info";
        public const string ModTitle = "Nickys Mod Owo~";
        public const string AviInfo = "Avatar Info";
        public const string Graphing = "Avatar Cloneing";
        public const string Path = "Avatar Save Path";

        // Wing menu ele,ents
        public const string Leftwingtitlepath = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/WngHeader_H1/LeftItemContainer/Text_Title";
        public const string Leftwingbasepath = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport";
        public const string LeftwingFirstButtonTitle = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile/Container/Text_QM_H3";
        public const string LeftwingSecondButtonTitle = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Friends/Container/Text_QM_H3";
        public const string LeftwingThirdButton = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Avatars/Container/Text_QM_H3";
        public const string LeftwingFourthButton = "Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emoji/Container/Text_QM_H3";

    }   
        
}
