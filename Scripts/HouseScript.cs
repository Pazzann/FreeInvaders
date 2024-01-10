using Godot;
using System;

public partial class HouseScript : Node
{
	public AnimatedSprite2D HouseSprites;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		HouseSprites = GetChild<AnimatedSprite2D>(0);
	}
	
	private void OnAreaEntered(Area2D area)
	{
		area.QueueFree();
		if(HouseSprites.Frame == 3)
			QueueFree();
		
		HouseSprites.Frame++;
	}
}



