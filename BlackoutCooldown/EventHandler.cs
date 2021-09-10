using Exiled.Events.EventArgs;
using MEC;
using System;

namespace BlackoutCooldown
{
    internal sealed class EventHandler
    {
        public void onLockingDown(LockingDownEventArgs ev)
        {
            if(BlackoutCooldown.Instance.activeCooldowns.ContainsKey(ev.Player))
            {
                DateTime usableTime = BlackoutCooldown.Instance.activeCooldowns[ev.Player] + TimeSpan.FromSeconds(BlackoutCooldown.Instance.Config.BlackoutCooldown);
                if (DateTime.Now > usableTime)
                {
                    BlackoutCooldown.Instance.activeCooldowns.Remove(ev.Player);
                    if (BlackoutCooldown.Instance.Config.EnterBlackoutHintTime > 0)
                        ev.Player.ShowHint(BlackoutCooldown.Instance.Config.EnterBlackoutHintMessage.Replace("%time%", BlackoutCooldown.Instance.Config.BlackoutCooldown.ToString()), BlackoutCooldown.Instance.Config.EnterBlackoutHintTime);
                    BlackoutCooldown.Instance.activeCooldowns[ev.Player] = DateTime.Now;
                    return;
                }
                if (BlackoutCooldown.Instance.Config.OnCooldownBlackoutHintTime > 0)
                    ev.Player.ShowHint(BlackoutCooldown.Instance.Config.OnCooldownBlackoutHintMessage.Replace("%remaining%", Math.Round((usableTime - DateTime.Now).TotalSeconds, 2).ToString()), BlackoutCooldown.Instance.Config.OnCooldownBlackoutHintTime);
                ev.IsAllowed = false;
                return;
            }

            if (BlackoutCooldown.Instance.Config.EnterBlackoutHintTime > 0)
                ev.Player.ShowHint(BlackoutCooldown.Instance.Config.EnterBlackoutHintMessage.Replace("%time%", BlackoutCooldown.Instance.Config.BlackoutCooldown.ToString()), BlackoutCooldown.Instance.Config.EnterBlackoutHintTime);
            BlackoutCooldown.Instance.activeCooldowns[ev.Player] = DateTime.Now;
        }
    }
}
