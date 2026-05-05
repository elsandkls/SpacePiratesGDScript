using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class StartMenu : Node2D
{   
    public override void _Ready()
    {
    }
 
	public void _start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/MainMenu.tscn");
	}
 
	public void _on_exit_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SettingsMenu.tscn");
	}

}