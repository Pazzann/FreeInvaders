using System;
using System.Collections.Generic;
using Godot;

namespace FreeInvader.Scripts;

public partial class Main : Node2D
{
	private const float StepX = 90f;
	private const float StepY = 70f;

	private static Random Rng = new();

	private PackedScene _enemyScene, _redScene;
	private Marker2D _sRectMin, _sRectMax;

	private List<Enemy> _enemies = new();
	private int d = -1;

	private float _lastEnemyUpdate;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_redScene = GD.Load<PackedScene>("res://Prefabs/RedBonusShip.tscn");
		_enemyScene = GD.Load<PackedScene>("res://Prefabs/Enemy.tscn");
		
		_sRectMin = GetNode<Marker2D>("EnemyRectMin");
		_sRectMax = GetNode<Marker2D>("EnemyRectMax");

		
	}
	
	private void UpdateEnemies()
	{
		var minX = 99999f;
		var maxX = -99999f;
		
		foreach (var enemy in _enemies)
		{
			if (IsInstanceValid(enemy))
			{
				enemy.GlobalTranslate(d * 15f * Vector2.Right);
				enemy.Sprite.Frame = (enemy.Sprite.Frame + 1) % 2; 

				minX = Mathf.Min(enemy.GlobalPosition.X, minX);
				maxX = Mathf.Max(enemy.GlobalPosition.X, maxX);
			}
		}

		if (minX + d * 15f - 32f <= GetViewportRect().Position.X || maxX + d * 15f + 32f >= GetViewportRect().End.X)
		{
			d = -d;
			
			foreach (var enemy in _enemies)
			{
				if (IsInstanceValid(enemy))
				{
					enemy.GlobalTranslate(15f * Vector2.Down);
				}
			}
		}
		
		
	}

	public void Spawn()
	{
		var pos = _sRectMin.GlobalPosition;
		var type = 0;

		for (;pos.Y < _sRectMax.GlobalPosition.Y; pos.Y += StepY)
		{
			
			var frame = Rng.Next(2);
			
			for (;pos.X < _sRectMax.GlobalPosition.X; pos.X += StepX)
			{
				var enemy = (_enemyScene.Instantiate() as Enemy)!;
				_enemies.Add(enemy);
				enemy.GlobalPosition = pos;
				AddChild(enemy);

				if (type == 0)
					enemy.Sprite.Animation = "live3";
				else if (type is 1 or 2)
					enemy.Sprite.Animation = "live2";
				else if (type is 3 or 4 or 5)
					enemy.Sprite.Animation = "live1";

				enemy.Sprite.Frame = frame;
				GlobalState.EnemyCount++;
			}

			type++;
			
			pos.X = _sRectMin.GlobalPosition.X;
		}

		GlobalState.Live++;
		GlobalState.ResetCount++;
	}

	public override void _Process(double delta)
	{
		if(GlobalState.EnemyCount == 0)
		{
			Spawn();
		}
		if(GlobalState.Live==0){GlobalState.Live=3;GetTree().ChangeSceneToFile("res://Prefabs/GameOver.tscn");}
	}
	
	private void SpawnRed()
	{
		var ship = (_redScene.Instantiate() as RedBonusShip)!;
		ship.GlobalPosition = GetNode<Marker2D>("RedLoc").GlobalPosition;
		AddChild(ship);
	}
}
