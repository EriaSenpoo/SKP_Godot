using Godot;
using System;

public class Powerup_Player_Slow : Area2D
{
	Player player = new Player();

	public override void _Ready()
	{
		
	}

	private void area_entered(object area)
	{
		player.speed = 0.05f;
	}
}
