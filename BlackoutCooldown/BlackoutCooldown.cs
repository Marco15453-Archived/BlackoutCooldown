using Exiled.API.Features;
using System;
using System.Collections.Generic;

namespace BlackoutCooldown
{
    public class BlackoutCooldown : Plugin<Config>
    {
        internal static BlackoutCooldown Instance;

        public override string Name => "BlackoutCooldown";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public Dictionary<Player, DateTime> activeCooldowns = new Dictionary<Player, DateTime>();

        private EventHandler eventHandler;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
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
