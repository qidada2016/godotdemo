using Godot;
using System;

public partial class Gem : Area2D
{

	const double Min_Speed = 150;
	const double Max_Speed = 180;

	public double Speed { get; set; } = 150;

	[Signal]
	public delegate void OnScoredEventHandler();
	[Signal]
	public delegate void OnHitBottomEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
		Speed = GD.RandRange(Min_Speed, Max_Speed);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		Position += new Vector2(0, (float)(Speed * delta));

		CheckHitBootom();
	}

	private void CheckHitBootom()
	{
		if (Position.Y > GetViewportRect().End.Y)
		{
			EmitSignal(SignalName.OnHitBottom);
			SetProcess(false);
			QueueFree();
		}
	}

	private void OnAreaEntered(Area2D area)
	{

		// if (area is Paddle)
		// {
		// }
		EmitSignal(SignalName.OnScored);
		QueueFree();
	}
}
