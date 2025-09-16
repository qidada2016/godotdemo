using Godot;
using System;
using System.ComponentModel;

public partial class Game : Node2D
{

	const double Gem_Margin = 50;
	const double Gen_Min_Time = 0.5;
	const double Gen_Max_Time = 1.5;
	const string Game_Over_Ani_Name = "gameover";

	// [Export]
	// private Gem _gem;

	[Export]
	private PackedScene _gemScene;

	[Export]
	private Timer _spawnTimer;

	[Export]
	private Label _scoreLabel;

	[Export]
	private AudioStreamPlayer _bgm;

	[Export]
	private AudioStreamPlayer _gameOverEffect;

	[Export]
	private AudioStreamPlayer2D _effect;

	[Export]
	private AnimationPlayer _ani;

	[Export]
	private Button _restartBtn;

	private int _score = 0;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// var g = GetNode<Gem>("Gem"); // 不推荐硬编码
		// _gem.OnScored += OnScored;

		SpawnGem();
		_spawnTimer.Timeout += SpawnGem;
		_spawnTimer.WaitTime = GD.RandRange(Gen_Min_Time, Gen_Max_Time);

		_restartBtn.Pressed += RestartGame;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void RestartGame()
	{
		GetTree().ReloadCurrentScene();
	}

	private void SpawnGem()
	{
		Gem gem = (Gem)_gemScene.Instantiate();
		AddChild(gem);

		float rx = (float)GD.RandRange(GetViewportRect().Position.X + Gem_Margin, GetViewportRect().End.X - Gem_Margin);
		gem.Position = new Vector2(rx, -100);

		gem.OnScored += OnScored;
		gem.OnHitBottom += GameOver;
	}

	private void OnScored()
	{
		_score += 1;
		_scoreLabel.Text = $"得分: {_score}";
		_effect.Play();

		// GD.Print($"!! {_score}");
	}

	private void GameOver()
	{
		GD.Print("Game Over");
		foreach (var node in GetChildren())
		{
			node.SetProcess(false);
		}
		_spawnTimer.Stop();
		_bgm.Stop();
		_gameOverEffect.Play();
		_ani.Play(Game_Over_Ani_Name);
	}
}
