using Godot;
using System;

public partial class ParallaxBackground2 : ParallaxBackground
{
    // planets
    [Export] public float PlanetSpeed1 = 0.4f; 
    [Export] public float PlanetSpeed2 = 0.6f; 
    [Export] public float PlanetSpeed4 = 0.3f; 
    [Export] public float PlanetSpeed3 = 0.8f; 
    private Sprite2D BackgroundPlanet1; 
    private Sprite2D BackgroundPlanet2; 
    private Sprite2D BackgroundPlanet3; 
    private Sprite2D BackgroundPlanet4; 
    
    
    public override void _Ready()
    { 
        BackgroundPlanet1 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground2/ParallaxLayer/Sprite2D");
        BackgroundPlanet2 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground2/ParallaxLayer2/Sprite2D");
        BackgroundPlanet4 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground2/ParallaxLayer4/Sprite2D");
        BackgroundPlanet3 = GetNode<Sprite2D>("/root/GateWayGameScene/ParallaxBackground2/ParallaxLayer3/Sprite2D"); 
    }
    public override void _Process(double delta)
    { 
        BackgroundPlanet1.Position = new Vector2(BackgroundPlanet1.Position.X,  PlanetSpeed1);
        BackgroundPlanet2.Position = new Vector2(BackgroundPlanet2.Position.X,  PlanetSpeed2);
        BackgroundPlanet4.Position = new Vector2(BackgroundPlanet4.Position.X,  PlanetSpeed4);
        BackgroundPlanet3.Position = new Vector2(BackgroundPlanet3.Position.X,  PlanetSpeed3);
    }
}
