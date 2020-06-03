using Godot;
using System;

public class Powerup_Grow : Area2D
{
	bool new_player_spawned = false;

	private void when_entered(object body)
	{
		// ---------- CallDeferred() will call a method whenever it's safe to do so ---------- \\
		// If I didn't use this function then I'd get 100 errors per collision.
		if (!new_player_spawned)
		{
			new_player_spawned = true;
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
		live_time.Name = "Grow_Live_Time";
		main_scene.AddChild(live_time);
		live_time.Start();
		KinematicBody2D player = (KinematicBody2D)GetTree().Root.GetNode("Main").GetNode("Player");
		PackedScene player_scene = GD.Load<PackedScene>("res://Scenes/Player.tscn");
		KinematicBody2D new_player = (KinematicBody2D)player_scene.Instance();
		player.AddChild(new_player);
		new_player.Position = new Vector2(0, 0);
		GD.Print(live_time.TimeLeft);
	}

	public void remove_new_player() // Maybe some UI that shows how much time is left on the powerup
	{
		GD.Print("aaaaaaaaaaa"); // timer doesn't fucking start only whenever it feels like it
		Timer live_time = (Timer)GetTree().Root.GetNode("Main").GetNode("Grow_Live_Time");
		KinematicBody2D player = (KinematicBody2D)GetTree().Root.GetNode("Main").GetNode("Player");
		//Godot.Collections.Array children = player.GetChildren();
		//for (int i = 2; i < player.GetChildCount(); i += 1)
		//{
		//	((KinematicBody2D)children[i]).QueueFree();
		//}
		//if (player.GetChildCount() >= 4 && player.GetChild(3) != null)
		//{
		//	player.GetChild(3).QueueFree();
		//}
		new_player_spawned = false;
		player.GetChild(2).QueueFree();
		live_time.QueueFree();
	}
}
