using Godot;
using System;

public class Ball : RigidBody2D
{
	[Export]
	public int min_speed = 10;

	[Export]
	public int max_speed = 100;

	public override void _Ready()
	{
		
	}
}
