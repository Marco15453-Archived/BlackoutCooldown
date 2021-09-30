# BlackoutCooldown
A simple plugin that adds an Cooldown for SCP-079 Room Blackout\
**THIS PLUGIN HAS BEEN ARCHIVED**

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
auto_update | bool | Should the plugin automaticly update? | true
blackout_cooldown | int | Cooldown for SCP-079 Room Blackouts? | 60
enter_blackout_hint_time | int | How long should a Hint be displayed that you have to wait before Blackout a Room again? (-1 = Disabled) | 3
enter_blackout_hint_message | string | What hint should be displayed that you have to wait before Blackout a Room again? %time% will be replaced with the Cooldown Time | <color=red>You Blackout a Room, you are now on cooldown for %time% Seconds
on_cooldown_blackout_hint_time | int | How long should a Hint be displayed when Room Blackout is on cooldown? (-1 = Disabled) | 3
on_cooldown_blackout_hint_message | string | What hint should be displayed when Room Blackout is on cooldown? %remaining% will be replaced with the time until Room Blackout is avaiable again! | <color=red>Room Blackout is currently on cooldown!</color> <color=blue>%remaining% Seconds</color>

# Default Config
```yml
blackout_cooldown:
  # Should the plugin be enabled?
  is_enabled: true
  # Should the plugin automaticly update?
  auto_update: true
  # Cooldown for SCP-079 Room Blackouts?
  blackout_cooldown: 60
  # How long should a Hint be displayed that you have to wait before Blackout a Room again? (-1 = Disabled)
  enter_blackout_hint_time: 3
  # What hint should be displayed that you have to wait before Blackout a Room again? %time% will be replaced with the Cooldown Time
  enter_blackout_hint_message: <color=red>You Blackout a Room, you are now on cooldown for %time% Seconds
  # How long should a Hint be displayed when Room Blackout is on cooldown? (-1 = Disabled)
  on_cooldown_blackout_hint_time: 3
  # What hint should be displayed when Room Blackout is on cooldown? %remaining% will be replaced with the time until Room Blackout is avaiable again!
  on_cooldown_blackout_hint_message: <color=red>Room Blackout is currently on cooldown!</color> <color=blue>%remaining% Seconds</color>
```
