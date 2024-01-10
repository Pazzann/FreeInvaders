using Godot;
using System;
using System.Net.Sockets;
using FreeInvader.Scripts;

public partial class Score : Node
{
	private Label _score;
	public override void _Ready()
	{
		_score = GetChild<Label>(0);
	}

	public override void _Process(double delta)
	{
		_score.Text = GlobalState.Score.ToString();
	}
}
