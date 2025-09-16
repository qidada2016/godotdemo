using Godot;
using System;

public partial class InfiniteBg : Node2D
{

	[Export]
	private float Speed = 100f;
	[Export]
	private Sprite2D _sp1;
	[Export]
	private Sprite2D _sp2;

	private Vector2 _sp1Origin;
	private Vector2 _sp2Origin;
	private float len = 810;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sp1Origin = _sp1.Position;
		_sp2Origin = _sp2.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		_sp1.Position -= new Vector2(0, Speed * (float)delta);
		_sp2.Position -= new Vector2(0, Speed * (float)delta);

		if (_sp1.Position.Y <= _sp1Origin.Y - len)
		{
			_sp1.Position = _sp1Origin;
		}

		if (_sp2.Position.Y <= _sp2Origin.Y - len)
		{
			_sp2.Position = _sp2Origin;
		}

	}
}
