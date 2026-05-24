using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class MiniScene : Node2D
{
    private AnimationPlayer animationPlayerNode;
     private AnimatedSprite2D PlayerAnimSprite2D; 
     private Sprite2D sprite2DNode;
     
    public GameData gameData;
    private string ClassName = "MiniScene";
    private int debug = 1; 
    public override void _Ready()
    {
        var func_name = "_Ready";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] "); }
        
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData(); 

    }

    public void SetSprite2D()// Create a new animation
    {
        var func_name = "SetSprite2D";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] "); }

        Sprite2D sprite = GetNode<Sprite2D>("Sprite2D");

        Texture2D texture = GD.Load<Texture2D>("res://art/player.png");

        sprite.Texture = texture;
    }
}
