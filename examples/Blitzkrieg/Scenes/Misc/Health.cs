using Godot;
using System;

public partial class Health : Node
{
    [Signal]
    public delegate void DeathEventHandler();

    [Export]
    private float _health = 1f;

    [Export]
    private HurtBox _hurtBox;

    public override void _Ready()
    {
        if (_hurtBox != null)
        {
            _hurtBox.OnHurt += OnHurt;
        }
    }
    private void OnHurt(HitBox area)
    {

        var bullet = area.GetParentOrNull<Bullet>();
        if (bullet == null)
        {
            return;
        }
        _health -= bullet.Damage;
        if (_health <= 0)
        {
            var parent = GetParentOrNull<Node>();
            if (parent != null)
            {
                EmitSignal(SignalName.Death);
            }
        }
    }
}
