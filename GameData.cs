using Godot;
using System;
using Godot.Collections;  
using GodotDict = Godot.Collections.Dictionary;  

public partial class GameData : Node
{
    public Dictionary Godotdata{get; set;} = new();
    private int debug = 1;
    private string ClassName = "GameData"; 
    private const int max_width = 1800;
    private const int max_height = 1000; 
    public const int GridWidth = max_width;
    public const int GridHeight = max_height;
 
    public const string ANIM_IDLE_LEFT = "Idle_Left";
    public const string ANIM_IDLE_RIGHT = "Idle_Right";
    public const string ANIM_WALK_LEFT = "Walk_Left";
    public const string ANIM_WALK_RIGHT = "Walk_Right";
    public const string DIRECTION_RIGHT = "right";
    public const string DIRECTION_LEFT = "left";
    public const string DIRECTION_FORWARD = "forward";
    public const string DIRECTION_BACKWARD = "backward";

    public void SetGodotData(Dictionary data)
    { 
        var func_name = "SetGodotData";
        Godotdata = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Game Data: "+Godotdata); }
    }

    public Dictionary GetGodotData()
    { 
        var func_name = "GetGodotData";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Game Data: "+Godotdata); }
        return(Godotdata);
    }
    public override void _Ready()
    {
        var func_name = "_Ready";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]"); }
        // Example: placeholder for some data
        Godotdata = new GodotDict()
        {
            { "player_name", "PlayerName" },
            { "level", 0 },
            { "health", 100 }, 
            { "magic", 100 }, 
            { "dexterity", 100 }, 
            { "strength", 100 }, 
            { "intelligence", 100 }, 
            { "wisdom", 100 }, 
            { "charisma", 100 }, 
            { "Constitution", 100 },  
            { "GridWidth", 0 }, 
            { "GridHeight", 0 }, 
            { "Player_X", 0 },   
            { "Player_Y", 0 }, 
            { "Player_Map", "CenterSquareMap" }, 
            { "last_known_direction",  "" }, 
            { "Map001", 0 },   
            { "Map002", 0 },   
            { "Map003", 0 },   
            { "Map004", 0 },  
            { "Map005", 0 }, 
            { "Map006", 0 }, 
            { "Map007", 0 },  
            { "Map008", 0 },  
            { "CenterSquareMap", 0 }
        };       
    }

    public void Set_GridWidth(int data)
    { 
        var func_name = "Set_GridWidth"; 
        Godotdata["GridWidth"] = data; 
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.GridWidth: "+ Godotdata["GridWidth"]); }
    }
    public int Get_GridWidth()
    { 
        var func_name = "Get_GridWidth";  
        int GridWidth = (int)Godotdata["GridWidth"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.GridWidth: "+ Godotdata["GridWidth"]); }
        return( GridWidth );
    }    
    
        
    public void Set_GridHeight(int data)
    { 
        var func_name = "Set_GridHeight";
        Godotdata["GridHeight"] = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.GridHeight: "+ Godotdata["GridHeight"]); }
    }
    public int Get_GridHeight()
    { 
        var func_name = "Get_GridHeight";  
        int GridHeight = (int)Godotdata["GridHeight"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.GridHeight: "+ Godotdata["GridHeight"]); }
        return( GridHeight );
    }  

    public void Set_PlayerX(int data)
    { 
        var func_name = "Set_PlayerX";
        Godotdata["Player_X"] = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_X: "+ Godotdata["Player_X"]); }
    }
    public int Get_PlayerX()
    { 
        var func_name = "Get_PlayerX";  
        int Player_X = (int)Godotdata["Player_X"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_X: "+ Godotdata["Player_X"]); }
        return( Player_X );
    }  

    public void Set_PlayerY(int data)
    { 
        var func_name = "Set_PlayerY";
        Godotdata["Player_Y"] = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_Y: "+ Godotdata["Player_Y"]); }
    }
    public int Get_PlayerY()
    { 
        var func_name = "Get_PlayerY";  
        int Player_Y = (int)Godotdata["Player_Y"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_Y: "+ Godotdata["Player_Y"]); }
        return( Player_Y );
    }  

    public void Set_PlayerMap(string data)
    { 
        var func_name = "Set_PlayerMap";
        Godotdata["Player_Map"] = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_Map: "+ Godotdata["Player_Map"]); }
    }
    public string Get_PlayerMap()
    { 
        var func_name = "Get_PlayerMap";  
        string PlayerMap = (string)Godotdata["Player_Map"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.Player_Map: "+ Godotdata["Player_Map"]); }
        return( PlayerMap );
    }       


    public void Set_PlayerDirection(string data)
    { 
        var func_name = "Set_PlayerDirection";
        Godotdata["last_known_direction"] = data;
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.last_known_direction: "+ Godotdata["last_known_direction"]); }
    }
    public string Get_PlayerDirection()
    { 
        var func_name = "Get_PlayerDirection";  
        string last_known_direction = (string)Godotdata["last_known_direction"];
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Godotdata.last_known_direction: "+ Godotdata["last_known_direction"]); }
        return( last_known_direction );
    }   

    public string GameConstants(string data)
    {
        if (data == "ANIM_IDLE_LEFT"){return ANIM_IDLE_LEFT ;}

        if (data == "ANIM_IDLE_RIGHT"){return ANIM_IDLE_RIGHT ;}
        
        if (data == "ANIM_WALK_LEFT"){return ANIM_WALK_LEFT ;}
        
        if (data == "ANIM_WALK_RIGHT"){return ANIM_WALK_RIGHT ;}
        
        if (data == "DIRECTION_RIGHT"){return DIRECTION_RIGHT ;}
        
        if (data == "DIRECTION_LEFT"){return DIRECTION_LEFT ;}
        
        if (data == "DIRECTION_FORWARD"){return DIRECTION_FORWARD ;}
        
        if (data == "DIRECTION_BACKWARD"){return DIRECTION_BACKWARD ;} 
    
        return "";
    }
 


}
