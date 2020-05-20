using Godot;
using System;

public class Player : KinematicBody2D
{
	Sprite sprite;
	Vector2 position;
	Vector2 outer_sprite_size;
	Vector2 inner_sprite_size;
	CollisionPolygon2D collision;
	//int sprite_orientation = 360;
	int sprite_thickness = 35;
	
	public override void _Ready()
	{
		position = new Vector2(512, 300);
		sprite = GetNode<Sprite>("Sprite");
		collision = GetNode<CollisionPolygon2D>("CollisionPolygon2D");
		outer_sprite_size = sprite.Texture.GetSize();
		inner_sprite_size = new Vector2(outer_sprite_size.x - sprite_thickness, outer_sprite_size.y - sprite_thickness);
		player_position();
		_Draw();
	}
	
	public void player_position()
	{
		sprite.Position = position;
		
	}

	public override void _Draw()
	{
		Color cyan = Color.ColorN("Cyan");

		GD.Print("Outer sprite size: " + outer_sprite_size);
		GD.Print("Inner sprite size: " + inner_sprite_size);
		
		collision.Position = new Vector2(512, 300 - 215);
		//collision.Polygon = PoolVector2Array(); // PoolVector2Array doesn't exist for some reason
	}
}
