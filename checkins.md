## Week 1 Summary (09/22/2025)

### This week I worked on:

I set my Unity project up with GitHub and worked on my Design Document for my game.

### This week I learned:

When setting up a repository with a gitignore file, the file has to be in the root folder of the Unity project.
Each time the project is opened or closed, there are hundreds of files that are updated.

### My successes this week were:

I further developed all of the features and mechanics I want in my game.

### The challenges I faced this week were:

I struggled to set up version control the first time around because I had my gitignore file in the wrong place.

---

## Week 2 Summary (09/29/2025)
### This week I worked on:

I started with a 3D template in Unity, so I downloaded Unity's 2D packages and configured the scene and camera to be 2D. I set up a basic scene with a ground platform and a character. The player can control the character using the WASD keys + the spacebar to jump. The camera is currently childed under the character so it follows the character's movement.

### This week I learned:

I was originally going to use a 2.5D approach to build this game, which would mean using 2D and 3D elements. However, I wanted to use mostly 2D sprites for the game art. Using 2D sprites on 3D objects requires "billboarding" them, which is basically making the sprite always face the camera. This was a bit more complicated than I initially thought, so I decided to go entirely 2D instead.

### My successes this week were:

I successfully created the most basic functions of my character controller and learned more about configuring Unity to work in both 2D and 3D applications.

### The challenges I faced this week were:

Switching my game plan from 2D and 3D elements to entirely 2D.

---

## Week 3 Summary (10/06/2025)
### This week I worked on:

I planned out my first sprint and began implementing it; my main focus for this sprint is player and enemy interaction. This week, I worked on creating an enemy that can patrol between two points, chase the player, and damage the player. I also created a health script so the player and enemies can die.

### This week I learned:

Working with multiple trigger colliders can be challenging; they sometimes need to be on child objects for functions like OnTriggerEnter2D to work properly. I also learned that changing the scale of a 2D object will flip the way it is facing. 

### My successes this week were:

I have an enemy that can patrol between two points and attack the player.

### The challenges I faced this week were:

I still have a few bugs I'm working to fix. At the moment, the player still cannot damage the enemy, and the enemy cannot chase the player and then return to its patrol route.

---

## Week 4 Summary (10/13/2025)
### This week I worked on:

I fixed the bug where the player cannot damage the enemy. The player can now attack by pressing the E key when within a certain range of the enemy, damaging the enemy's health and knocking it back.

### This week I learned:

Instead of using a collider set to trigger, I learned that you can use a RaycastHit2D, which casts a circle around the player that returns info about any colliders it hits. Each enemy collider within range is stored in an array, so the player can hit multiple enemies at once.

### My successes this week were:

I did some research and found a better way to achieve the functionality I wanted.

### The challenges I faced this week were:

I had to rework the way I was thinking about the player's attack, and I had issues with time management and other responsibilities this week.

---

## Week 5 Summary (10/20/2025)
### This week I worked on:

I added a second "flying" enemy type that follows a patrol and shoots projectiles straight down. The projectiles damage the player and are destroyed once they make contact or fall past the ground.

### This week I learned:

The player's attack did double damage because of the enemies' second collider used for their attack range; to fix this, I moved their attack range collider onto an empty child object and moved the enemy script to that object.

### My successes this week were:

I got a working projectile system that can damage the player.

### The challenges I faced this week were:

I tried destroying the projectiles when they collided with the ground object, but that didn't seem to work. I've changed it to a check to see if they travel past a certain distance, but I'd like to use the ground's collider if possible.

## Week 6 Summary (10/27/2025)
### This week I worked on:

I took a break this week, but I did go in and fix an error where the attackable layer in the player script was set to the Ground layer instead of the Enemy layer. I also planned out the end of my first sprint. I'd like to implement an enemy chase mechanic and possibly a mechanic to block enemy attacks.

### This week I learned:

I deleted and re-added the Ground layer last week, which changed the order of all my other layers. There were several instances where I had to go in and change the layer set on an object or in a script.

### My successes this week were:

I planned out the rest of my first sprint.

### The challenges I faced this week were:

I didn't realize deleting a layer would reorder all of the others, so I had to do some clean up after that.

---

## Week 7 Summary (11/03/2025)
### This week I worked on:

I finished up most of the combat system by implementing a block mechanic & an enemy that can chase the player and then return to its patrol path. When holding shift, the enemy becomes immune to all attacks, including projectiles. Melee enemies become stunned for 3 seconds when they attempt to attack the player while they are blocking.

### This week I learned:

I am using a coroutine to stun the enemies for 3 seconds in a separate script. To call the coroutine from the attack script, I found that creating a public method in the stunned script that starts the coroutine was the easiest approach.

### My successes this week were:

I successfully implemented the last two features I wanted in the combat mechanics.

### The challenges I faced this week were:

There are still a few small bugs I'd like to revisit. When the player first enters an enemy's chase range, the enemy moves very quickly towards the player because I'm not normalizing the speed. I'll need to go back and change how I'm handling the enemy movement. Also, once the enemy is stunned for the first time, if the player continues to block, the enemy is able to push against the player before attacking again. I'd like to fix that issue at some point as well.

---

## Week 8 Summary (11/10/2025)
### This week I worked on:

I began working on my second sprint, which will consist of level design features like traps, obstacles, and powerups. This week, I added two obstacles, spikes and a crusher. If the player collides with the spikes object, they take damage & become slow. The crusher moves up and down between two points, and if the player stands beneath it, they are crushed and die.

### This week I learned:

I looked into assets to add to make my game more visually interesting, and learned that many assets for 2D use tilemaps. Tilemaps are grids that allow objects to be evenly placed, making level design easier. Some assets come with tilesets, which are sets of blocks that can make up the ground the player walks on. These assets can be pretty large, so I'm trying to find one that won't take up too much space.

### My successes this week were:

I have the beginnings of two obstalces for the player to interact with, did some research into assets for my game, and removed the camera from the player object & added a script for the camera to follow the player instead.

### The challenges I faced this week were:

There are a few additions I'd like to make to the spikes and crusher obstacles, like triggering the crusher only if the player is standing beneath it and setting up a coroutine to damage the player multiple times if they stand in the spikes.

---

## Week 9 Summary (11/17/2025)
### This week I worked on:

I continued to work on my second sprint. I added improvements to the spikes and crusher traps from last week: the crusher script has been moved onto the player for easier collider checks, and I added a coroutine that damages the player over time if they stand on spikes. I also added a powerup that allows the player to double jump and a health pickup that restores the players health. Finally, I added a moving platform I plan to implement into level design, and started working on a water obstacle that can kill the player.

### This week I learned:

I had a bit of trouble getting the coroutine to work for my spikes, but I learned that using a while loop inside of a coroutine allows me to carry out the pause function continuously. I also struggled with updating the player's transform when on the moving platform. I was originally adding force to the rigidbody or updating the transform every frame, but then I figured out that I could just make the player a child of the platform when it collides with it, which automatically updates its transform.

### My successes this week were:

I made substantial progress in my second sprint, and the game mechanics are now more interesting.

### The challenges I faced this week were:

I had some trouble with the water obstacle. I want to disable the player's movement script so the player sinks to the bottom and "drowns," but the inputs are still being read even after disabling the player controller script for some reason.

---

## Week 10 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 11 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 12 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 13 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---
