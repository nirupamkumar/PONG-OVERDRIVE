# Project-PONG

3D mini game that resembles Pong. Two players are playing on one machine, every player controls his “Paddle”.
The game have powerups and changes level on each run.
-------
> For ball implmentation I'm using logic and math not Physics Rigidbody.
-------
**Powerups:**
Powerups are objects that should generate on the level.  If the ball touches the powerup, the player takes it and the ball continues its trajectory. The last player that hit the ball takes the powerup 
- Slow down opponent 
- Over Speed up opponent 
- Sinusoid ball movement when traveling to the opponent 
- Freeze player 
- Blockers (objects that generate on the level. They are spawned occasionally and are destroyed when the ball hits them. When the ball destroys it, it changes the direction from where it came.)
