using Godot;
using System;

public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var Color = GetNode<ColorRect>;
		if(Input.IsActionJustPressed("leave")){GetTree().Quit();}
		
	}
	private void Play()
{
	GetTree().ChangeSceneToFile("res://Prefabs/Main.tscn");
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

