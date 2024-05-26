# Marble Battle

Marble Battle is my final project for the CS50G course, made with Unity.

## Quick Description
It's an action-roguelike third-person game. You play as Suzy's hand, a 7-year-old girl who imagines epic stories.
She's the Marble Queen and wants to defeat her opponents to save her kingdom.
You control a marble in an arena and are attacked by various enemies.
You can move by dragging and dropping to give your marble an impulse.
The goal is to hit the enemies with enough speed and mass to inflict damage on them.
When every enemy is defeated, you can upgrade your marble to become stronger.
Every level is more difficult than the previous one, and you have to reach the fifth level without dying.

## Inspiration and Theme
I'm a big fan of roguelike games and wanted to take the opportunity to build one.
I've spent dozens of hours playing Hades and loved how the game allows for fast-paced fights and 
a strong sense of action. The upgrade choices are very interesting and the game lets us test out
various builds to develop our playstyle.
I was inspired by Colton's demonstration of many colored balls that bounce around, which I found very
satisfying.
I wanted to implement a beginner-friendly version of Hades. I tried to make
an action-roguelike game with build choices, but the objective was to make a game 
easy enough and with a catchy theme. I directly thought about a childish theme
that could fit with everyone's experiences. What's better than a game that everyone
played in their life and can easily bring nostalgia?

## Gameplay
I wanted very basic gameplay on purpose, to let everyone have fun with it
without requiring many skills. You have only one move during the game:
Drag and drop your mouse to aim and give an impulse to your marble.
This is the main gameplay mechanic, so I tried to make it as satisfying as possible.
To ensure this, I included:
- A slowdown during the move (letting the player aim well and giving a cool bullet-time effect)
- Cinematic effects with black stripes (it's cool and gives a western feeling when you are about to shoot)
- A stamina bar to ensure you can't spam this move

The stamina bar was really mandatory for me. It sets a limit to the impulse,
and adds a really cool emergent gameplay element. Should I strike the marble heavily and consume all my stamina,
or should I manage my remaining stamina well to have the opportunity to dodge later?
This results in an interesting way to move because during the fight, the player has to
manage this resource well and make choices about their actions.

I included two different AIs for the enemies. One of them is a simple AI that chases the player.
Not very dangerous, but they won't let you rest. You have to avoid them, play around
their predicted trajectory...
The other one is more aggressive. Periodically, this ball will charge at you with great speed and
can inflict serious damage.

The interesting thing about these AIs is that they are predictable, which encourages the player
to strategize to counter them and take advantage of their
movements. For example, the player can position some marbles between themselves and the aggressive one.
The aggressive one will try to charge at the player but will hit other marbles, damaging them!

## Level Design
I imagined small, enclosed arenas to force the player to react.
Enemies spawn close to the player and don't let them rest!
The player has to attack, defend, or avoid the enemies. I wanted an action-driven 
game and this kind of level helped to achieve this objective.

To add some variety, I included:
- 5 different levels with various shapes
- Obstacles to create interesting emergent gameplay (hide and seek, avoid enemies...)
- Bumpers that allow you to speed up your marble
- Little ski jumps to add some verticality.

## Progression
Between each level, the player has the opportunity to choose one upgrade.
They can upgrade:
- Maximum Health
- Maximum Stamina
- Stamina Regeneration
- Size
- Mass

Each choice allows for building a unique playstyle. For example, a player can 
choose to upgrade stamina and stamina regeneration to have great flexibility and move
easily inside the arena. They could play another run with more size
and more mass to feel very heavy and strike the 
enemies with huge power, but it will lack mobility.

## Audio and Visuals
I aimed for a childish style with a chill ukulele soundtrack.
I made an introduction with childish drawings and tried to design levels and
graphics that suggest we are in a child's room.
Viviana Estrada, a professional voice actress, helped me to 
record Suzy's voice. This greatly contributed to giving the game a natural
feeling. You feel like you are in Suzy's mind, playing epic
marble battles in her room!

I have to credit fiftysounds.com for the music.

## Future
I have many ambitious ideas for this game and will continue to develop it.
Here's a list of various ideas to take the game to the next level:
- Create various enemy AIs
- Implement traps to make levels more interesting
- Implement an economy to buy, sell, and manage power-ups
- Add different types of marbles (wooden, metallic, etc.)
- Balance and add more interesting choices for power-ups (damping, elasticity, new powers...)
- Create boss fights
- Implement progression between runs (like in Hades or other roguelike games)

## Conclusion
I really loved working on this project. It allowed me to experiment with roguelike mechanics,
a genre I love, and I want to make an interesting and original roguelike game.
I think my game has original ideas and gameplay. It's pretty simple, but with adjustments, it could
be a fun game with easy-to-learn, hard-to-master mechanics. 
I learned that the most challenging part is balancing the game. Making it fair but not too hard is really tricky.
Creating a solid game system that's easy to work with was also challenging. I may need to learn more about
ScriptableObjects, interfaces, and other Unity tools that could help me make a cleaner and more scalable game workflow.

I hope you loved my project, and again, thanks for all these courses that helped me gain many
game development skills. Now I want to learn more, continue developing, and
make my own games that I can be proud of.
