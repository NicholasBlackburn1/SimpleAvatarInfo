
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Net.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using MelonLoader;
using TMPro;
using UnityEngine.UI;

namespace TestMod.utils
{


    public static class Utils
    {
        public static VRCPlayer get_local()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
        public static Il2CppSystem.Collections.Generic.List<Player> get_all_player()
        {
            if (PlayerManager.field_Private_Static_PlayerManager_0 == null) return null;
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
        }
        public static APIUser get_api(this Player p)
        {
            return p.field_Private_APIUser_0;
        }
        public static Player get_player(string id)
        {
            var t = get_all_player();
            for (var c = 0; c < t.Count; c++)
            {
                var p = t[c]; if (p == null) continue;
                if (p.get_api().id == id) return p;
            }
            return null;
        }
        public static Player get_player(int local_id)
        {
            var t = get_all_player();
            return t[local_id];
        }
        public static Player get_selected_player(this QuickMenu inst)
        {
            if (QuickMenu.prop_QuickMenu_0 == null ||
                QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0 == null ||
                PlayerManager.prop_PlayerManager_0 == null) return null;
            return get_player(QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0.id);
        }
        public static QuickMenu get_quick_menu()
        {
            return QuickMenu.prop_QuickMenu_0;
        }
        public static PlayerManager get_player_manager()
        {
            return PlayerManager.prop_PlayerManager_0;
        }
        public static VRCUiManager get_ui_manager()
        {
            return VRCUiManager.prop_VRCUiManager_0;
        }
        public static UserInteractMenu get_interact_menu()
        {
            return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0];
        }
        public static void toggle_outline(Renderer render, bool state)
        {
            if (HighlightsFX.prop_HighlightsFX_0 == null) return;
            HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(render, state);
        }
        public static string get_instance_id()
        {
            return APIUser.CurrentUser.location;
        }

        // allows me to make simple buttons 
        public static Transform CreateDefaultButton(string text, Vector3 textPosition, string tooltip, Color textColor, Transform parent, Action listener)
        {
            Transform quickMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)");
            Transform buttonBase = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn");
            Transform buttonTransform = UnityEngine.Object.Instantiate(buttonBase, parent).transform;

            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().text = text;
            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().rectTransform.localPosition = textPosition;
            buttonTransform.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;

            buttonTransform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            buttonTransform.GetComponent<Button>().onClick.AddListener(listener);

            UnityEngine.Object.Destroy(buttonTransform.transform.Find("Icon").gameObject);
            UnityEngine.Object.Destroy(buttonTransform.transform.Find("Icon_Secondary").gameObject);

            buttonTransform.gameObject.SetActive(true);

            return buttonTransform;
        }
    }
}

