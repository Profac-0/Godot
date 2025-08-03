using Godot;
using System;

public partial class TabuleiroManager : Node
{

	// Essa matriz vai representar o tabuleiro do jogo;
	const int colunas = 5;
	const int linhas = 7;
	public int[,] tabuleiro;
	// Numero de possiveis objetos, nesse caso: semente, broto, arbusto e arvore
	const int numDePossiveisObjects = 4;
	public override void _Ready()
	{
		tabuleiro = new int[linhas, colunas];
		this.sortStartTabuleiro();
	}

	// Faz o sorteio do itens iniciais no tabuleiro
	private void sortStartTabuleiro() {
		int numDeObjects = GD.RandRange(1, 5);
		for (int i = 0; i < numDeObjects; i++)
		{
			int coordLinha = GD.RandRange(1, linhas-1);
			int coordColuna = GD.RandRange(1, colunas-1);
			// 1 semente, 2 broto, 3 arbusto e 4 arvore;
			int valor = GD.RandRange(1, numDeObjects);
			tabuleiro[coordLinha, coordColuna] = valor;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
