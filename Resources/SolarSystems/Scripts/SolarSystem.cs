using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class SolarSystem : Node2D
{   
    public override void _Ready()
    {
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