using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  
public partial class HudEngines : Node2D
{   
 
    public int hud_value = 100;
    private int debug = 0;
 
    private string ClassName = "HudEngines";

     private AnimatedSprite2D Active_AnimatedSprite2D;
     private AnimatedSprite2D Hundreds_AnimatedSprite2D;
     private AnimatedSprite2D Tens_AnimatedSprite2D;
     private AnimatedSprite2D Ones_AnimatedSprite2D;
     private TextureProgressBar TextureProgressBar;
 
    public override void _Ready()
    {
        string func_name = "_Ready";  
        
        Hundreds_AnimatedSprite2D = GetNode<AnimatedSprite2D>("HBoxContainer/BoxContainer/Hundreds_AnimatedSprite2D"); 
        Tens_AnimatedSprite2D = GetNode<AnimatedSprite2D>("HBoxContainer/BoxContainer2/Tens_AnimatedSprite2D");  
        Ones_AnimatedSprite2D = GetNode<AnimatedSprite2D>("HBoxContainer/BoxContainer3/Ones_AnimatedSprite2D");  
        TextureProgressBar = GetNode<TextureProgressBar>("TextureProgressBar");  
    }

    public void SET_VALUE(int data)
    {
        string func_name = "SET_VALUE";  
        hud_value = data;
        TextureProgressBar.Value = hud_value;
        /// set the SpriteFrames number
        UpdateDisplay(hud_value);
    } 


 private void UpdateDisplay(int data)
    {
        string func_name = "UpdateDisplay";  
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] START  -->  "); } 
        int remainder = 0;
        int hundreds = 0;
        int tens = 0;
        int ones = 0;
 
        hundreds = data / 100;
        remainder = data % 100;            
        tens = remainder / 10;
        ones = remainder % 10;     
         
        if (debug == 1) { GD.Print($"{hundreds}{tens}{ones}"); }  
        
        UpdateVisualTimer(hundreds, Hundreds_AnimatedSprite2D); 
        UpdateVisualTimer(tens, Tens_AnimatedSprite2D); 
        UpdateVisualTimer(ones, Ones_AnimatedSprite2D); 
 
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] <-- END "); }   
 
    }
    private void UpdateVisualTimer(int number, AnimatedSprite2D UPDATEME)
    { 
        string func_name = "UpdateVisualTimer";  
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] START  -->  "); } 
        switch (number)
        {
            case 0:
                if (debug == 1) { GD.Print("Zero"); }
                //UPDATEME.Texture = Digit_0;
                AnimationFunction("0", UPDATEME);
                break;

            case 1:
                if (debug == 1) { GD.Print("One"); }
                //UPDATEME.Texture = Digit_1;
                AnimationFunction("1", UPDATEME);
                break;

            case 2:
                if (debug == 1) { GD.Print("Two"); }
                //UPDATEME.Texture = Digit_2;
                AnimationFunction("2", UPDATEME);
                break;

            case 3:
                if (debug == 1) { GD.Print("Three"); }
                //UPDATEME.Texture = Digit_3;
                AnimationFunction("3", UPDATEME);
                break;
                
            case 4:
                if (debug == 1) { GD.Print("Four"); }
                //UPDATEME.Texture = Digit_4;
                AnimationFunction("4", UPDATEME);
                break;

            case 5:
                if (debug == 1) { GD.Print("Five"); }
                //UPDATEME.Texture = Digit_5;
                AnimationFunction("5", UPDATEME);
                break;

            case 6:
                if (debug == 1) { GD.Print("Six"); }
                //UPDATEME.Texture = Digit_6;
                AnimationFunction("6", UPDATEME);
                break;

            case 7:
                if (debug == 1) { GD.Print("Seven"); }
                //UPDATEME.Texture = Digit_7;
                AnimationFunction("7", UPDATEME);
                break;

            case 8:
                if (debug == 1) { GD.Print("Eight"); }
                //UPDATEME.Texture = Digit_8;
                AnimationFunction("8", UPDATEME);
                break;

            case 9:
                if (debug == 1) { GD.Print("Nine"); }
                //UPDATEME.Texture = Digit_9;
                AnimationFunction("9", UPDATEME);
                break;    
 
            default:
                if (debug == 1) { GD.Print("Unknown number."); }
                if (debug == 1) { GD.Print("Forced - Zero"); }
                //UPDATEME.Texture = Digit_0;
                AnimationFunction("0", UPDATEME);
                break;
        }
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] <-- END "); } 
        
    }

    public void AnimationFunction(string AnimationLabel, AnimatedSprite2D Active_AnimatedSprite2D)// Create a new animation
    {

        var func_name = "AnimationFunction";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] AnimationLabel - "+ AnimationLabel); }
        Boolean FoundAnim = false;
        SpriteFrames spriteFrames = Active_AnimatedSprite2D.SpriteFrames;
        // Example: Print all animation names for debuging purposes... 
        foreach (string animName in spriteFrames.GetAnimationNames())
        { 
            if (animName == AnimationLabel)
            {
                FoundAnim = true;
                // Verifing the labeled sprite frame exists. 
            }
        }
        if (FoundAnim == true)
        { 
            // Play it
            Active_AnimatedSprite2D.Play(AnimationLabel + "/" + AnimationLabel);            
            //animationPlayerNode.Play(AnimationLabel);
        }
        else
        {
            GD.Print("ERROR: The animation [" + AnimationLabel + "/" + AnimationLabel + "] does not exist in sprite frames.");
        }
    }

}