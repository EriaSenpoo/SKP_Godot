using Godot;
using System;

public class Ball : RigidBody2D
{
	[Export]
	public float min_speed = 10;

	[Export]
	public float speed = 100;

	[Export]
	public float max_speed = 100;
	
	Vector2 direction = new Vector2(0, 0);
	bool moveable = false;
	
	public override void _Process(float delta)
	{
		movement();
	}

	public override void _Ready()
	{

	}
	
	private void start_game()
	{
		Random start_direction = new Random();
		start_direction.Next(0, 360);
		direction = new Vector2(Rotation, Convert.ToSingle(start_direction)); // This line is fucked, pure guesswork
		moveable = true;
	}

	public void movement()
	{
		if (moveable)
		{
			direction = direction.Normalized() * speed; // need it to move forward somehow
		}
	}
}
