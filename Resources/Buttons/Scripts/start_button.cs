using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class StartButton : Node2D
{   
    public override void _Ready()
    {
    }

	public void _on_start_game_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://SolarSystems/Scenes/SolarSystem_00.tscn");
	} 

}