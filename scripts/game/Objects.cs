using Godot;
using System;

public partial class Objects : Node2D
{
	[Signal]
	public delegate void PutObjectEventHandler(int x, int y);
	private AnimatedSprite2D stages;
	// Called when the node enters the scene tree for the first time.
	[Export]
	public int linha { get; set; }
	[Export]
	public int coluna{ get; set; }
	TabuleiroManager tabuleiroManager;
	// vaariaveis para as animações de codigo
	private Vector2 initialGlobalPosition;
	private Vector2 positionToEvolve;
	private bool goToEvolvePosition = false;
	private Timer goToEvolvePositionTimer;
	public override void _Ready()
	{
		stages = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		tabuleiroManager = GetNode<TabuleiroManager>("/root/TabuleiroManager");
		setType(GlobalPosition, false, 0);
		tabuleiroManager.setType += setType;
		// Usar essas variaveis para fazer as possiveis animações de movimento
		// dos espaços
		initialGlobalPosition = GlobalPosition;
		positionToEvolve = initialGlobalPosition;
		goToEvolvePositionTimer = GetNode<Timer>("GoToEvolve");
	}
	public void setType(Vector2 clickedGlobalPosition, bool evolveAObject, int clickValue)
	{
		if (evolveAObject && clickedGlobalPosition == initialGlobalPosition)
		{
			// espera os elementos chegar ate ele
			goToEvolvePositionTimer.Start();
			// Coloca o valor do clique
			stages.Frame = clickValue;
			return;
		}
		if (tabuleiroManager.tabuleiro[linha, coluna] == -1 && evolveAObject)
		{
			positionToEvolve = clickedGlobalPosition;
			tabuleiroManager.tabuleiro[linha, coluna] = 0;
			goToEvolvePosition = true;
			goToEvolvePositionTimer.Start();
			return;
		}
		stages.Frame = tabuleiroManager.tabuleiro[linha, coluna];	
	}

	public void onGoToEvolveTimeout()
	{
		positionToEvolve = initialGlobalPosition;
		GlobalPosition = initialGlobalPosition;
		goToEvolvePosition = false;
		stages.Frame = tabuleiroManager.tabuleiro[linha, coluna];
	}
    public override void _Process(double delta)
	{
		if (goToEvolvePosition)
		{
			Vector2 distance = (positionToEvolve - GlobalPosition);
			Position += (5 * Math.Max(Math.Abs(distance.X), Math.Abs(distance.Y))) * (float)(delta) * distance.Normalized();
		}
	}

	private void _OnObjectPressed()
	{
		if (tabuleiroManager.tabuleiro[linha, coluna] != 0) return;
		tabuleiroManager.tryJoinElements(linha, coluna, GlobalPosition);

		EmitSignal(SignalName.PutObject, linha, coluna);
		GD.Print("coloquei um Object");
	}

}



