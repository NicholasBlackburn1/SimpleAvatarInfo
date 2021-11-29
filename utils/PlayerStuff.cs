
/**
 * this class is for handling player stuffy ok 
 */
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;

using VRC.SDK3;
using VRC.UI;

namespace SimpleAvatarInfo.utils
{
    class PlayerStuff
    { 
       public static void InitializeNetworkManager()
        {
            var playerJoinedDelegate = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
            var playerLeftDelegate = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
            playerJoinedDelegate.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(p =>
            {
                if (p != null) OnPlayerJoin(p);
            }));

            playerLeftDelegate.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(p =>
            {
                if (p != null) OnPlayerLeft(p);
            }));
        }


        public static void OnPlayerJoin(Player player)
        {

        }

        public static void OnPlayerLeft(Player player)
        {

        }
    }
}
