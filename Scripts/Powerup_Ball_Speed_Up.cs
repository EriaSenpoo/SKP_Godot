using Godot;
using System;

public class Powerup_Ball_Speed_Up : Area2D
{
	Ball ball = new Ball();
	bool active = true;

	public override void _Ready()
	{
		Timer timer = new Timer();
		timer.Connect("timeout", this, "powerup_timeout");
		timer.WaitTime = 10;
		timer.OneShot = true;
		AddChild(timer);
		timer.Start();
	}

	private void area_entered(object area)
	{
		if (active)
		{
			ball.speed += 5555; // Test for ball
		}
	}

	public void powerup_timeout()
	{
		active = false;
	}
}
