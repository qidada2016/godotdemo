using Godot;
using System;

public partial class Bullet : Node2D
{

    [Export]
    public HitBox HitBox;

    public float Damage { get; set; }

    public Vector2 Velocity { get; set; } = Vector2.Zero;


    public override void _Process(double delta)
    {
        Position += Velocity * (float)delta;

        if (!GetViewportRect().HasPoint(Position))
        {
            SetProcess(false);
            QueueFree();
        }
    }

    public void SetTag(string tag)
    {
        if (HitBox == null)
        {

            GD.PrintErr("Bullet : HitBox is not null");
            return;
        }

        HitBox.Tag = tag;
    }
}
