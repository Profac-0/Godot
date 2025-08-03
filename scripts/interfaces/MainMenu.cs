using Godot;
using System;

public partial class MainMenu : Control
{

	Button start;
	Button exit;
	public PackedScene start_level = GD.Load<PackedScene>("res://scenes/main.tscn");



	public override void _Ready()
	{
	}

	public void _on_start_button_pressed(){
		GD.Print("Wotakoi");
		GetTree().ChangeSceneToPacked(start_level);
	}
	public void _on_exit_button_pressed(){
		GD.Print("Romantic Killer");
		GetTree().Quit();
	}

}

