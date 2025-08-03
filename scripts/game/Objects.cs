using Godot;
using System;

public partial class Objects : Node2D
{
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
		stages.Frame = tabuleiroManager.tabuleiro[linha, coluna];
	}
	private void _OnObjectPressed()
	{
		stages.Frame += 1;
		tabuleiroManager.tabuleiro[linha, coluna] = stages.Frame; 
		GD.Print("Cliquei em Object");
	}

}



