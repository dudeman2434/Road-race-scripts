# Road-race-scripts
For the current project crazy road race
The scripts are in C# and have been made for Unity engine. The physics have been applie in 3D.
Functionality of scripts:
1) Camera_controller.cs: Enables the camera to follow the player.
2) MENU - The scrips in this section deal with the UI part of the game. The functionality  corresponds to the name of the scripts. The death.cs script contains an advertisement section in Quit_to_main() function which can be removed if preferred.
3)MOVEMENT - The Player_movement.cs enables the player to move by touch/click inputs and increase points in combination with the SCORING scripts. The Enemy_movement.cs is similar to Player_movement.cs but the movement is automatic(needs some more improvement).
4)PLATFORM - Platform_generator.cs and Platform_destroyer.cs generates and deactivates the platforms generated respectively, selected from the object pool by Object_pool.cs, depending on the view of the camera. Enemy_pool.cs can hold multiple enemies and generate them randomly along with the platform. Game_manager.cs manages the various aspects of the game like the generation and deactivation point of platform and enemies, the score display and buttons.
5)SCORING - The scripts in this section manage the score of the player. cash_generator.cs generates points on platform that can be picked up by the player for scores. pickup_points.cs enables player to collect the points and then disables it after it's picked up by the player. Score_manager.cs manages the points collected by the player and displaying the current score and the high score of the current play.
