using Godot;
using FreeInvader.Scripts;

public partial class Bullet : Area2D
{
	public AnimatedSprite2D _sprites;
	public int Speed = -600;

	public Node2D Shooter { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprites = GetChild<AnimatedSprite2D>(0);
		if (_sprites.Frame is 1 or 2)
			Speed *= -1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + (float)(Speed * GlobalState.SpeedScale * delta));
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


