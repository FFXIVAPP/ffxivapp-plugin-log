// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventSubscriber.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   EventSubscriber.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log {
    using System;

    using FFXIVAPP.Common.Core.Constant;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.IPluginInterface.Events;
    using FFXIVAPP.Plugin.Log.Utilities;

    using NLog;

    using Sharlayan.Core;

    public static class EventSubscriber {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Subscribe() {
            Plugin.PHost.ConstantsUpdated += OnConstantsUpdated;
            Plugin.PHost.ChatLogItemReceived += OnChatLogItemReceived;

            // Plugin.PHost.NewMonsterEntries += OnNewMonsterEntries;
            // Plugin.PHost.NewNPCEntries += OnNewNPCEntries;
            // Plugin.PHost.NewPCEntries += OnNewPCEntries;
            // Plugin.PHost.NewPlayerEntity += OnNewPlayerEntity;
            // Plugin.PHost.NewTargetEntity += OnNewTargetEntity;
            // Plugin.PHost.NewPartyEntries += OnNewPartyEntries;
        }

        public static void UnSubscribe() {
            Plugin.PHost.ConstantsUpdated -= OnConstantsUpdated;
            Plugin.PHost.ChatLogItemReceived -= OnChatLogItemReceived;

            // Plugin.PHost.NewMonsterEntries -= OnNewMonsterEntries;
            // Plugin.PHost.NewNPCEntries -= OnNewNPCEntries;
            // Plugin.PHost.NewPCEntries -= OnNewPCEntries;
            // Plugin.PHost.NewPlayerEntity -= OnNewPlayerEntity;
            // Plugin.PHost.NewTargetEntity -= OnNewTargetEntity;
            // Plugin.PHost.NewPartyEntries -= OnNewPartyEntries;
        }

        private static void OnChatLogItemReceived(object sender, ChatLogItemEvent chatLogItemEvent) {
            // delegate event from chat log, not required to subsribe
            // this updates 100 times a second and only sends a line when it gets a new one
            if (sender == null) {
                return;
            }

            ChatLogItem chatLogEntry = chatLogItemEvent.ChatLogItem;
            try {
                LogPublisher.Process(chatLogEntry);
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        private static void OnConstantsUpdated(object sender, ConstantsEntityEvent constantsEntityEvent) {
            // delegate event from constants, not required to subsribe, but recommended as it gives you app settings
            if (sender == null) {
                return;
            }

            ConstantsEntity constantsEntity = constantsEntityEvent.ConstantsEntity;
            Constants.AutoTranslate = constantsEntity.AutoTranslate;
            Constants.ChatCodes = constantsEntity.ChatCodes;
            Constants.Colors = constantsEntity.Colors;
            Constants.CultureInfo = constantsEntity.CultureInfo;
            Constants.CharacterName = constantsEntity.CharacterName;
            Constants.ServerName = constantsEntity.ServerName;
            Constants.GameLanguage = constantsEntity.GameLanguage;
            Constants.EnableHelpLabels = constantsEntity.EnableHelpLabels;
            Constants.Theme = constantsEntity.Theme;
            PluginViewModel.Instance.EnableHelpLabels = Constants.EnableHelpLabels;
            PluginViewModel.Instance.ChatCodes = Constants.ChatCodes;
        }

        // private static void OnNewMonsterEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        // {
        // // delegate event from monster entities from ram, not required to subsribe
        // // this updates 10x a second and only sends data if the items are found in ram
        // // currently there no change/new/removed event handling (looking into it)
        // if (sender == null)
        // {
        // return;
        // }
        // var monsterEntities = actorEntitiesEvent.ActorEntities;
        // }

        // private static void OnNewNPCEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        // {
        // // delegate event from npc entities from ram, not required to subsribe
        // // this list includes anything that is not a player or monster
        // // this updates 10x a second and only sends data if the items are found in ram
        // // currently there no change/new/removed event handling (looking into it)
        // if (sender == null)
        // {
        // return;
        // }
        // var npcEntities = actorEntitiesEvent.ActorEntities;
        // }

        // private static void OnNewPCEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        // {
        // // delegate event from player entities from ram, not required to subsribe
        // // this updates 10x a second and only sends data if the items are found in ram
        // // currently there no change/new/removed event handling (looking into it)
        // if (sender == null)
        // {
        // return;
        // }
        // var pcEntities = actorEntitiesEvent.ActorEntities;
        // }

        // private static void OnNewPlayerEntity(object sender, PlayerEntityEvent playerEntityEvent)
        // {
        // // delegate event from player info from ram, not required to subsribe
        // // this is for YOU and includes all your stats and your agro list with hate values as %
        // // this updates 10x a second and only sends data when the newly read data is differen than what was previously sent
        // if (sender == null)
        // {
        // return;
        // }
        // var playerEntity = playerEntityEvent.PlayerEntity;
        // }

        // private static void OnNewTargetEntity(object sender, TargetEntityEvent targetEntityEvent)
        // {
        // // delegate event from target info from ram, not required to subsribe
        // // this includes the full entities for current, previous, mouseover, focus targets (if 0+ are found)
        // // it also includes a list of upto 16 targets that currently have hate on the currently targeted monster
        // // these hate values are realtime and change based on the action used
        // // this updates 10x a second and only sends data when the newly read data is differen than what was previously sent
        // if (sender == null)
        // {
        // return;
        // }
        // var targetEntity = targetEntityEvent.TargetEntity;
        // }

        // private static void OnNewPartyEntries(object sender, PartyEntitiesEvent partyEntitiesEvent)
        // {
        // // delegate event that shows current party basic info
        // if (sender == null)
        // {
        // return;
        // }
        // var partyEntities = partyEntitiesEvent.PartyEntities;
        // }
    }
}