# Project Review

## Ángel Ramírez

---

<!-- Your review goes here -->
<!-- Explain why you did the things that way or any snippet that is word mentioning -->
<!-- If you had any issue and how you resolved them -->

## Comment the execution time for each issue closed:
  - UI took me about 30 minutes from setting the Canvas for every menu to implement all the code for turning them
on/off correctly.
  - Gameplay took me the expected amount of time.
  - Saving system took me way less time than I expected. I mainly thought it'd take me 25 minutes because I always 
have to look up how to implement the BinaryFormatter but it was quick.
  - I'd also add like 20 minutes I took thinking on how to implement the tasks before I sent you my first estimations.
## Review the project (what you learn, where you struggle, what you liked from what you did, if we should pay attention on a particular piece of the project). You can use the Review.md for this:
  - It was an easy project overall. My major struggle was deciding how to connect the MainCharacter-LevelManager-GameManager for a good communication between those scripts. 
  - I liked how I made the platform 'spawning' system and the LevelManager: 
     + I changed the 3d models so they are much bigger with just a small hole inside so I don't have issues by holes appearing on one side if they are spawned too close to the
other side (X) of the level.
     + There isn't any instancing, destroying, enabling or disabling. They are setup at the beginning of the level with a random value on X for displacement. Everytime they hit
a trigger on the top, they are sent down. This way I also don't need to control a spawn rate because it just gets faster as the same pace at their moving speed increases. 
     *Note: For the trigger, I had to add a rigidbody so I used the physics layers to avoid them from colliding with everything but from the player and the trigger on top of the level.

From the bonus points I made the ones I think are more focused on programming:  
- The longer the game lasts, the faster the platforms should move (and the spawn rate should also become smaller)  
- Don't use PlayerPrefs for highscore persistence.  
- Don't use OnBecameInvisible for destroying the player.  
- When restarting the game, don't reload the scene.