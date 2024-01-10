using Godot;
using System;
using System.Net.Sockets;
using FreeInvader.Scripts;

public partial class Lives : Node
{
	// Called when the node enters the scene tree for the first time.
	private Sprite2D _live1;
	private Sprite2D _live2;
	private Sprite2D _live3;
	private Sprite2D _live4;
	private Sprite2D _live5;
	private Sprite2D _live6;
	private Sprite2D _live7;
	private Sprite2D _live8;
	private Sprite2D _live9;
	private Sprite2D _live10;
	private Sprite2D _live11;
	private Sprite2D _live12;
	public override void _Ready()
	{
		_live1 = GetChild<Sprite2D>(1);
		_live2 = GetChild<Sprite2D>(2);
		_live3 = GetChild<Sprite2D>(3);
		_live4 = GetChild<Sprite2D>(4);
		_live5 = GetChild<Sprite2D>(5);
		_live6 = GetChild<Sprite2D>(6);
		_live7 = GetChild<Sprite2D>(7);
		_live8 = GetChild<Sprite2D>(8);
		_live9 = GetChild<Sprite2D>(9);
		_live10 = GetChild<Sprite2D>(10);
		_live11 = GetChild<Sprite2D>(11);
		_live12 = GetChild<Sprite2D>(12);
		_live4.Visible = false;
		_live5.Visible = false;
		_live6.Visible = false;
		_live7.Visible = false;
		_live8.Visible = false;
		_live9.Visible = false;
		_live10.Visible = false;
		_live11.Visible = false;
		_live12.Visible = false;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GlobalState.Live > 0)
			_live1.Visible = true;
		else
			_live1.Visible = false;
		
		if (GlobalState.Live > 1)
			_live2.Visible = true;
		else
			_live2.Visible = false;
		
		if (GlobalState.Live > 2)
			_live3.Visible = true;
		else
			_live3.Visible = false;
		
		if (GlobalState.Live > 3)
			_live4.Visible = true;
		else
			_live4.Visible = false;
		
		if (GlobalState.Live > 4)
			_live5.Visible = true;
		else
			_live5.Visible = false;
		
		if (GlobalState.Live > 5)
			_live6.Visible = true;
		else
			_live6.Visible = false;
		
		if (GlobalState.Live > 6)
			_live7.Visible = true;
		else
			_live7.Visible = false;
		
		if (GlobalState.Live > 7)
			_live8.Visible = true;
		else
			_live8.Visible = false;
		
		if (GlobalState.Live > 8)
			_live9.Visible = true;
		else
			_live9.Visible = false;
		
		if (GlobalState.Live > 9)
			_live10.Visible = true;
		else
			_live10.Visible = false;
		
		if (GlobalState.Live > 10)
			_live11.Visible = true;
		else
			_live11.Visible = false;
		
		if (GlobalState.Live > 11)
			_live12.Visible = true;
		else
			_live12.Visible = false;
	}
}
