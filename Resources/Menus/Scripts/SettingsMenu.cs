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
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SettingsMenu.tscn");
	}

}