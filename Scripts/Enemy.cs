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
			GlobalState.Score += 10;
		}

		area.QueueFree();
		
		Sprite.Animation = "explode";
		GetTree().CreateTimer(0.2f).Timeout += QueueFree;
	}
}



