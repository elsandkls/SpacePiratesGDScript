using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class MainMenuButton : Node2D
{   
    public override void _Ready()
    {
    }

	public void _on_texture_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Menus/Scenes/MainMenu.tscn");
	} 

}