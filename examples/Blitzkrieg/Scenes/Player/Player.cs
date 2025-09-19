using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export]
    public float Speed { get; set; } = 300f;

    [Export]
    public Health Health { get; set; }


    public override void _Ready()
    {
        Health.Death += OnDeath;
        
    }

    public override void _Process(double delta)
    {
        Movement(delta);
    }

    private void Movement(double delta)
    {
        var inputDir = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDir.Normalized() * Speed;
        MoveAndSlide();
    }

    private void OnDeath()
    {
        QueueFree();
        GameManager.Instance.EmitSignal(nameof(GameManager.GameOver));

    }
}
