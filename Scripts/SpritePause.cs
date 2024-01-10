using Godot;
using System;

public partial class SpritePause : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("pause"))
		{
			if(GetTree().Paused == false) 
			{
				GetTree().Paused=true;
				Show();
			}
			else
			{
				GetTree().Paused = false;
				Hide();
			}
		}
	}
}
