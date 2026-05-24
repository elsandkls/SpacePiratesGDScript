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
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SaveMenu.tscn");
	}

	public void _on_exit_button_pressed()
	{
		GetTree().Quit();
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent &&
			keyEvent.Pressed &&
			keyEvent.Keycode == Key.Escape)
		{
			GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/MainMenu.tscn");
		}
	}

}