using Godot;
using System;

[GlobalClass]
public partial class GameManager : Node
{
    [Signal]
    public delegate void GameOverEventHandler();

    [Signal]
    public delegate void GameStartEventHandler();

    public static GameManager Instance { get; private set; }



    public override void _Ready()
    {

        GameOver += OnGameOver;
        GameStart += OnGameStart;
        Instance = this;

    }

    public override void _Process(double delta)
    {
        
    }

    private void OnGameOver()
    {

        GetTree().Paused = true;
    }

    private void OnGameStart()
    {
        GetTree().Paused = false;
    }
}
