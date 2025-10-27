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

## Week 6 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 7 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 8 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

---

## Week 9 Summary (MM/DD/YYYY)
### This week I worked on:

[Your answer here]

### This week I learned:

[Your answer here]

### My successes this week were:

[Your answer here]

### The challenges I faced this week were:

[Your answer here]

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
