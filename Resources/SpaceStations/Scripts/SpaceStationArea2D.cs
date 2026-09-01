using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class SpaceStationArea2D : Area2D
{    
    private string ClassName = "SpaceStationArea2D"; 
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
          
        CollisionShape2D CollisionShape2D_1 = (CollisionShape2D)GetNode("CollisionShape2D_1"); 
        CollisionShape2D CollisionShape2D_2 = (CollisionShape2D)GetNode("CollisionShape2D_2");   
        CollisionShape2D CollisionShape2D_3 = (CollisionShape2D)GetNode("CollisionShape2D_3");  
        CollisionShape2D CollisionShape2D_4 = (CollisionShape2D)GetNode("CollisionShape2D_4");      
        
    }

    public override void _Process(double delta)
    {  
        string func_name = "_Process";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }

    }

    public void _SpaceStation_Area2d(Area2D ObjectsCollided)
    {
        string func_name = "_SpaceStation_Area2d";        
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        var _SpaceStation_Area2d_Path = ObjectsCollided.GetPath();
        CollisionShape2D CollisionShape2D_1 = (CollisionShape2D)GetNode(_SpaceStation_Area2d_Path); 
 
    }
 

}
