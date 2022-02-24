# 2D-Controller

## What is it?
A simple 2D character controller made in Unity, using Rigidbody2D, with features to improve the platforming experience

## What does it do?
This controller has several features to improve the player experience on a platformer game, mostly on the jump, it includes:

- Variable jump height, or ending a jump early by releasing the button
- Higher gravity when coming back down for a Mario style jump
- Jump buffering (which, in my opinion dramatically improves platforming) to ready a jump a bit before touching the ground
- Clamped fall speed for extra control in the air
- Coyote time, still being able to jump for a short time after leaving a platform, for player forgiveness
- Apex modifiers or giving a small amount of anti-gravity and a speed boost at the apex of a jump
- A smooth camera, which will follow the player and reduces jittery movement
- Reduce movement speed with a "walk" button

## Setup

1. Set up a player gameobject with a Rigidbody2D and a BoxCollider2D (NOTE: I haven't tested these scripts with Rigidbody and BoxCollider, and you'll need to change the code to make those work).
2. Add the Movement2DController and Player scripts to the gameobject.
3. Make a new layer and apply it to any obstacles in your scene, pass the name of the layer to the Movement2DController script in the inspector, obstacles should have a BoxCollider2D themselves and a PhysicsMaterial2D with no friction, otherwise the player'll stick to the walls when running against them.
4. Don't make the camera a child of the player, instead give it a CameraPlayer script and pass it a reference to your player.
