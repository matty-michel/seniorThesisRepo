# Senior Thesis Repo: [PLACE YOUR PROJECT NAME HERE]
This repository is provided to help you build your senior thesis project. You will edit it to store your specification documents, code, and weekly checkins.

First, fork this repo (this makes a copy of it associated with your account) and then clone it to your machine (this makes a copy of your fork on your personal machine). You can then use an editor and a GitHub client to manage the repository.

### Markdown
This file is called README.md. It is a [Markdown file](https://en.wikipedia.org/wiki/Markdown). Markdown is a simple way to format documents. When a Markdown-ready viewer displays the contents of a file, it formats it to look like HTML. However, Markdown is significantly easier to write than HTML. VSCode supports displaying Markdown in a preview window. GitHub uses Markdown extensively including in every repo's description file, ```README.md```.

All Markdown files end with the extension ```.md```. There is a Markdown tutorial [here](https://www.markdowntutorial.com/) and a Markdown cheatsheet [here](https://www.markdownguide.org/cheat-sheet/).

#### Images
If you would like to add images to a Markdown file, place them in the ```docs/images/``` directory in this repo and reference them using markdown like this:

```
![alt text](relative/path/to/image)
```

Here is how to add the Carthage logo to a Markdown file (you can see the image in the repo right now):

```
![Carthage Firebird Logo](docs/images/firebirdLogo.jpg)
```
![Carthage Firebird Logo](docs/images/firebirdLogo.jpg)

This ensures that images are correctly linked and displayed when viewing the documentation on GitHub or any Markdown-supported platform.

## Code
The ```code``` directory is used to store your code. You can put it all in one directory or you can create subdirectories.

I have added a ```main.cpp``` file to get you started. Feel free to remove it.

If you have any questions feel free to ask me! I'll answer professor questions, customer questions, and give advice if asked.


## Design Document
### Overview:
This game will be a single-player 2D platformer where the player controls three characters, each a different insect with its own unique abilities. The player will traverse three separate areas with different obstacles to clear and enemies to face. Each section will end with a final “boss battle” that the player must defeat in order to clear the level.


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
