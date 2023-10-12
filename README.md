# SpaceWars
2024 Coding Challenge

## Premise

Turn-based (tick-based) game where players can queue up actions, and once every tick each player's next action is dequeued and executed.  Actions have an order of precedence, where moving happens first, then hits are calculated, then another other action (ship upgrades, weapons upgrades, ship repairs).

Every ship starts off with a certain number of repair credits, and a certain number of upgrade credits.

As long as ships have > 0 health, they can always move at a default speed, and can always fire a default (weak) weapon, regardless of how many upgrade or repair credits they have.

## Entities

- Ship
    - Location (x,y) (where you are)
    - Orientation (0-359) (where you are pointing) **or should this be just Up/UpRight/Right/RightDown/Down/DownLeft/Left/LeftUp? **
    - Health (0-100) (once this reaches 0 you are out of the game)
    - Speed (1-100) (how far you can move in any given tick.  Starts off at 1 but can be upgraded)
    - Shield (0-100) (hits first take out the shield, once the shield is at 0 then remaining hit points go against the ship health)
    - Weapons (a list of available weapons)
    - RepairCreditBalance
    - UpgradeCreditBalance
- Weapon
    - Name
    - Range (a list of distance and effectiveness, i.e. within 5 distance the weapon is 100% effective, from 5-10 it's 60% effective, 10-12 it's 20% effective, 12+ 0% effective)
    - Power (how many hit points at 100% effectiveness)
    - Cost (how many upgrade points it takes to acquire the weapon)
    - ShotCost (how many upgrade points it takes to fire the weapon)
    - ChargeTurns (how many game ticks it takes to charge the weapon)
- PowerUp (*not in initial version*)
    - Location (where it is on the map)
    - UpgradeCredits (how many bonus credits you get)
    - RepairCredits (how many bonus credits you get)

## Player Interaction

Provide two parts to the standard client:

1. A console program from a repo they can clone/fork.  This would have all the interfaces necessary for contestants to add their own logic, their own programmability.  This is what would listen to keyboard events and actually send the player's network requests to the server.
  - Basic actions implemented (join game, send moves, etc.)
  - Basic movements are available
  - Make it easy to plug in custom functionality, something like subclass a 'GameShortcut' abstract class that requires a key / key combination, and has some method you can run to modify the player's action queue, or even have access to a raw HttpClient to send your own requests.
2. A visual dashboard / heads-up-dispaly running in the browser.  A player would join the game from their console app, get a token, and then be able to use that token to open up _their_ dashboard/HUD.  The player's HUD would show:
  - A more high-resolution of what is aroud their ship (this is how we implement the fog of war - the full map shown to everyone up on the projectors is just a rough/inaccurate map, if you want to make good moves you'll base that off of the map in your HUD).
  - The status of your ship, weapons, all your counters, etc.
  - More?

## Questions for discussion

- Repair cost / repair rate - spend $$$ to repair quickly, spend $ to repair slowly?
- Is there a self-healing rate, where you are rewarded x repair value every y ticks?
- How much repair & upgrade credits do you get when you kill someone?  (all of their credits + what else?)
- 

     
## API Endpoints
- /game
    - /join?name={playerName} => returns a token
    - /state?token={playerToken} => returns the game state
      ```json
      {
        "state": "joining (or 'playing', or 'gameOver')",  
        "location": {
            "x": 123,
            "y": 234
        },
        "orientation": {something...degrees or cardinal directions???},
        "ship": {
            "health": 95,
            "speed": 89,
            "shield": 23,
            "weapons": [
                {
                    "name": "Spreadfire",
                    "range": [
                        {
                            "maxDistance": 5,
                            "effectiveness": 1.00
                        },
                        {
                            "maxDistance": 10,
                            "effectiveness": ".50"
                        }
                    ],
                    "power": 25,
                    "purchaseCost": 10,
                    "shotCost": 2,
                    "cargeTicks": 0
                },
                {
                    "name": "Laser of Death",
                    "range": [
                        {
                            "maxDistance": 50,
                            "effectiveness": "1.00"
                        },
                        {
                            "maxDistance": 90,
                            "effectiveness": ".75"
                        },
                        {
                            "maxDistance": 150,
                            "effectiveness": ".4"
                        }
                    ],
                    "power": 40,
                    "purchaseCost": 16,
                    "shotCost": 5,
                    "chargeTicks": 3
                }
            ]
        }
      }
      ```
    - /enqueue?token={playerToken}&action={action}&subAction={subAction}
      |action|possible sub-actions|
      |---|----|
      |turn|right/left|
      |move||
      |charge|weaponName|
      |fire|weaponName|
      |repair||
      |purchase|weaponName|
      |upgrade|upgradeName|
      |reload|weaponName|
    - /clearQueue?token={playerToken}
    - POST /enqueueMany
      ```json
      {
        "token": "{playerToken"},
        "actions": [
            {
                "action": "{action from list above}",
                "subAction": "{sub-action from list above}"
            }
        ]
      }```

## Additional ideas

- Only run two events, a low stakes and a whole-enchilada (maybe insert a preliminary event right at the beginning of the semester to whet peopele's appetites / show off what's possible?)
- Don't add major features between runs, only minor adjustments/tweaks to protect quality of play for all participants.
- Additional prize, coolest / most fun implementation, as judged by faculty
- Have a few bad guy bots alive in the practice environment, so there's something to practice against.
- Make everyone test their clients in the same environment (don't host multiple concurrent games (like last year), don't go out of your way to make it easy for people to host their own server)
- Maybe don't charge for ammo? just recharge time?
- Three ticks a second (?)
- Make available position and orientation of all players, updated every tick
- Rate limit for all players at 2x tick rate? 3x tick rate?  What is reasonable?

