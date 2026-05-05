using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class Player : CharacterBody2D
{    
    
    [ExportGroup("Required Nodes")]
     private AnimationPlayer animationPlayerNode;
     private AnimatedSprite2D PlayerAnimSprite2D; 
     private Sprite2D sprite2DNode;
     
     GameData gameData;
    private string ClassName = "Player|CharacterBody2D";
    private int debug = 1; 
    private Vector2 direction = new();
    private bool DEBUG = false;
    private String last_known_direction;
    private int runBALOnce = 0;

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

        last_known_direction = gameData.Get_PlayerDirection();
        if (runBALOnce < 1)
        {
            //BuildAnimationLibrary();
            runBALOnce = runBALOnce + 1;
        }
        //AnimationFunction(gameData.GameConstants("ANIM_IDLE_LEFT"));
    }

    public void BuildAnimationLibrary()// Create a new animation
    {
        SpriteFrames spriteFramesList = PlayerAnimSprite2D.SpriteFrames;
        // Example: Print all animation names for debuging purposes... 
        foreach (string animName in spriteFramesList.GetAnimationNames())
        {
            if (DEBUG == true) { GD.Print("Building Animation Library: " + animName); }

            // Example: Get number of frames in "walk" animation
            int frameCount = spriteFramesList.GetFrameCount(animName);
            if (DEBUG == true) { GD.Print(animName + " has " + frameCount + " frames."); }
            Texture2D[] frames = new Texture2D[frameCount];

            // Add a new animation to the animation player.
            Animation myAnim = new Animation();
            if (DEBUG == true) { GD.Print("Created new animation [ " + animName + " ]"); }
            // Set the time length for the whole animation
            myAnim.Length = 1.0f;
            myAnim.LoopMode = Animation.LoopModeEnum.Linear;
            // I dunno what linear does yet, but it's the same as the default for the editor
            // set the frame time base don the animation lenght above, and the number of sprite frames that are being added to the animation.
            float frameTime = myAnim.Length / frameCount;

            // Add track to the animation player (just like the editor)
            int trackIdx = myAnim.AddTrack(Animation.TrackType.Value);
            if (DEBUG == true) { GD.Print("AddTrack [ " + animName + " ]"); }

            // Set the track to use textures (just like the editor)
            myAnim.TrackSetPath(trackIdx, sprite2DNode.GetPath() + ":texture");
            if (DEBUG == true) { GD.Print("TrackSetPath [ " + animName + " ]"); }

            // bulid the animations key frames from the selected sprite frames
            for (int i = 0; i < frameCount; i++)
            { 
                Texture2D FrameAnim = spriteFramesList.GetFrameTexture(animName, i);
                int trackIndex = myAnim.GetTrackCount() - 1;
                frames[i] = FrameAnim;
                myAnim.TrackInsertKey(trackIndex, i * frameTime, frames[i]);
            }
            if (DEBUG == true) { GD.Print("Added key frames to track. [ " + animName + " ]"); }

            // Create and assign a new AnimationLibrary
            var animLibrary = new AnimationLibrary();
            animLibrary.AddAnimation(animName, myAnim);
            if (DEBUG == true) { GD.Print("AddAnimation [ " + animName + " ]"); }
            // Register the AnimationLibrary under the AnimationPlayer
            animationPlayerNode.AddAnimationLibrary(animName, animLibrary);
            if (DEBUG == true) { GD.Print("AddAnimationLibrary [ " + animName + " ] "); }
            // animation is ready to play at a later time.            
            if (DEBUG == true) { GD.Print("Animation Library is ready for [ " + animName + " ] "); }
            if (DEBUG == true) { GD.Print(" **************************************************** "); }
        }         
    }

    public void AnimationFunction(String AnimationLabel)// Create a new animation
    {
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
        }
        else
        {
            GD.Print("ERROR: The animation [" + AnimationLabel + "] does not exist in sprite frames.");
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, direction.Y);
        Velocity *= 5;         
        MoveAndSlide();
    } 
    public override void _Input(InputEvent @event)
    {
        GameData gameData = GetNode<GameData>("/root/GameData");
        GodotDict PlayerData = gameData.GetGodotData(); 
        
        direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        if (direction > Vector2.Zero)
        {
            AnimationFunction(gameData.GameConstants("ANIM_WALK_RIGHT"));
            last_known_direction = gameData.GameConstants("DIRECTION_RIGHT");
        }
        else if (direction < Vector2.Zero)
        {
            AnimationFunction(gameData.GameConstants("ANIM_WALK_LEFT"));
            last_known_direction = gameData.GameConstants("DIRECTION_LEFT");
        }
        else
        {
            if (last_known_direction == gameData.GameConstants("DIRECTION_RIGHT"))
            {
                AnimationFunction(gameData.GameConstants("ANIM_IDLE_RIGHT"));
            }
            else
            { 
                AnimationFunction(gameData.GameConstants("ANIM_IDLE_LEFT"));
            }
        }
    }
}
