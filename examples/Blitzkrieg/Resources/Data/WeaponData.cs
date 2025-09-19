using Godot;
using System;

[GlobalClass]
public partial class WeaponData : Resource
{
    [Export]
    public PackedScene PackedScene { get; set; }

    [Export]
    public Vector2 ShootDirection { get; set; } = Vector2.Up;

    [Export]
    public float Damage { get; set; } = 1f;

    [Export]
    public float Speed { get; set; }


    [Export]
    public string SelfTag { get; set; }
}
