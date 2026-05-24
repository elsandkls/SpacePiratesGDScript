using Godot;
using System;
using Godot.Collections;  
using GodotDict = Godot.Collections.Dictionary;
using System.Data;


public partial class GameData : Node
{
    public Dictionary Godotdata{get; set;} = new();
    private int debug = 1;
    private string ClassName = "GameData"; 
    private const int max_width = 1800;
    private const int max_height = 1000; 
    public const int GridWidth = max_width;
    public const int GridHeight = max_height;
 
    public const string STATE_IDLE = "IDLE";
    public const string STATE_MOVEMENT = "MOVING";

    public const string STATE_DAMAGED = "DAMAGED";
    public const string STATE_NORMAL = "NORMAL";
 

    public const string ANIM_IDLE_LEFT = "LEFT_IDLE";
    public const string ANIM_IDLE_RIGHT = "RIGHT_IDLE";
    public const string ANIM_IDLE_UP = "UP_IDLE";
    public const string ANIM_IDLE_DOWN = "DOWN_IDLE";

    public const string ANIM_LEFT = "LEFT";
    public const string ANIM_RIGHT = "RIGHT";
    public const string ANIM_UP = "UP";
    public const string ANIM_DOWN = "DOWN";

    public const string ANIM_LEFT_DAMAGED = "LEFT_DAMAGED";
    public const string ANIM_RIGHT_DAMAGED = "RIGHT_DAMAGED";
    public const string ANIM_UP_DAMAGED = "UP_DAMAGED";
    public const string ANIM_DOWN_DAMAGED = "DOWN_DAMAGED";

    
    public const string ANIM_IDLE_LEFT_DAMAGED = "LEFT_DAMAGED";
    public const string ANIM_IDLE_RIGHT_DAMAGED = "RIGHT_DAMAGED";
    public const string ANIM_IDLE_UP_DAMAGED = "UP_DAMAGED";
    public const string ANIM_IDLE_DOWN_DAMAGED = "DOWN_DAMAGED";

    public const string DIRECTION_RIGHT = "RIGHT";
    public const string DIRECTION_LEFT = "LEFT";
    public const string DIRECTION_UP = "UP";
    public const string DIRECTION_DOWN = "DOWN";

    public string Get_DIRECTION_RIGHT()
    { 
        var func_name = "Get_DIRECTION_RIGHT";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + DIRECTION_RIGHT ); }
        return( DIRECTION_RIGHT );
    }  
    public string Get_DIRECTION_LEFT()
    { 
        var func_name = "Get_DIRECTION_LEFT";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + DIRECTION_LEFT ); }
        return( DIRECTION_LEFT );
    }  
    public string Get_DIRECTION_UP()
    { 
        var func_name = "Get_DIRECTION_UP";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + DIRECTION_UP ); }
        return( DIRECTION_UP );
    }  
    public string Get_DIRECTION_DOWN()
    { 
        var func_name = "Get_DIRECTION_DOWN";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + DIRECTION_DOWN ); }
        return( DIRECTION_DOWN );
    }  


    public string Get_STATE_MOVEMENT()
    { 
        var func_name = "Get_STATE_MOVEMENT";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + STATE_MOVEMENT ); }
        return( STATE_MOVEMENT );
    } 
    public string Get_STATE_IDLE()
    { 
        var func_name = "Get_STATE_IDLE";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + STATE_IDLE ); }
        return( STATE_IDLE );
    } 


    public string Get_STATE_NORMAL()
    { 
        var func_name = "Get_STATE_NORMAL";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + STATE_NORMAL ); }
        return( STATE_NORMAL );
    } 
    public string Get_STATE_DAMAGED()
    { 
        var func_name = "Get_STATE_DAMAGED";   
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]" + STATE_DAMAGED ); }
        return( STATE_DAMAGED );
    } 
 

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


    public (string, string) GameConstants(string data, string mystate, string movement)
    {
        var func_name = "GameConstants"; 
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] " + data); }

        if (data == DIRECTION_RIGHT){ 
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]  MATCH: " + DIRECTION_RIGHT); }

            if (movement == STATE_IDLE)  // no movement
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_IDLE_RIGHT); }
                    return (DIRECTION_RIGHT, ANIM_IDLE_RIGHT);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_RIGHT_DAMAGED); }
                    return (DIRECTION_RIGHT, ANIM_RIGHT_DAMAGED);                    
                } 
            }
            else // movement, not idle
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_IDLE_RIGHT); }
                    return (DIRECTION_RIGHT, ANIM_RIGHT);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_RIGHT_DAMAGED); }
                    return (DIRECTION_RIGHT, ANIM_IDLE_RIGHT_DAMAGED);                    
                } 
            }
 
        }        

        if (data == DIRECTION_LEFT){ 

            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]  MATCH: " + DIRECTION_LEFT); }

            if (movement == STATE_IDLE)  // no movement
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_IDLE_LEFT); }
                    return (DIRECTION_LEFT, ANIM_IDLE_LEFT);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_LEFT_DAMAGED); }
                    return (DIRECTION_LEFT, ANIM_IDLE_LEFT_DAMAGED);                    
                } 
            }
            else // movement, not idle
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_LEFT); }
                    return (DIRECTION_LEFT, ANIM_LEFT);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_LEFT_DAMAGED); }
                    return (DIRECTION_LEFT, ANIM_IDLE_LEFT_DAMAGED);                    
                } 
            } 
        }   

        if (data == DIRECTION_UP){ 
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]  MATCH: " + DIRECTION_UP); }

            if (movement == STATE_IDLE)  // no movement
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_IDLE_UP); }
                    return (DIRECTION_UP, ANIM_IDLE_UP);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_UP_DAMAGED); }
                    return (DIRECTION_UP, ANIM_UP_DAMAGED);                    
                } 
            }
            else // movement, not idle
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_LEFT); }
                    return (DIRECTION_UP, ANIM_UP);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_UP_DAMAGED); }
                    return (DIRECTION_UP, ANIM_IDLE_UP_DAMAGED);                    
                } 
            }    
        }        
        if (data == DIRECTION_DOWN){ 
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "]  MATCH: " + DIRECTION_DOWN); }

            if (movement == STATE_IDLE)  // no movement
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_IDLE_DOWN); }
                    return (DIRECTION_DOWN, ANIM_IDLE_DOWN);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_DOWN_DAMAGED); }
                    return (DIRECTION_DOWN, ANIM_DOWN_DAMAGED);                    
                } 
            }
            else // movement, not idle
            {
                if(mystate == STATE_NORMAL) // state not damaged = normal
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_LEFT); }
                    return (DIRECTION_DOWN, ANIM_DOWN);   
                }
                else // state damaged
                {
                    if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] MATCH: " + ANIM_DOWN_DAMAGED); }
                    return (DIRECTION_DOWN, ANIM_IDLE_DOWN_DAMAGED);                    
                } 
            }   
        }
     
    
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] NO MATCH - DEFAULT: " + ANIM_UP); }
        return (DIRECTION_UP, ANIM_UP);  
    }
}
