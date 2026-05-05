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
		GetTree().ChangeSceneToFile("res://Resources/SolarSystems/Scenes/SolarSystem_00.tscn");
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

}