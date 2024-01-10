using Godot;
using FreeInvader.Scripts;

public partial class Bullet : Area2D
{
	private AnimatedSprite2D _sprites;
	private int _speed = -600;

	public Node2D Shooter { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprites = GetChild<AnimatedSprite2D>(0);
		if (_sprites.Frame is 1 or 2)
			_speed *= -1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + (float)(_speed * GlobalState.SpeedScale * delta));
	}
	private void OnTimerTimeout()
	{
		if (Rotation < 3.0f)
		{
			Rotation = Mathf.Pi;
			return;
		} 
		Rotation = 0;
	}
}


