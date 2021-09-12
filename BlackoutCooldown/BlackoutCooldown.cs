using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;

namespace BlackoutCooldown
{
    public class BlackoutCooldown : Plugin<Config>
    {
        internal static BlackoutCooldown Instance;

        public override string Name => "BlackoutCooldown";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 2, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public Dictionary<Player, DateTime> activeCooldowns = new Dictionary<Player, DateTime>();

        private EventHandler eventHandler;

        private CoroutineHandle updateCoroutine;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            if (BlackoutCooldown.Instance.Config.AutoUpdate) updateCoroutine = Timing.RunCoroutine(AutoUpdater.AutoUpdates());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Timing.KillCoroutines(updateCoroutine);
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            eventHandler = new EventHandler();

            // SCP-079
            Exiled.Events.Handlers.Scp079.LockingDown += eventHandler.onLockingDown;
        }

        private void UnregisterEvents()
        {
            // SCP-079
            Exiled.Events.Handlers.Scp079.LockingDown -= eventHandler.onLockingDown;

            eventHandler = null;
        }
    }
}
