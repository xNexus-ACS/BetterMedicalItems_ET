using PluginAPI;
using System;
using PluginAPI.Enums;
using PlayerHandler = PluginAPI.Events.PlayerEvents;
using PluginAPI.Events.EventArgs;
using SCP_ET;

namespace BetterMedicalItems_ET
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "xNexus-ACS";
        public override string Name { get; } = "BetterMedicalItems";
        public override PluginType Type { get; } = PluginType.Utility;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public override Version Version { get; } = new Version(0, 1, 0);
        public override Version RequiredVersion { get; } = new Version(0, 4, 3);

        public override void OnEnabled()
        {
            PlayerHandler.PlayerUseMedicalItem += Player_UseMedicalItem;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.PlayerUseMedicalItem -= Player_UseMedicalItem;
            
            base.OnDisabled();
        }

        private void Player_UseMedicalItem(PlayerUseMedicalItemEvent ev)
        {
            if (ev.ItemType == ItemType.MedkitSmall)
            {
                ev.Player.Health = 200;
                ev.Player.MaxHealth = 200;
            }

            if (ev.ItemType == ItemType.Medkit)
            {
                ev.Player.Health = 250;
                ev.Player.MaxHealth = 250;
            }
        }
    }
}