using Godot;
using System;

public partial class HitBox : Area2D
{
    [Signal]
    public delegate void DestroyEventHandler();

    public string Tag { get; set; }

    public override void _Ready()
    {
        Destroy += OnDestroy;
    }

    private void OnDestroy()
    {
        GetParent().QueueFree();
    }
}
