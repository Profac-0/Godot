using Godot;
using System;
using System.Collections.Generic;

// Muitos erros na Classe então comentei para resoler mais tarde
public partial class Node2d : Node2D
{
	// Node2D player;
	// Button botaoA,botaoB,botaoC,botaoD;
	// int boardX;
	// int boardY;
	// bool over = false;
	// Random rnd = new Random();	

	// public void spawn()
	// {



	// 	for (boardX = 0; boardX < 8; boardX++)
	// 	{


	// 		for (boardY = 0; boardY < 8; boardY++)
	// 		{
	// 			int tester = rnd.Next(1, 10);
	// 			int ved = 74;
	// 			int hod = 76;
	// 			int ver = 580;
	// 			int hor = 310;

	// 			if (tester == 1)
	// 			{

	// 				PackedScene plantsScene = GD.Load<PackedScene>("res://objects.tscn");
	// 				Node2D[] plant = {};
	// 				plant[boardY] = plantsScene.Instantiate<Node2D>();
	// 				GetNode("plants").AddChild(plant[boardY]);





	// 				Transform2D position = Transform2D.Identity;
	// 				position.Origin = new Vector2(hor, ver);
	// 				plant[boardY].Transform = position;



	// 			}

	// 			ver = ver + ved;

	// 		}
	// 	}



	// }


	// public override void _Ready()
	// {
	// 	player = GetNode<Node2D>("mob");
	// 	spawn();
	// 	GD.Print(rnd.Next(0,10));

	// }

	// public void _on_colisao_pressed(){
	// 	GD.Print("Shangri-la");
	// 	over = true;
	// }

	// public void _on_colisao_released(){
	// 	GD.Print("Boruto");
	// 	over = false;
	// }

	// public void drag_on(){
	// 	Transform2D position = Transform2D.Identity;
	// 	position.Origin = GetGlobalMousePosition();
	// 	player.Transform = position;
	// }




	//  /*public override void _Input(InputEvent @event)
	// {
	//     if (@event is InputEventMouseButton mouseButton)
	//     {
	//         if (mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
	//         {
	//             GD.Print("Dr.stone");
	//         }
	//     }
	// }*/


	// public override void _Process(double delta)
	// {
	// 	if(over == true){
	// 		drag_on();
	// 	}
	// }

}
