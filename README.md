# Senior Thesis Repo: [PLACE YOUR PROJECT NAME HERE]
## Design Document
### Overview:
This game will be a single-player 2D platformer where the player controls three characters, each a different insect with its own unique abilities. The player will traverse three separate areas with different obstacles to clear and enemies to face. Each section will end with a final “boss battle” that the player must defeat in order to clear the level.

### Important Terms:
PLATFORMER - A "platformer" game focuses on the character overcoming obstacles, collecting items, and defeating enemies using player abilities.

PARENT/CHILD - The Unity editor uses a hierarchy system. When an object is a "child" under another object, it inherits the "parent" object's transform.

TRANSFORM - The "transform" is the position/rotation/scale of an object.

COLLIDER - A "collider" is a component that can be added to an object. It can be used to detect collisions with colliders on other objects. Colliders can also be set to "trigger" to trigger certain events.

RIGIDBODY - A "rigidbody" is a component that allows an object to be affected by Unity's physics system. The object will be moved by gravity and other forces from collisions.

LAYERS & TAGS - Unity uses "layers" and "tags" as helpful organization tools to separate game objects. Tags are a useful way to reference an object in a script.



### Gameplay:
HEALTH - The player has a 3 heart health system–enemy attacks will do different levels of damage.

ENEMIES - There will be a few different types of enemies for each character–some will walk, some will fly, and some will crawl on walls.

ATTACKS - Each character will have its own attack. The beetle character will have a horn attack, the spider will have a bite attack, and the caterpillar will roll.

POWERUPS - There will be various collectibles throughout the map that the player can use to kill enemies. Some may increase damage, speed, or jump height.

BOSS FIGHTS - At the end of each level, there will be a boss fight. Once the player clears the boss, that level will be complete, and they can move on to the next character’s level.


### Characters:
BEETLE (KEVLAR) - The beetle character is restricted to walking and jumping, but its special move is a horn/headbutt attack that knocks enemies backward.

CATERPILLAR (IRA) - The caterpillar character can climb walls. Its special move is a rolling attack that it can use to damage enemies.

SPIDER (JEWEL) - The spider character can shoot webs like a grappling hook to traverse the level. It has a bite attack.


### Level Design:
PLATFORMING - The levels will consist of varying levels of platforming. The beetle level will focus on jumping, while the spider level will have platforms that are further apart.

CLIMBING - In the caterpillar level, the player will be able to scale walls. This level will be more focused on vertical movement.

ENVIRONMENT - The game will have a natural-looking environment, with the characters traversing grassy hills, dirt tunnels, flowers, and trees.


### UI & SFX:
START SCREEN - The start screen will have a ‘Play’ button which leads the player to a ‘Character Select’ menu. Only the first character will be available to play until they beat that level, and then the next character will open up.

PAUSE MENU - The player will be able to pause their game and click the ‘Quit’ button to exit to the main menu.

HEALTH & POWERUPS - On-screen UI will tell the player how many hearts they have and if they have an active powerup.

CHARACTER SFX - The characters will have sound effects for walking, taking damage, and attacking.

ENEMY SFX - The enemies will have sound effects for taking damage, attacking, and flying.

ENVIRONMENT SFX - There will be background music in the start menu and during gameplay.
