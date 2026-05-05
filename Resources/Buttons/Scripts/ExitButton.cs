using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class ExitButton : Node2D
{   
    public override void _Ready()
    {
    }

	public void _on_exit_game_button_pressed()
	{
		GetTree().Quit();
	} 

}