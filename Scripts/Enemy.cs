using System;
using Godot;

namespace FreeInvader.Scripts;

public partial class Enemy : Area2D
{
	public AnimatedSprite2D Sprite;
	
	public override void _Ready()
	{
		Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D")!;
	}

	public override void _Process(double delta)
	{
	}
	
	private void OnAreaEntered(Area2D area)
	{
		if (area is Bullet { Shooter: Player })
		{
			if(Sprite.Animation == "live1")
				GlobalState.Score += 10;
			if(Sprite.Animation == "live2")
				GlobalState.Score += 20;
			if(Sprite.Animation == "live3")
				GlobalState.Score += 40;
		}

		area.QueueFree();
		
		Sprite.Animation = "explode";
		GetTree().CreateTimer(0.2f).Timeout += QueueFree;
	}
}



