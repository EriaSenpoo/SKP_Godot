using Godot;
using System;

public class Main : Node2D
{
	int screen_width = 1024;
	int screen_height = 600;
	
	public override void _Ready()
	{
		// --------- NONE OF THIS IS ACTUALLY SUPPOSED TO BE IN MAIN, IT'S JUST FOR TESTING ---------- \\

		PackedScene scene = GD.Load<PackedScene>("res://Scenes/Power-ups/Power-ups.tscn");
		GD.Print(GetTree().GetNodeCount()); // 15 // Dunno what, I have less than 15 root scenes and more than 15 nodes total
		//var grow = GetTree().Root.GetNode("Player"); // I CAN'T GET THE ROOT OF ANY OTHER NODE THAN MAIN !!!!
		// Can't change anything regarding the newly instanced scene
		Node power_up = scene.Instance();
		AddChild(power_up);
		power_up.Name = "aaaa";
		var a = GetTree().GetRoot().GetNode("Main").GetNode("aaaa");
		GD.Print(a.Name); // aaaa
		GD.Print(power_up.Name); // aaaa

		// Need to figure out:
		// 1. How to pick a child from a newly instanced node from code
		// 2. How to change the child node's position (or any newly instanced node for that matter)
	}
	
	public void start_position()
	{
		//Sprite rotation_point = GetNode<Sprite>("Rotation_Point");
		//Vector2 set_start_position = new Vector2(screen_width / 2, screen_height / 2);
		//rotation_point.Position = set_start_position;
	}
}
