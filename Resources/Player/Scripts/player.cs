using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class Player : CharacterBody2D
{    
    
    [ExportGroup("Required Nodes")]
     private AnimatedSprite2D AnimSprite2D_Movement;
     private AnimatedSprite2D AnimSprite2D_Damaged;
     private AnimatedSprite2D AnimSprite2D_Healing;
     private AnimatedSprite2D AnimSprite2D_Docking;
     private AnimationPlayer AnimationPlayer;   
     
    public GameData gameData;
    private string ClassName = "Player|CharacterBody2D";
    private int debug = 1; 
    private Vector2 direction = new(); 
    private string last_known_direction;
    private string last_known_state;
      
    private int runBALOnce = 0;
    private int CONST_VELOCITY = 25;
    private bool CONST_DAMAGED = false;
    private bool CONST_HEALING = false;
    private bool CONST_IDLE = false;
    private bool CONST_NORMAL = false;
    private bool CONST_MOVEMENT = false;
    private bool CONST_STATIONARY = false;
    private bool CONST_DOCKING = false;

    
    string DIRECTION_RIGHT = "";
    string DIRECTION_LEFT = "";
    string DIRECTION_UP = "";
    string DIRECTION_DOWN = "";
    
    int DIRECTION_RIGHT_ANGLE = 0;
    int DIRECTION_LEFT_ANGLE = 0;
    int DIRECTION_UP_ANGLE = 0;
    int DIRECTION_DOWN_ANGLE = 0;

    string STATE_IDLE = "";
    string STATE_MOVEMENT = "";
    string STATE_NORMAL = "";
    string STATE_DAMAGED = "";
    string STATE_HEALING = "";
    string STATE_STATIONARY = "";
    string STATE_DOCKING = "";

    int DAMAGED_LEVEL = 0;


    public override void _Ready()
    {
        var func_name = "_Ready";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] "); }
        
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData(); 

        GD.Print("Scene path: ", GetSceneFilePath());
        GD.Print("Children: ", GetChildren());
        GetTree().Root.PrintTreePretty(); 
        AnimSprite2D_Movement =  GetNode<AnimatedSprite2D>("AnimSprite2D_Movement");  
        AnimSprite2D_Damaged =  GetNode<AnimatedSprite2D>("AnimSprite2D_Damaged"); 
        AnimSprite2D_Healing =  GetNode<AnimatedSprite2D>("AnimSprite2D_Healing"); 
        AnimSprite2D_Docking  =  GetNode<AnimatedSprite2D>("AnimSprite2D_Docking"); 
        AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        last_known_direction = gameData.Get_PlayerDirection();
        if (runBALOnce < 1)
        { 
            BuildAnimationLibrary(AnimSprite2D_Movement);
            BuildAnimationLibrary(AnimSprite2D_Damaged);
            BuildAnimationLibrary(AnimSprite2D_Healing);
            BuildAnimationLibrary(AnimSprite2D_Docking);
            runBALOnce = runBALOnce + 1;
        } 
    }

    public void BuildAnimationLibrary(AnimatedSprite2D PlayerAnimSprite2D)// Create a new animation
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
                AnimationPlayer.AddAnimationLibrary(animName, animLibrary);
                if (debug == 1) { GD.Print("AddAnimationLibrary [ " + animName + " ] "); } 
            }
            if (debug == 1) { GD.Print(" **************************************************** "); }
        }         
    }

    public void AnimationFunction(string AnimationLabel, AnimatedSprite2D PlayerAnimSprite2D)// Create a new animation
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
            AnimationPlayer.Play(AnimationLabel + "/" + AnimationLabel);            
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
        Velocity *= CONST_VELOCITY;         
        MoveAndSlide();
    } 


    public override void _Input(InputEvent @event)
    { 
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData();

        DIRECTION_RIGHT = gameData.Get_DIRECTION_RIGHT();
        DIRECTION_LEFT = gameData.Get_DIRECTION_LEFT();
        DIRECTION_UP = gameData.Get_DIRECTION_UP();
        DIRECTION_DOWN = gameData.Get_DIRECTION_DOWN();
        
        DIRECTION_RIGHT_ANGLE = gameData.Get_DIRECTION_RIGHT_ANGLE();
        DIRECTION_LEFT_ANGLE = gameData.Get_DIRECTION_LEFT_ANGLE();
        DIRECTION_UP_ANGLE = gameData.Get_DIRECTION_UP_ANGLE();
        DIRECTION_DOWN_ANGLE = gameData.Get_DIRECTION_DOWN_ANGLE();
 
        STATE_IDLE = gameData.Get_STATE_IDLE();
        STATE_MOVEMENT = gameData.Get_STATE_MOVEMENT();
        STATE_STATIONARY = gameData.Get_STATE_STATIONARY(); 
        STATE_DOCKING = gameData.Get_STATE_DOCKING(); 

        STATE_NORMAL = gameData.Get_STATE_NORMAL();
        STATE_DAMAGED = gameData.Get_STATE_DAMAGED(); 
        STATE_HEALING = gameData.Get_STATE_HEALING();
    
        AnimSprite2D_Movement =  GetNode<AnimatedSprite2D>("AnimSprite2D_Movement");  
        AnimSprite2D_Damaged =  GetNode<AnimatedSprite2D>("AnimSprite2D_Damaged"); 
        AnimSprite2D_Healing =  GetNode<AnimatedSprite2D>("AnimSprite2D_Healing"); 
        AnimSprite2D_Docking  =  GetNode<AnimatedSprite2D>("AnimSprite2D_Docking");

        direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        string plaayer_path = GetPath(); 
        CharacterBody2D player_ship = GetNodeOrNull<CharacterBody2D>(plaayer_path); 

        if(CONST_HEALING == true)
        {
            AnimationFunction( "HEALING", AnimSprite2D_Healing );                     
        } 
        else
        {
            AnimationFunction( "NOT_HEALING", AnimSprite2D_Healing );             
        }

        if(CONST_DAMAGED == true)
        {
            if(DAMAGED_LEVEL == 1 )
            {
                AnimationFunction( "DAMAGED_V!", AnimSprite2D_Damaged );
            }     
            else if(DAMAGED_LEVEL == 2 )
            {
                AnimationFunction( "DAMAGED_V2", AnimSprite2D_Damaged );
            }
            else if(DAMAGED_LEVEL == 3 )
            {
                AnimationFunction( "DAMAGED_V3", AnimSprite2D_Damaged );
            }             
        } 
        else
        {
            AnimationFunction( "NOT_DAMAGED", AnimSprite2D_Damaged );             
        }

        if(CONST_DOCKING == true)
        {
            AnimationFunction( "DOCKING", AnimSprite2D_Docking );                     
        }
        else
        {
            AnimationFunction( "NOT_DOCKING", AnimSprite2D_Docking );             
        }
        
        if (direction.X == 0 && direction.Y == 0)        
        { 
            if(Velocity.X == 0) // moving
            {
                if(CONST_STATIONARY == true)
                {
                    AnimationFunction( "STATIONARY", AnimSprite2D_Movement );                     
                }
            }
            else
            {   
                if(CONST_IDLE == true)
                {
                    AnimationFunction( "IDLE", AnimSprite2D_Movement );                     
                } 
            } 
        }

        // Vector2.Left   = (-1, 0)
        // Vector2.Right  = ( 1, 0) 
        if (direction.X > 0 && direction.Y == 0)
        {
            if(Velocity.X > 0) // moving
            {
                player_ship.Rotate(DIRECTION_RIGHT_ANGLE);                
                if(CONST_MOVEMENT == true)
                {
                    AnimationFunction( "MOVEMENT", AnimSprite2D_Movement );                     
                }  
            }
            else // not moving
            {  
                if(CONST_IDLE == true)
                {
                    AnimationFunction( "IDLE", AnimSprite2D_Movement );                     
                }
            }    
        }

        if (direction.X < 0 && direction.Y == 0)
        { 
            if(Velocity.X < 0)
            {
                player_ship.Rotate(DIRECTION_LEFT_ANGLE);                     
                if(CONST_MOVEMENT == true)
                {
                    AnimationFunction( "MOVEMENT", AnimSprite2D_Movement );                     
                }  
            }
            else
            {   
                if(CONST_IDLE == true)
                {
                    AnimationFunction( "IDLE", AnimSprite2D_Movement );                     
                }  
            }   
        }
 
        // Vector2.Up     = ( 0,-1)
        // Vector2.Down   = ( 0, 1)
        if (direction.Y > 0 && direction.X == 0)
        { 
            if(Velocity.Y > 0)
            {
                player_ship.Rotate(DIRECTION_DOWN_ANGLE);                 
                if(CONST_MOVEMENT == true)
                {
                    AnimationFunction( "MOVEMENT", AnimSprite2D_Movement );                     
                }  
            }
            else
            {     
                if(CONST_IDLE == true)
                {
                    AnimationFunction( "IDLE", AnimSprite2D_Movement );                     
                }   
            }  
        }

        if (direction.Y < 0 && direction.X == 0)
        { 
            if(Velocity.Y < 0)
            {
                player_ship.Rotate(DIRECTION_UP_ANGLE);                  
                if(CONST_MOVEMENT == true)
                {
                    AnimationFunction( "MOVEMENT", AnimSprite2D_Movement );                     
                }  
            }
            else
            {   
                if(CONST_IDLE == true)
                {
                    AnimationFunction( "IDLE", AnimSprite2D_Movement );                     
                }         
            }   
        }
 
    }
} 