using Godot;

namespace FreeInvader.Scripts;

public partial class Boss : Area2D
{
	private AnimatedSprite2D _sprite;
	private bool _first = true;

	private Vector2 _d = new Vector2(1f, -1f); 
	
	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		_sprite.Animation = "appear";

		_sprite.AnimationLooped += () =>
		{
			if (_first)
			{
				_first = false;
				_sprite.Animation = "fight";
			}
		};
		
		_sprite.Play();
	}

	public override void _Process(double delta)
	{
		if (_first)
			return;
		
		GlobalTranslate(300f * _d * (float) delta);

		if (GlobalPosition.X > GetViewportRect().End.X || GlobalPosition.X < GetViewportRect().Position.X)
			_d.X = -_d.X;
		
		if (GlobalPosition.Y > GetViewportRect().End.Y || GlobalPosition.Y < GetViewportRect().Position.Y)
			_d.Y = -_d.Y;
	}
	
	private void OnAreaEntered(Area2D area)
	{
		if (area is Bullet { Shooter: Player })
		{
			GlobalState.Score += 1000;
		}
		
		area.QueueFree();
		
		_sprite.Animation = "explode";
		GetTree().CreateTimer(0.2f).Timeout += QueueFree;
	}

}
