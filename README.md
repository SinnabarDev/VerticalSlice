# GDIM33 Vertical Slice

## Milestone 1 Devlog

1. Pick 1 Visual Scripting Graph in your game and explain how it works. This answer should be about a paragraph.
   One visual scipt in my game is the plunger graph. The plunger graph on start node get the local postion of the plunger and set the originalposition object variable to this vector3. On update the graph checks input get key down space seting isChargin object variable boolean to true or false if node. if true the the charge rate multiplied by timedelta gets added by get power but the is clamp by the math clamp node accepting object variable maxoutput then power is set by set variable then clamped by the pullback variable node ultimately creating a vector 2 distance to set a transform set postion for the plunger to be pulled down its position. If isChargin is false then get postion and variable orignalposition from the on start is vector 3 lerp node and set as postion in the next node. The plunger also has a add force rigidbody 2d logic to it but it is currently disable because I found that impluse was launching the ball premeturely this was a oncollision enter node that checked for the gameobject tag Ball.
2. Update your break-down with the state machine system you're using in your game, and attach your new break-down in your Devlog. Then, explain what you updated about your break-down, how your state machine works, and how your state machine is related to OTHER systems in your game. This answer may take about 2 paragraphs.
   [Updated Breakdown Google Drawing](https://docs.google.com/drawings/d/1rDadNLUu3eKdqkvgikzgiEYu6WRma7Pcq5lvztv7wWY/edit?usp=sharing)
   I have updated my breakdown to include scriptable objects as coins and the coinmachine is the spawner and coin manager applying the modifier to the game. I add NPC to my breakdown because the NPC will move with Navmesh and Navagent and inherit hittable which branches off from the bumper logic already prexist in my game.
   The state machine in my game has two states the active play state where the player is interacting with traditional pinball controls with untraditional mechanics. The state machine transtion checks if 3 balls have been destroyed this is my version of 3 lives if so then the state machine transistions to the passive play state where mouse input is used to interact with a slot/coin operated machine which cost 100 points and generates 3 choices of coins each with its own modifier to the active play state. To transistion back to the active game state players will input "Escape" key to return to active play state.

## Milestone 2 Devlog

Milestone 2 Devlog goes here.

## Milestone 3 Devlog

Milestone 3 Devlog goes here.

## Milestone 4 Devlog

Milestone 4 Devlog goes here.

## Final Devlog

Final Devlog goes here.

## Open-source assets

- Cite any external assets used here!
