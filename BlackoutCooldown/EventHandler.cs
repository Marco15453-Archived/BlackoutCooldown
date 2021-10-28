using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;

namespace BlackoutCooldown
{
    internal sealed class EventHandler
    {
        public BlackoutCooldown plugin;
        public EventHandler(BlackoutCooldown plugin) => this.plugin = plugin;

        private Dictionary<Player, DateTime> activeCooldowns = new Dictionary<Player, DateTime>();

        public void onLockingDown(LockingDownEventArgs ev)
        {
            if(activeCooldowns.ContainsKey(ev.Player))
            {
                DateTime usableTime = activeCooldowns[ev.Player] + TimeSpan.FromSeconds(plugin.Config.BlackoutCooldown);
                if (DateTime.Now > usableTime)
                {
                    activeCooldowns.Remove(ev.Player);
                    if (plugin.Config.EnterBlackoutHintTime > 0)
                        ev.Player.ShowHint(plugin.Config.EnterBlackoutHintMessage.Replace("%time%", plugin.Config.BlackoutCooldown.ToString()), plugin.Config.EnterBlackoutHintTime);
                    activeCooldowns[ev.Player] = DateTime.Now;
                    return;
                }
                if (plugin.Config.OnCooldownBlackoutHintTime > 0)
                    ev.Player.ShowHint(plugin.Config.OnCooldownBlackoutHintMessage.Replace("%remaining%", Math.Round((usableTime - DateTime.Now).TotalSeconds, 2).ToString()), plugin.Config.OnCooldownBlackoutHintTime);
                ev.IsAllowed = false;
                return;
            }

            if (plugin.Config.EnterBlackoutHintTime > 0)
                ev.Player.ShowHint(plugin.Config.EnterBlackoutHintMessage.Replace("%time%", plugin.Config.BlackoutCooldown.ToString()), plugin.Config.EnterBlackoutHintTime);
            activeCooldowns[ev.Player] = DateTime.Now;
        }
    }
}
