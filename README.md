# Unity-TopDownShooter
A top down shooter with AI that take advantage of cover

The purpose of this project was to create a top down shooter with AI that reacted cleverly to the players movement. Many top down shooters 
have their enemies out in the open with their movement pattern set to short random bursts to make for a challenging target. Whereas 
with mine I wanted to create AI that took advantage of the objects around them. 

It proved challenging to implement the cover system of a 3D game into a 2D game. The AI can identify good and bad cover and move into 
position with but I’ve yet to implement more complex behaviours such as flanking. I used a plugin (PolyNav2D) to handle my pathfinding 
as Unitys Navmesh isn’t available in Unitys 2D mode, this proved helpful but the real issue was dealing with colliding objects on one 
plane. I’ve moved on to other projects but still keen to tackle it again. 

