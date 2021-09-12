using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BlackoutCooldown
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the plugin automaticly update?")]
        public bool AutoUpdate { get; set; } = true;

        [Description("Cooldown for SCP-079 Room Blackouts?")]
        public int BlackoutCooldown { get; set; } = 60;

        [Description("How long should a Hint be displayed that you have to wait before Blackout a Room again? (-1 = Disabled)")]
        public int EnterBlackoutHintTime { get; set; } = 3;

        [Description("What hint should be displayed that you have to wait before Blackout a Room again? %time% will be replaced with the Cooldown Time")]
        public string EnterBlackoutHintMessage { get; set; } = "<color=red>You Blackout a Room, you are now on cooldown for %time% Seconds";

        [Description("How long should a Hint be displayed when Room Blackout is on cooldown? (-1 = Disabled)")]
        public int OnCooldownBlackoutHintTime { get; set; } = 3;

        [Description("What hint should be displayed when Room Blackout is on cooldown? %remaining% will be replaced with the time until Room Blackout is avaiable again!")]
        public string OnCooldownBlackoutHintMessage { get; set; } = "<color=red>Room Blackout is currently on cooldown!</color> <color=blue>%remaining% Seconds</color>";
    }
}
