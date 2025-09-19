using Godot;
using System;

public partial class Movement : Node
{

	[Export]
	public float Speed { get; set; } = 80f;

	private Node2D _parent;
	private Vector2 _dir;

	public override void _Ready()
	{
		_parent = GetParent<Node2D>();

		// 第一版 直线
		_dir = new Vector2(0, 1);
	}

	public override void _Process(double delta)
	{
		_parent.Position += _dir * Speed * (float)delta;

        if (_parent.GetViewportRect().End.Y < _parent.Position.Y)
        {
            _parent.SetProcess(false);
            _parent.QueueFree();
        }
    }
}
