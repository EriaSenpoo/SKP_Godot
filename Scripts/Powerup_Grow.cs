using Godot;
using System;

public class Powerup_Grow : Area2D
{
	int new_player_counter = 0;

	private void when_entered(object body)
	{
		// ---------- CallDeferred() will call a method whenever it's safe to do so ---------- \\
		// If I didn't use this function then I'd get 100 errors per collision.
		new_player_counter += 1;
		if (new_player_counter <= 1)
		{
			CallDeferred("spawn_new_player");
		}
	}

	public void spawn_new_player()
	{
		Node2D main_scene = (Node2D)GetTree().Root.GetNode("Main");
		Timer live_time = new Timer();
		live_time.Connect("timeout", this, "remove_new_player");
		live_time.OneShot = true;
		live_time.WaitTime = 10;
		main_scene.AddChild(live_time);
		live_time.Start();
		KinematicBody2D player = (KinematicBody2D)GetTree().Root.GetNode("Main").GetNode("Player");
		PackedScene player_scene = GD.Load<PackedScene>("res://Scenes/Player.tscn");
		KinematicBody2D new_player = (KinematicBody2D)player_scene.Instance();
		player.AddChild(new_player);
		new_player.Position = new Vector2(0, 0);
	}

	public void remove_new_player() // Maybe some UI that shows how much time is left on the powerup
	{
		KinematicBody2D player = (KinematicBody2D)GetTree().Root.GetNode("Main").GetNode("Player");
		player.GetChild(2).QueueFree();
		new_player_counter -= 1;
	}
}
