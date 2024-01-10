using Godot;

namespace FreeInvader.Scripts;

public partial class Player : Area2D
{
	private const float MovementSpeed = 400f;

	private PackedScene _bulletScene;
	private Marker2D _bulletSpawnPos;
	
	public override void _Ready()
	{
		_bulletScene = GD.Load<PackedScene>("res://Prefabs/Bullet.tscn");
		_bulletSpawnPos = GetNode<Marker2D>("BulletSpawnPos")!;
	}

	public override void _Process(double delta)
	{
		var deltaF = (float)delta;
		
		if (Input.IsActionPressed("move_left"))
			GlobalTranslate(Vector2.Left * MovementSpeed * GlobalState.SpeedScale * deltaF);
		
		if (Input.IsActionPressed("move_right"))
			GlobalTranslate(Vector2.Right * MovementSpeed * GlobalState.SpeedScale * deltaF);
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (@event.IsActionPressed("shoot"))
		{
			var bullet = (_bulletScene.Instantiate() as Bullet)!;
			bullet.GlobalPosition = _bulletSpawnPos.GlobalPosition;
			GetParent().AddChild(bullet);
		}
	}
}
