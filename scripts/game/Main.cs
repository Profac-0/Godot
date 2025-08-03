using Godot;
using System;


public partial class Main : Node2D
{
	Node2D player;
	Button botaoA,botaoB,botaoC,botaoD;
	Vector2 mouse;
	bool over = false;



	public override void _Ready(){
		player=GetNode<Node2D>("mob");
	}

	public void _on_colisao_pressed()
	{
		GD.Print("Shangri-la");
		over = true;
	}

	public void _on_colisao_released(){
		GD.Print("Boruto");
		over = false;
	}

	public void drag_on(){
		Transform2D position = Transform2D.Identity;
		position.Origin = GetGlobalMousePosition();
		player.Transform = position;
	}




	 /*public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
			{
				GD.Print("Dr.stone");
			}
		}
	}*/


	public override void _Process(double delta)
	{
		if(over == true){
			drag_on();
		}
	}
	
}
