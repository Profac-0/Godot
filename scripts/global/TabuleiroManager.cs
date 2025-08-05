using Godot;
using System;
using System.Collections.Generic;

public partial class TabuleiroManager : Node
{
	[Signal]
	public delegate void setTypeEventHandler();
	// Essa matriz vai representar o tabuleiro do jogo;
	const int colunas = 4;
	const int linhas = 5;
	public int[,] tabuleiro;
	// valores do click 
	public AnimatedSprite2D emUsoSprite;
	public AnimatedSprite2D proximoSprite;
	public int emUso;
	public int proximo;
	// Numero de possiveis objetos, nesse caso: semente, broto, arbusto e arvore
	const int numDePossiveisObjects = 4;
	public override void _Ready()
	{
		tabuleiro = new int[linhas, colunas];
		sortStartTabuleiro();
		emUso = GD.RandRange(1, numDePossiveisObjects);
		proximo = GD.RandRange(1, numDePossiveisObjects);
		// Pega os sprites do emUso e proximo no tabuleiro
		emUsoSprite = GetNode<AnimatedSprite2D>("/root/Main/EmUso/AnimatedSprite2D");
		proximoSprite = GetNode<AnimatedSprite2D>("/root/Main/Proximo/AnimatedSprite2D");
		//Seta os sprites para o valor sorteado
		proximoSprite.Frame = proximo;
		emUsoSprite.Frame = emUso;
	}

	public void tryJoinElements(int x, int y)
	{
		List<Vector2I> adjacents;
		do
		{
			nextObjectToUse();
			int antigoVal = tabuleiro[x, y];
			adjacents = searchForEquals(x, y, antigoVal);
			if (adjacents.Count >= 3)
			{
				foreach (Vector2I position in adjacents)
				{
					tabuleiro[position.X, position.Y] = 0;
				}
				tabuleiro[x, y] = Math.Min(antigoVal + 1, numDePossiveisObjects);
				EmitSignal(SignalName.setType);
			}
		} while (adjacents.Count >= 3);
		
		
	}

	private List<Vector2I> searchForEquals(int x, int y, int target)
	{
		var adjacents = new List<Vector2I>();
		var visiteds = new bool[linhas, colunas];

		// Fazer uma fila para ir acessando os elementos adjacentes
		Queue<Vector2I> queue = new Queue<Vector2I>();
		queue.Enqueue(new Vector2I(x, y));
		visiteds[x, y] = true;
		//Possiveis direções para procurar
		int[] dx = { 0, 1, 0, -1 };
		int[] dy = { -1, 0, 1, 0 };
		// Enquanto tem elementos na lista
		while (queue.Count > 0)
		{
			Vector2I pos = queue.Dequeue();
			adjacents.Add(pos);

			for (int dir = 0; dir < 4; dir++)
			{
				int nx = pos.X + dx[dir];
				int ny = pos.Y + dy[dir];

				if (ny >= 0 && ny < colunas && nx >= 0 && nx < linhas)
				{
					if (!visiteds[nx, ny] && tabuleiro[nx, ny] == target)
					{
						queue.Enqueue(new Vector2I(nx, ny));
						visiteds[nx, ny] = true;
					}
				}
			}
		}
		return adjacents;
	}

	private void nextObjectToUse()
	{
		emUso = proximo;
		proximo = GD.RandRange(1, numDePossiveisObjects);
		// Seta os valores no painel do tabuleiro
		proximoSprite.Frame = proximo;
		emUsoSprite.Frame = emUso;
	}
	// Faz o sorteio do itens iniciais no tabuleiro
	private void sortStartTabuleiro()
	{
		int numDeObjectsIniciais = GD.RandRange(1, 5);
		for (int i = 0; i < numDeObjectsIniciais; i++)
		{
			int coordLinha = GD.RandRange(1, linhas - 1);
			int coordColuna = GD.RandRange(1, colunas - 1);
			// 1 semente, 2 broto, 3 arbusto e 4 arvore;
			int valor = GD.RandRange(1, numDePossiveisObjects);
			tabuleiro[coordLinha, coordColuna] = valor;
		}
	}

	
}
