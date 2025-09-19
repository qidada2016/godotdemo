using Godot;
using System;

public partial class HurtBox : Area2D
{

    [Signal]
    public delegate void OnHurtEventHandler(HitBox area);

    [Export]
    public string DetectionTag { get; set; }

    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is HitBox)
        {

            var hitBox = (HitBox)area;

            if (!string.IsNullOrEmpty(DetectionTag) && hitBox.Tag == DetectionTag)
            {
                EmitSignal(SignalName.OnHurt, area);

                hitBox.EmitSignal(nameof(hitBox.Destroy));
            }

        }

    }

}
