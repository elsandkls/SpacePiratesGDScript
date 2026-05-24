using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class MainMenu : Node2D
{   
    public override void _Ready()
    {
    }

	public void _on_start_game_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/SolarSystems/Scenes/SolarSystem.tscn");
	}
	public void _on_ship_builder_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/ShipBuilder/Scenes/ShipBuilder.tscn");
	}
	public void _on_save_game_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SaveMenu.tscn");
	}
	public void _on_settings_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Resources/Menus/Scenes/SettingsMenu.tscn");
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