using Godot;
using System;

public partial class GameControl : Control
{

    [Export]
    public Button RestartGameBtn;

    private Player _player;

    [Export]
    private PackedScene _playerScene;
    private bool _playerIsInPosition;

    public override void _Ready()
    {
        Visible = false;
        GameManager.Instance.GameOver += OnGameOver;

        RestartGameBtn.Pressed += OnRestartGame;


        var timer = GetNode<Timer>("Timer");

        timer.Timeout += CreatePlayer;

    }

    public override void _Process(double delta)
    {
        if (_player == null)
        {
            return;
        }

        if (!_playerIsInPosition)
        {
            _player.Position += new Vector2(0, Vector2.Up.Y * 300f * (float)delta);

            if (_player.Position.Y <= 270)
            {
                _playerIsInPosition = true;
            }
        }
    }

    private void CreatePlayer()
    {
        _playerIsInPosition = false;
        _player = _playerScene.Instantiate<Player>();
        _player.Position = new Vector2(288, 350);
        GetTree().Root.AddChild(_player);
    }


    private void OnGameOver()
    {
        Visible = true;
    }
    private void OnRestartGame()
    {
        Visible = false;
        GameManager.Instance.EmitSignal(nameof(GameManager.Instance.GameStart));
        CreatePlayer();
    }
}
