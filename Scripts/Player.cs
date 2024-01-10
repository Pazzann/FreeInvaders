using Godot;

namespace FreeInvader.Scripts;

public partial class Player : Area2D
{
	private const float MovementSpeed = 400f;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		var deltaF = (float)delta;
		
		if (Input.IsActionPressed("move_left"))
			GlobalTranslate(Vector2.Left * MovementSpeed * GlobalState.SpeedScale * deltaF);
		
		if (Input.IsActionPressed("move_right"))
			GlobalTranslate(Vector2.Right * MovementSpeed * GlobalState.SpeedScale * deltaF);
	}
}
