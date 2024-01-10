using Godot;

namespace FreeInvader.Scripts;

public partial class Enemy : Area2D
{
	private AnimatedSprite2D _sprite;
	
	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D")!;
	}

	public override void _Process(double delta)
	{
	}
	
	private void OnAreaEntered(Area2D area)
	{
		area.QueueFree();
		
		_sprite.Animation = "explode";
		GetTree().CreateTimer(0.05f).Timeout += QueueFree;
	}
}



