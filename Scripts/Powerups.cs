using Godot;
using System;

public class Powerups : Node2D
{
	//public override void _Ready()
	//{
	//	Random spawn_rate = new Random();
	//	int time = spawn_rate.Next(10, 30);
	//	Timer timer = new Timer();
	//	timer.Connect("timeout", this, "spawn_timer");
	//	timer.WaitTime = Convert.ToSingle(time);
	//	AddChild(timer);
	//}

	//public void spawn_timer()
	//{
	//	PackedScene scene = GD.Load<PackedScene>("res://Power-ups/Power-ups.tscn");
	//	Node power_up = scene.Instance();
	//	var first = power_up.GetChild(0);
	//	AddChild(first);
	//}
}
