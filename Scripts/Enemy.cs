using System;
using Godot;

namespace FreeInvader.Scripts;

public partial class Enemy : Area2D
{
	private static Random Rng = new Random();
	
	private PackedScene _bulletScene;
	public AnimatedSprite2D Sprite;
	private Marker2D _bulletPos;
	private Timer _bulletSpawnTimer;
	
	public override void _Ready()
	{
		_bulletScene = GD.Load<PackedScene>("res://Prefabs/Bullet.tscn");
		
		Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D")!;
		_bulletPos = GetNode<Marker2D>("BulletSpawnPos")!;
		_bulletSpawnTimer = GetNode<Timer>("BulletSpawnTimer")!;

		var off = Rng.NextSingle() * 100f;
		
		GetTree().CreateTimer(off).Timeout += () =>
		{
			ShootBullet();
			_bulletSpawnTimer.Start(100f);
		};
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
	
	private void ShootBullet()
	{
		_bulletSpawnTimer.Start(10f);
		
		var bullet = (_bulletScene.Instantiate() as Bullet)!;
		bullet.Shooter = this;
		bullet.CollisionLayer = bullet.CollisionMask = 2;
		bullet.Speed = -bullet.Speed;
			
		bullet.GlobalPosition = _bulletPos.GlobalPosition;
		GetParent().AddChild(bullet);
	}

}
