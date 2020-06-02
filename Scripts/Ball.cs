using Godot;
using System;

public class Ball : RigidBody2D
{
	[Export]
	public float min_speed = 10f;

	[Export]
	public float speed = 50f;

	[Export]
	public float max_speed = 2000f; // Test for power-up

	Vector2 last_velocity = new Vector2(0, 0);
	Vector2 velocity;
	bool moveable = false;
	bool has_collided = false;
	bool collision;
	Vector2 force;

	public override void _Ready()
	{

	}

	public override void _Process(float delta)
	{
		//GD.Print(force);
		//GD.Print(speed); // powerup doesn't change ball speed yet
		movement();
	}

	private void start_ball()
	{
		Random start_direction = new Random();
		float random_direction_y = (float)(start_direction.Next(-100, 100) / 100f);
		float random_direction_x = (float)(start_direction.Next(-100, 100) / 100f);
		velocity = new Vector2(random_direction_x, random_direction_y);
		moveable = true;
	}

	public void movement()
	{
		if (moveable)
		{
			Rotation = 0f;
			SetAppliedForce(velocity * speed);
			force = GetAppliedForce();
			if (collision)
			{
				if (speed > max_speed)
				{
					speed = max_speed;
				}
				if (force.x > min_speed)
				{
					speed -= 1f;
				}
				if (force.y > min_speed)
				{
					speed -= 1f;
				}
				//SetAppliedForce(-force);
				//SetAppliedForce(-velocity * speed);
			}
			else
			{
				if (speed > max_speed)
				{
					speed = max_speed;
				}
				if (force.x < min_speed)
				{
					speed += 1f;
				}
				if (force.y < min_speed)
				{
					speed += 1f;
				}
				//SetAppliedForce(force);
				//SetAppliedForce(velocity * speed);
			}
		}
	}

	private void on_collision(object body)
	{
		collision = !collision;
		has_collided = true;
		velocity = velocity.Reflect(velocity);
		ContactsReported += 1;
	}
}
