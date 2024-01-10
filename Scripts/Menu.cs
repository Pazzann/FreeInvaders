using Godot;
using System;
using FreeInvader.Scripts;

public partial class Menu : Control
{
	private PackedScene main;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main = GD.Load<PackedScene>("res://Prefabs/Main.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var Color = GetNode<ColorRect>;
		if(Input.IsActionJustPressed("leave")){GetTree().Quit();}
		
	}
	private void Play()
	{
		GlobalState.Score = 0;
		GlobalState.EnemyCount = 0;
		GlobalState.ResetCount = 0;
		GetTree().ChangeSceneToPacked(main);
	}

private void Exit()
{
	GetTree().Quit();
}

void GameOver()
{
	GetTree().ChangeSceneToFile("res://Prefabs/GameOver.tscn");
}
}

