using Godot;
using System;
using FreeInvader.Scripts;

public partial class RedBonusShip : Area2D
{
	private static Random Rng = new Random();
	private AnimatedSprite2D _sprite;
	private Timer _timer;
	private Label _label;

	private int _timesBlinked = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite = GetChild<AnimatedSprite2D>(0);
		_label = GetChild<Label>(2);
		_timer = GetChild<Timer>(3);
		_label.Visible = false;
	}

	public override void _Process(double delta)
	{
		if(_sprite.Visible)
			Position = new Vector2(Position.X + 300f * (float)delta, Position.Y);
	}


	private void OnAreaEntered(Area2D area)
	{
		var points = Rng.Next(50, 300);

		_label.Text = points.ToString();
		GlobalState.AddScore(points);
		_timer.Start();
		_sprite.Visible = false;
	
	}
	
	private void _on_timer_timeout()
	{
		_timesBlinked++;
		_label.Visible = !_label.Visible;
		if(_timesBlinked >5)
			GetTree().CreateTimer(0.5f).Timeout += QueueFree;
	}

}




