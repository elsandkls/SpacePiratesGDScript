using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class SpaceStation : Node2D
{   
    private string ClassName = "SpaceStation"; 
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }

    }

    
    public override void _Process(double delta)
    {  
        string func_name = "_Process";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }

    }
 

}