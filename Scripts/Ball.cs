using Godot;
using System;

public class Ball : RigidBody2D
{
	[Export]
	public float min_speed = 10;

	[Export]
	public float speed = 20;

	[Export]
	public float max_speed = 100;

	Vector2 last_velocity = new Vector2(0, 0);
	Vector2 velocity;
	bool moveable = false;

	public override void _Ready()
	{

	}

	public override void _Process(float delta)
	{
		movement();
	}

	private void start_ball()
	{
		Random start_direction = new Random();
		float random_direction_y = start_direction.Next(-1, 1);
		float random_direction_x = start_direction.Next(-1, 1);
		velocity = new Vector2(random_direction_x, random_direction_y);
		moveable = true;
	}

	public void movement()
	{
		if (moveable)
		{
			AddForce(new Vector2(0, 0), velocity);
		}
	}

	private void on_collision(object body)
	{
		Random start_direction = new Random();
		float random_direction_y = start_direction.Next(-1, 1);
		float random_direction_x = start_direction.Next(-1, 1);
		velocity = velocity.Bounce(new Vector2(random_direction_y, random_direction_x));
		ContactsReported += 1;
	}
}
