using Godot;

namespace FreeInvader.Scripts;

public partial class Player : Area2D
{
	private const float MovementSpeed = 400f;
	private const float DelayBetweenShots = 0.5f;
	
	private PackedScene _bulletScene;
	private Marker2D _bulletSpawnPos;
	private AnimatedSprite2D _sprite;

	private float _lastShotTime = 0f;
	
	public override void _Ready()
	{
		_bulletScene = GD.Load<PackedScene>("res://Prefabs/Bullet.tscn");
		_bulletSpawnPos = GetNode<Marker2D>("BulletSpawnPos")!;
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D")!;
	}

	public override void _Process(double delta)
	{
		var deltaF = (float)delta;
		
		if (Input.IsActionPressed("move_left"))
			GlobalTranslate(Vector2.Left * MovementSpeed * GlobalState.SpeedScale * deltaF);
		
		if (Input.IsActionPressed("move_right"))
			GlobalTranslate(Vector2.Right * MovementSpeed * GlobalState.SpeedScale * deltaF);

		GlobalPosition = GlobalPosition.Clamp(GetViewportRect().Position + new Vector2(37.5f, 19f), GetViewportRect().End - new Vector2(37.5f, 19f));
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		var curTime = Time.GetTicksMsec() / 1000f;

		if (@event.IsActionPressed("shoot") && curTime - _lastShotTime >= DelayBetweenShots)
		{
			_lastShotTime = curTime;
			
			var bullet = (_bulletScene.Instantiate() as Bullet)!;
			bullet.Shooter = this;
			
			bullet.GlobalPosition = _bulletSpawnPos.GlobalPosition;
			GetParent().AddChild(bullet);
		}
	}
	
	private void OnAreaEntered(Area2D area)
	{
		if (area is Bullet)
			area.QueueFree();

		GlobalState.ReduceLive();

		var callback = () =>
		{
			_sprite.Animation = "default";
			_sprite.Stop();
			GlobalPosition = GlobalPosition with { X = GetViewportRect().GetCenter().X };
			
			if (GlobalState.Live == 0)
				QueueFree();
		};

		if (!_sprite.IsConnected(AnimatedSprite2D.SignalName.AnimationLooped, Callable.From(callback)))
			_sprite.AnimationLooped += callback;

		if (GlobalState.Live == 0)
		{
			_sprite.Animation = "explode";
			_sprite.Play();
		}
		else
		{
			_sprite.Animation = "explode";
			_sprite.Play();
		}
	}

}
