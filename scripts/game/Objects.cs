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
	public override void _Ready()
	{
		stages = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		tabuleiroManager = GetNode<TabuleiroManager>("/root/TabuleiroManager");
		setType();
		tabuleiroManager.setType += setType;
	}
	public void setType()
	{
		stages.Frame = tabuleiroManager.tabuleiro[linha, coluna];
	}
	private void _OnObjectPressed()
	{
		if (tabuleiroManager.tabuleiro[linha, coluna] != 0) return;
		stages.Frame += tabuleiroManager.emUso;
		tabuleiroManager.tabuleiro[linha, coluna] = stages.Frame;
		tabuleiroManager.tryJoinElements(linha, coluna);

		EmitSignal(SignalName.PutObject, linha, coluna);
		GD.Print("Cliquei em Object");
	}

}



