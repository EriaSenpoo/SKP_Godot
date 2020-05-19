using Godot;
using System;

public class Player : KinematicBody2D
{
	public override void _Ready()
	{
		sprite_collision();
	}
	
	public void sprite_collision()
	{
		Sprite sprite = GetNode<Sprite>("Sprite");
		int sprite_thickness = 35;
		Vector2 outer_sprite_size = sprite.Texture.GetSize();
		Vector2 inner_sprite_size = new Vector2(outer_sprite_size.x - sprite_thickness, outer_sprite_size.y - sprite_thickness);
		GD.Print("Outer sprite size: " + outer_sprite_size);
		GD.Print("Inner sprite size: " + inner_sprite_size);
		CollisionPolygon2D collision = GetNode<CollisionPolygon2D>("CollisionPolygon2D");
		
		
	}
}
