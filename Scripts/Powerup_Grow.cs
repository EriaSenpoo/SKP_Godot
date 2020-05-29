using Godot;
using System;

public class Powerup_Grow : Area2D
{
	public override void _Ready()
	{
		
	}

	private void area_entered(object area)
	{
		//PackedScene scene = GD.Load<PackedScene>("res://Player.tscn");
		//Node player_node = scene.Instance();
		//AddChild(player_node);
	}
}
