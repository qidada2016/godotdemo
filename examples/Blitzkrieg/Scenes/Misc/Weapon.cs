using Godot;
using System;

public partial class Weapon : Node
{
    [Export]
    public WeaponData WeaponData { get; set; }

    [Export]
    public bool CanShoot { get; set; } = true;

    [Export]
    public float FireRate { get; set; } = 0.5f;


    private float _accumulatedTime = 0f;
    private Node2D _parent;


    public override void _Ready()
    {
        _parent = GetParentOrNull<Node2D>();

        if (!CanShoot)
        {
            SetProcess(false);
        }
    }

    public override void _Process(double delta)
    {
        _accumulatedTime += (float)delta;

        if (_accumulatedTime >= FireRate)
        {
            if (WeaponData.PackedScene != null)
            {
                var bullet = (Bullet)WeaponData.PackedScene.Instantiate();
                bullet.Velocity = WeaponData.ShootDirection * WeaponData.Speed;
                bullet.GlobalPosition = _parent.GlobalPosition;
                bullet.Damage = WeaponData.Damage;
                bullet.SetTag(WeaponData.SelfTag);
                GetTree().Root.AddChild(bullet);

            }

            _accumulatedTime -= FireRate;
        }
    }
}
