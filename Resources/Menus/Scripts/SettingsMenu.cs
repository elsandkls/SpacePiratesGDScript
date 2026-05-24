using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class SettingsMenu : Node2D
{   
    public override void _Ready()
    {
    }
 
	public void _on_check_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SaveMenu.tscn");
	}
	public void _on_check_button_toggled()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SaveMenu.tscn");
	}
	public void _on_option_button_item_selected()
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