# GDIM33 Vertical Slice

## Milestone 1 Devlog

1. Pick 1 Visual Scripting Graph in your game and explain how it works. This answer should be about a paragraph.
   One visual scipt in my game is the plunger graph. The plunger graph on start node get the local postion of the plunger and set the originalposition object variable to this vector3. On update the graph checks input get key down space seting isChargin object variable boolean to true or false if node. if true the the charge rate multiplied by timedelta gets added by get power but the is clamp by the math clamp node accepting object variable maxoutput then power is set by set variable then clamped by the pullback variable node ultimately creating a vector 2 distance to set a transform set postion for the plunger to be pulled down its position. If isChargin is false then get postion and variable orignalposition from the on start is vector 3 lerp node and set as postion in the next node. The plunger also has a add force rigidbody 2d logic to it but it is currently disable because I found that impluse was launching the ball premeturely this was a oncollision enter node that checked for the gameobject tag Ball.
2. Update your break-down with the state machine system you're using in your game, and attach your new break-down in your Devlog. Then, explain what you updated about your break-down, how your state machine works, and how your state machine is related to OTHER systems in your game. This answer may take about 2 paragraphs.
   [Updated Breakdown Google Drawing](https://docs.google.com/drawings/d/1rDadNLUu3eKdqkvgikzgiEYu6WRma7Pcq5lvztv7wWY/edit?usp=sharing)
   I have updated my breakdown to include scriptable objects as coins and the coinmachine is the spawner and coin manager applying the modifier to the game. I add NPC to my breakdown because the NPC will move with Navmesh and Navagent and inherit hittable which branches off from the bumper logic already prexist in my game.
   The state machine in my game has two states the active play state where the player is interacting with traditional pinball controls with untraditional mechanics. The state machine transtion checks if 3 balls have been destroyed this is my version of 3 lives if so then the state machine transistions to the passive play state where mouse input is used to interact with a slot/coin operated machine which cost 100 points and generates 3 choices of coins each with its own modifier to the active play state. To transistion back to the active game state players will input "Escape" key to return to active play state.

## Milestone 2 Devlog

## Milestone 2 Devlog
1. Write scriptable object code with my data points.
   - Create RewardTypes based on the modifier desired.
   - Create String Title Name.
   - Create String Text Description.
   - Create sprite icon field.
   - Create int value for rarity.
   - All fields will be passed to a container or prefab.
   - The title name will be a text field to define the object to the player.
   - Sprite will be passed to the container.
   - Description will be passed to container.
   - RewardType will be read from the coin machine script.
   - Amount/modifier will be read from the coin machine script.
2. Create ui/Coin generation manger.
   - UI will be probaly a button with CoinMachine sprite.
   - Component with script coinmanager/generator.
   - 3 container gameobjects to hold instaite coin game child.
   - Coins need to have visual and be button on click().
3. Make other code or interactions read the code.
   - Coin Machine will store a list of scriptable objects and generate from this pool.
   - An array will spawn 3 scriptable objects at RAND.
   - There will be a way to input and apply reward type read from the scriptable object selected.
   - gameObjects are then destroyed.
   - Coin Machine will read the graph and scene variables in graphs that the modifiers target.

## ANSWER THIS AFTER CODING: 
1. Did the task steps break-down activity & quiz question (from W5) help you build a feature for this Milestone? Why or why not, and what would you do to improve your break-downs to be more helpful if you were to do them again?
Yes the task break down activity did help me to build this feature as it helped me to seperate the high level tasks needed and the individual steps or components to funnel into the breakdown goals. This was able to help me envision the steps to reach my milestone.
2. Explain how you bridged visual scripting and code in your game. Are you calling a custom event from a Graph from a C# method, or vice versa, and what purpose does this serve in your architecture? Make sure to name the C# script(s) involved, and attach a screenshot of the relevant Graph.
My visual scripting that bridges the code in my game is a script graph that controls hinges in my game. Unfortunately the motor speed needs to be called by code geting the component setting which is unabled to be set specifically in the visual script graph nodes as the input is a joint2d node. There I use the script (C# Flipper.cs) to store the motor speed and update when powerup influence the motor speed going up and down individually for both flipper controls.
[VScript C# Google Drawing](https://docs.google.com/drawings/d/1LeMLj8s50WFcKiaQj641pIOIj1642RkLF1U1SAxtKoU/edit?usp=sharing)
3. Briefly explain (in 1-2 sentences) what Unity system you want us to grade for Feature (3). It doesn't matter if it's what you originally pitched- pick your best one and tell us where to find it so we can give you credit. I want to grade my scriptable object Coins these are reward modifiers that can be found in my rouge like state (passive state) once the player reaches 3 balls falling into the hole per round.

## Milestone 3 Devlog

Milestone 3 Devlog goes here.

## Milestone 4 Devlog

Milestone 4 Devlog goes here.

## Final Devlog

Final Devlog goes here.

## Open-source assets

- Cite any external assets used here!
