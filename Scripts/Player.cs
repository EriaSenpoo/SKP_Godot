using Godot;
using System;

public class Player : KinematicBody2D
{
	bool moveable = false;
	public float speed = 0.1f;

	public override void _PhysicsProcess(float delta)
	{
		player_movement();
	}
	
	private void start_game()
	{
		moveable = true;
	}

	public void player_movement()
	{
		if (moveable)
		{
			if (Input.IsActionPressed("rotate_left"))
			{
				Rotation += speed;
			}
			else if(Input.IsActionPressed("rotate_right"))
			{
				Rotation -= speed;
			}
		}
	}

	public override void _Ready()
	{
		
	}
	/*
	int screen_width = 1024;
	int screen_height = 600;
	Sprite sprite;
	Vector2 position;
	CollisionPolygon2D collision;
	//int sprite_orientation = 360;
	int sprite_thickness = 35;
	Vector2 center = new Vector2(0, 0);
	

	int speed = 300;

	int angle = 0;
	//int distance = 250;
	Vector2 rotation_point = new Vector2(0, 0);

	public override void _PhysicsProcess(float delta)
	{
		player_movement();
	}

	public override void _Ready()
	{
		Vector2 distance = new Vector2(0, 0 - 250 + sprite_thickness);
		rotation_point = new Vector2(screen_width / 2, screen_height / 2);
		position = rotation_point + new Vector2(Convert.ToSingle(Math.Cos(angle)), Convert.ToSingle(Math.Sin(angle))) * distance;
		position = rotation_point + (position - rotation_point).Rotated(angle);
		sprite = GetNode<Sprite>("Sprite");
		player_position();
	}
	
	public void player_movement()
	{
		angle = Convert.ToInt32((Input.IsActionPressed("rotate_right"))) - Convert.ToInt32((Input.IsActionPressed("rotate_left")));
		Vector2 rotate_direction = new Vector2(0, 0);
		var motion = rotate_direction.Normalized() * speed;
	}

	public void player_position()
	{
		sprite.Position = position;
	}
	*/
}
