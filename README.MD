# Planing document for Umeå's Prop Hunt Game
## Features
### 3 Teams
- Hiders
  - Camoflage as props
    - Prop disguise should rotate on the y-axis along with the players view angle.
    - Player can lock their rotation by pressing a button.
  - Health that depends on the disguises size (Ex. a can would have 5 health while a fridge would have 150 health)
      - Switching props should retain the players health % (Ex. If you are half health as a can and change to a fridge you would be half health.)

- Seekers
  - Hunt Hiders with a variety of weapons (Gun, Pointy stick)
    - Attacking non-hider props deals damage to the seeker
    - Killing a hider restores some health to the seeker

- Spectators
  - Does not participate in the match
  - Switch perspective between living players
  - Free fly mode as well?

### Gameplay
At the start of every round the seekers will be locked in a room (or blinded). During this intial grace period the hiders will be able to find a hiding place without the fear of being spotted. Afterwards the seekers will be released to search the map for the hiders.

The seekers win if they managed to find and kill every hider. If the round time runs out or if every seeker dies the hiders win. After the rounds is over the teams are scrambled.

### UI
- Main menu
  - Host game
  - Join game
  - Options
  - Exit
- GUI
  - Chat
  - Tab menu
    - Scoreboard
- Pause menu
  - Options
  - Main menu
  - Exit
- Options Menu
  - A bunch of options


### Bonus goals
- Text chat
  - Local voice chat (would be cool)
- Hiders can taunt (Plays a sound clip)
- Outline around teammates when dead and spectating