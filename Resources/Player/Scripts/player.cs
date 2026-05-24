using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class Player : CharacterBody2D
{    
    
    [ExportGroup("Required Nodes")]
     private AnimationPlayer animationPlayerNode;
     private AnimatedSprite2D PlayerAnimSprite2D;   
     
    public GameData gameData;
    private string ClassName = "Player|CharacterBody2D";
    private int debug = 1; 
    private Vector2 direction = new(); 
    private string last_known_direction;
    private string last_known_state;
      
    private int runBALOnce = 0;
    private int CONST_Velocity = 10;
    private bool CONST_Damaged = false;

    public override void _Ready()
    {
        var func_name = "_Ready";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] "); }
        
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData(); 

        GD.Print("Scene path: ", GetSceneFilePath());
        GD.Print("Children: ", GetChildren());
        GetTree().Root.PrintTreePretty();

        PlayerAnimSprite2D =  GetNode<AnimatedSprite2D>("PlayerAnimSprite2D");  
        animationPlayerNode = GetNode<AnimationPlayer>("AnimationPlayer");

        last_known_direction = gameData.Get_PlayerDirection();
        if (runBALOnce < 1)
        { 
            BuildAnimationLibrary();
            runBALOnce = runBALOnce + 1;
        }
        //AnimationFunction(gameData.GameConstants("ANIM_IDLE_LEFT"));
    }

    public void BuildAnimationLibrary()// Create a new animation
    {
        var func_name = "BuildAnimationLibrary";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] "); }
        SpriteFrames spriteFramesList = PlayerAnimSprite2D.SpriteFrames;
        // Example: Print all animation names for debuging purposes... 
        foreach (string animName in spriteFramesList.GetAnimationNames())
        {
            if (debug == 1) { GD.Print("Building Animation Library: " + animName); }
        }

        foreach (string animName in spriteFramesList.GetAnimationNames())
        {
            if (debug == 1) { GD.Print("Building Animation Library: " + animName); }

            // Example: Get number of frames in "walk" animation
            int frameCount = spriteFramesList.GetFrameCount(animName);
            if (debug == 1) { GD.Print(animName + " has " + frameCount + " frames."); }
            Texture2D[] frames = new Texture2D[frameCount];

            // Add a new animation to the animation player.
            Animation myAnim = new Animation();
            if (debug == 1) { GD.Print("Created new animation [ " + animName + " ]"); }
            // Set the time length for the whole animation
            myAnim.Length = 1.0f;
            myAnim.LoopMode = Animation.LoopModeEnum.Linear; 
            float frameTime = myAnim.Length / frameCount;

            // Add track to the animation player (just like the editor)
            int trackIdx = myAnim.AddTrack(Animation.TrackType.Value);
            if (debug == 1) { GD.Print("AddTrack [ " + animName + " ]"); }

            // Set the track to use textures (just like the editor)
            myAnim.TrackSetPath(trackIdx, PlayerAnimSprite2D.GetPath() + ":texture");
            if (debug == 1) { GD.Print("TrackSetPath [ " + animName + " ]"); }

            // bulid the animations key frames from the selected sprite frames
            for (int i = 0; i < frameCount; i++)
            { 
                Texture2D FrameAnim = spriteFramesList.GetFrameTexture(animName, i);
                int trackIndex = myAnim.GetTrackCount() - 1;
                frames[i] = FrameAnim;
                myAnim.TrackInsertKey(trackIndex, i * frameTime, frames[i]);
            }
            if (debug == 1) { GD.Print("Added key frames to track. [ " + animName + " ]"); }

            // Create and assign a new AnimationLibrary
            var animLibrary = new AnimationLibrary();
            animLibrary.AddAnimation(animName, myAnim);
            if (debug == 1) { GD.Print("AddAnimation [ " + animName + " ]"); }
            // Register the AnimationLibrary under the AnimationPlayer
            if (animName != null && animLibrary != null)
            {
                animationPlayerNode.AddAnimationLibrary(animName, animLibrary);
                if (debug == 1) { GD.Print("AddAnimationLibrary [ " + animName + " ] "); } 
            }
            if (debug == 1) { GD.Print(" **************************************************** "); }
        }         
    }

    public void AnimationFunction(string Direction, string AnimationLabel)// Create a new animation
    {

        var func_name = "AnimationFunction";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] AnimationLabel - "+ AnimationLabel); }
        Boolean FoundAnim = false;
        SpriteFrames spriteFrames = PlayerAnimSprite2D.SpriteFrames;
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
            animationPlayerNode.Play(AnimationLabel + "/" + AnimationLabel);            
            //animationPlayerNode.Play(AnimationLabel);
        }
        else
        {
            GD.Print("ERROR: The animation [" + AnimationLabel + "/" + AnimationLabel + "] does not exist in sprite frames.");
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        var func_name = "_PhysicsProcess"; 
        Velocity = new(direction.X, direction.Y);
        Velocity *= CONST_Velocity;         
        MoveAndSlide();
    } 


    public override void _Input(InputEvent @event)
    { 
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData(); 
        string DIRECTION_RIGHT = gameData.Get_DIRECTION_RIGHT();
        string DIRECTION_LEFT = gameData.Get_DIRECTION_LEFT();
        string DIRECTION_UP = gameData.Get_DIRECTION_UP();
        string DIRECTION_DOWN = gameData.Get_DIRECTION_DOWN();
 
        string STATE_IDLE = gameData.Get_STATE_IDLE();
        string STATE_MOVEMENT = gameData.Get_STATE_MOVEMENT();

        string STATE_NORMAL = gameData.Get_STATE_NORMAL();
        string STATE_DAMAGED = gameData.Get_STATE_DAMAGED(); 

        direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        // Vector2.Left   = (-1, 0)
        // Vector2.Right  = ( 1, 0) 
 
        if (direction.X > 0 && direction.Y == 0)
        {
            if(CONST_Damaged == false)
            {
                if(Velocity.X > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_RIGHT, STATE_MOVEMENT, STATE_NORMAL);
                    AnimationFunction(last_known_direction, last_known_state ); 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_RIGHT, STATE_IDLE, STATE_NORMAL); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }
            else // if(CONST_Damaged == true) 
            { 
                if(Velocity.X > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_RIGHT, STATE_MOVEMENT, STATE_DAMAGED);   
                    AnimationFunction(last_known_direction, last_known_state );                 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_RIGHT, STATE_IDLE, STATE_DAMAGED); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }    
        }
        else if (direction.X < 0 && direction.Y == 0)
        {
            if(CONST_Damaged == false)
            {
                if(Velocity.X > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_LEFT, STATE_MOVEMENT, STATE_NORMAL);
                    AnimationFunction(last_known_direction, last_known_state ); 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_LEFT, STATE_IDLE, STATE_NORMAL); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }
            else // if(CONST_Damaged == true) 
            { 
                if(Velocity.X > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_LEFT, STATE_MOVEMENT, STATE_DAMAGED);   
                    AnimationFunction(last_known_direction, last_known_state );                 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_LEFT, STATE_IDLE, STATE_DAMAGED); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }    
        }

        // Vector2.Up     = ( 0,-1)
        // Vector2.Down   = ( 0, 1)
        else if (direction.Y < 0 && direction.X == 0)
        {
            if(CONST_Damaged == false)
            {
                if(Velocity.Y > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_UP, STATE_MOVEMENT, STATE_NORMAL);
                    AnimationFunction(last_known_direction, last_known_state ); 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_UP, STATE_IDLE, STATE_NORMAL); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }
            else // if(CONST_Damaged == true) 
            { 
                if(Velocity.Y > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_UP, STATE_MOVEMENT, STATE_DAMAGED);   
                    AnimationFunction(last_known_direction, last_known_state );                 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_UP, STATE_IDLE, STATE_DAMAGED); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }    
        }
        else if (direction.Y > 0 && direction.X == 0)
        {
           
            if(CONST_Damaged == false)
            {
                if(Velocity.Y > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_DOWN, STATE_MOVEMENT, STATE_NORMAL);
                    AnimationFunction(last_known_direction, last_known_state ); 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_DOWN, STATE_IDLE, STATE_NORMAL); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }
            else // if(CONST_Damaged == true) 
            { 
                if(Velocity.Y > 0)
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_DOWN, STATE_MOVEMENT, STATE_DAMAGED);   
                    AnimationFunction(last_known_direction, last_known_state );                 
                }
                else
                {
                    (last_known_direction, last_known_state) = gameData.GameConstants(DIRECTION_DOWN, STATE_IDLE, STATE_DAMAGED); 
                    AnimationFunction(last_known_direction, last_known_state );                      
                }
            }    
        }
 
    }
} 