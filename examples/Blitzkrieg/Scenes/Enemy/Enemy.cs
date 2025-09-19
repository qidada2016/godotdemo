using Godot;
using System;

public partial class Enemy : Node2D
{

	[Export]
	public Health Health { get; set; }

	public override void _Ready()
	{

		Health.Death += OnDeath;

	}

	public override void _Process(double delta)
	{
	}

	public void OnDeath()
	{
		QueueFree();
    }
}
