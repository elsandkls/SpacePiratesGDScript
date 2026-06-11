using Godot;
using System;

public partial class ParallaxBackground : Godot.ParallaxBackground
{    
    [Export] public float StarsSpeed = 0.1f; 
    private Sprite2D BackgroundStars1; 
    private Sprite2D BackgroundStars2; 
    
    public override void _Ready()
    { 
        BackgroundStars1 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground/ParallaxLayer/Space1");
        BackgroundStars2 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground/ParallaxLayer/Space2"); 

    }
    public override void _Process(double delta)
    { 
        BackgroundStars1.Position = new Vector2(BackgroundStars1.Position.X,  StarsSpeed);
        BackgroundStars2.Position = new Vector2(BackgroundStars2.Position.X,  StarsSpeed);
    }
}
