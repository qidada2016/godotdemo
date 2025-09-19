using Godot;
using System;

public partial class EnemyManager : Node
{

    [Export]
    public PackedScene EnemyScene;

    [Export]
    public float SpawnRate { get; set; }

    private float _accumulatedTime = 0f;

    public override void _Ready()
    {
        SpawnRate = (float)GD.RandRange(0.5, 1.5);
    }

    public override void _Process(double delta)
    {

        _accumulatedTime += (float)delta;

        if (_accumulatedTime >= SpawnRate)
        {

            var enemy = EnemyScene.Instantiate<Enemy>();
            GetTree().Root.AddChild(enemy);
            var x = enemy.GetViewportRect().End.X;
            enemy.Position = new Vector2((float)GD.RandRange(x / 4, x * 3 / 4), -50f);

            _accumulatedTime -= SpawnRate;

        }

    }
}
