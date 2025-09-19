using Godot;
using System;

public partial class Layout : Node2D
{
    [Export]
    private float _speed = 50f;

    public override void _Process(double delta)
    {
        Position += Vector2.Down * _speed * (float)delta;
        if(Position.Y >= 320)
        {
            Position = new Vector2(Position.X, 0);
        }
    }
}
