using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class SaveMenu : Node2D
{   
    public override void _Ready()
    {
    }
 
	public void _on_menu_game_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Menus/Scenes/SaveMenu.tscn");
	}

	public void _on_exit_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Menus/Scenes/SettingsMenu.tscn");
	}

}