using Godot;
using System;
using System.Runtime.CompilerServices;
using GodotDict = Godot.Collections.Dictionary;  

public partial class ShipBuilder : Node2D
{   
	private int Core_ClickCount = 0;
	private int Weapon_ClickCount = 0;
	private int Engine_ClickCount = 0;
	private int Cockpit_ClickCount = 0;
	private int Cargo_ClickCount = 0; 
    public override void _Ready()
    {
		
    }

	public void Core_ButtonCorePressed()
	{
		var animSprite = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_CENTER/AnimatedSprite2D_CENTER_USABLE");
		var animSprite2 = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_CENTER/AnimatedSprite2D_CENTER");

		if (Core_ClickCount == 0)
		{
			animSprite.Hide();
			animSprite2.Show();
			Core_ClickCount = 1;
		}
		else
		{
			animSprite.Show();
			animSprite2.Hide();
			Core_ClickCount = 0;
		}
	}

	public void Engine_ButtonCorePressed()
	{
		var animSprite = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_BOTTOM/AnimatedSprite2D_BOTTOM_USABLE");
		var animSprite2 = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_BOTTOM/AnimatedSprite2D_BOTTOM");

		if (Engine_ClickCount == 0)
		{
			animSprite.Hide();
			animSprite2.Show();
			Engine_ClickCount = 1;
		}
		else
		{
			animSprite.Show();
			animSprite2.Hide();
			Engine_ClickCount = 0;
		}
	}

	public void Weapons_ButtonCorePressed()
	{
		var animSprite = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_RIGHT/AnimatedSprite2D_RIGHT_USABLE");
		var animSprite2 = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_RIGHT/AnimatedSprite2D_RIGHT");

		if (Weapon_ClickCount == 0)
		{
			animSprite.Hide();
			animSprite2.Show();
			Weapon_ClickCount = 1;
		}
		else
		{
			animSprite.Show();
			animSprite2.Hide();
			Weapon_ClickCount = 0;
		}
	}

	public void Cockpit_ButtonCorePressed()
	{
		var animSprite = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_TOP/AnimatedSprite2D_TOP_USABLE");
		var animSprite2 = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_TOP/AnimatedSprite2D_TOP");

		if (Cockpit_ClickCount == 0)
		{
			animSprite.Hide();
			animSprite2.Show();
			Cockpit_ClickCount = 1;
		}
		else
		{
			animSprite.Show();
			animSprite2.Hide();
			Cockpit_ClickCount = 0;
		}
	}


	public void Cargo_ButtonCorePressed()
	{
		var animSprite = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_LEFT/AnimatedSprite2D_LEFT_USABLE");
		var animSprite2 = GetNode<AnimatedSprite2D>("/root/ShipBuilder/GridContainer/BoxContainer_LEFT/AnimatedSprite2D_LEFT");

		if (Cargo_ClickCount == 0)
		{
			animSprite.Hide();
			animSprite2.Show();
			Cargo_ClickCount = 1;
		}
		else
		{
			animSprite.Show();
			animSprite2.Hide();
			Cargo_ClickCount = 0;
		}
	}

}
  