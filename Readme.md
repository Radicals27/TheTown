## The Motivation
I was tired of games in which the NPC towns/cities felt dead and lifeless, as if they only operated in response to the player.  I wanted to create a simulation of a (small) town that did not require player input at all. 

![The Town Simulation Game](TheTown.gif "The Town Simulation Game")


## Gameplay
I decided to incorporate Goal-Oriented Action Planning (GOAP), as used in such titles as 'FEAR' (2005).  It gives each NPC agent a list of goals and associated importances for each goal.  Goals such as eat, drink, sleep and work.

The agents have access to an array of actions that have pre-requisites and consequences.  They are intelligent enough to then string together a chain of actions that will lead to the satisfaction of a goal (or goals).

It is an interesting way of adding complexity to a game.

## Technology
This was developed in Unity 2019 using C#.  Models were from Mixamo.com.

## Status
This is simply a prototype, it is in development as an experiment and will be developed further for an idnefinite amount of time.