
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
    class PlayerStuff { 
        private readonly List<string> myJoinNames = new List<string>();
        private readonly List<string> myLeaveNames = new List<string>();

        

        private int myLastLevelLoad;
        private bool myObservedLocalPlayerJoin;

           

        // this allows me to do stuff when the player joins 
        public void OnPlayerJoined(Player player)
        {
           
                var apiUser = player.prop_APIUser_0;

            if (apiUser == null) return;

            if (APIUser.CurrentUser.id == apiUser.id)
            {
                myObservedLocalPlayerJoin = true;
                myLastLevelLoad = Environment.TickCount;
            }

            if (!myObservedLocalPlayerJoin || Environment.TickCount - myLastLevelLoad < 5_000)
            {
            };

            
            var playerName = apiUser.displayName ?? "!null!";

            MelonLogger.Msg(ConsoleColor.DarkMagenta+" A person Joined there name is "+" " +playerName.ToString());
        }


        public void OnPlayerLeft(Player player)
        {
            var apiUser = player.prop_APIUser_0;
            if (apiUser == null) return;
            if (Environment.TickCount - myLastLevelLoad < 5_000) return;


            var playerName = apiUser.displayName ?? "!null!";

            MelonLogger.Msg(ConsoleColor.DarkMagenta + "A person Left there name is" + " " + playerName.ToString());
        }

    }
}
