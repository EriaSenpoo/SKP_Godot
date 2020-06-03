using Godot;
using System;

public class Main : Node2D
{
	int screen_width = 1024;
	int screen_height = 600;
	
	public override void _Ready()
	{
		Timer powerup_timer = new Timer();
		Timer powerup_destroyer = new Timer();
		powerup_timer.Name = "Powerup_Spawner";
		powerup_destroyer.Name = "Powerup_Remover";
		powerup_timer.Connect("timeout", this, "powerup_spawner");
		powerup_destroyer.Connect("timeout", this, "powerup_remover");
		powerup_timer.OneShot = false;
		powerup_destroyer.OneShot = false;
		powerup_timer.WaitTime = 5;
		powerup_destroyer.WaitTime = 10;
		AddChild(powerup_timer);
		AddChild(powerup_destroyer);
		powerup_timer.Start();
		powerup_destroyer.Start();
	}

	public void powerup_spawner()
	{
		// ---------- Load instances ---------- \\

		PackedScene ball_speed_up = GD.Load<PackedScene>("res://Scenes/Power-ups/Power-up_Ball_Speed_Up.tscn");
		PackedScene grow = GD.Load<PackedScene>("res://Scenes/Power-ups/Power-up_Grow.tscn");
		PackedScene player_slow = GD.Load<PackedScene>("res://Scenes/Power-ups/Power-up_Player_Slow.tscn");

		// ---------- Positions ---------- \\
		
		// Later on I might want to add a proper random position system to make it more professional
		// such as a random position within a given area

		Vector2 powerup_pos0 = new Vector2(660, 300);
		Vector2 powerup_pos1 = new Vector2(450, 200);
		Vector2 powerup_pos2 = new Vector2(430, 290);
		Vector2 powerup_pos3 = new Vector2(500, 300);
		Vector2 powerup_pos4 = new Vector2(570, 180);
		Vector2 powerup_pos5 = new Vector2(500, 150);
		Vector2 powerup_pos6 = new Vector2(440, 410);
		Vector2 powerup_pos7 = new Vector2(500, 390);
		Vector2 powerup_pos8 = new Vector2(570, 400);
		Vector2 powerup_pos9 = new Vector2(480, 370);

		// ---------- Instancing the scenes ---------- \\

		Area2D powerup_ball_speed_up = (Area2D)ball_speed_up.Instance();
		Area2D powerup_grow = (Area2D)grow.Instance();
		Area2D powerup_player_slow = (Area2D)player_slow.Instance();

		// ---------- Randomizing numbers ---------- \\

		Random powerup_picker = new Random();
		var powerup_picker_odds = powerup_picker.Next(0, 3);

		Random powerup_position = new Random();
		var powerup_position_odds = powerup_position.Next(0, 9);

		Area2D powerup_type = new Area2D();
		Node2D all_powerups = (Node2D)GetNode("Powerups");

		// ---------- Powerup picker, applying randomized numbers ---------- \\

		switch (powerup_picker_odds)
		{
			case 0:
				all_powerups.AddChild(powerup_ball_speed_up);
				powerup_type = powerup_ball_speed_up;
				break;
			case 1:
				all_powerups.AddChild(powerup_grow);
				powerup_type = powerup_grow;
				break;
			case 2:
				all_powerups.AddChild(powerup_player_slow);
				powerup_type = powerup_player_slow;
				break;
			default:
				GD.Print("Error: Main, powerup_picker_odds, powerup not found.");
				break;
		}

		// ---------- Powerup positions, applying randomized numbers ---------- \\

		switch (powerup_position_odds)
		{
			case 0:
				powerup_type.Position = powerup_pos0;
				break;
			case 1:
				powerup_type.Position = powerup_pos1;
				break;
			case 2:
				powerup_type.Position = powerup_pos2;
				break;
			case 3:
				powerup_type.Position = powerup_pos3;
				break;
			case 4:
				powerup_type.Position = powerup_pos4;
				break;
			case 5:
				powerup_type.Position = powerup_pos5;
				break;
			case 6:
				powerup_type.Position = powerup_pos6;
				break;
			case 7:
				powerup_type.Position = powerup_pos7;
				break;
			case 8:
				powerup_type.Position = powerup_pos8;
				break;
			case 9:
				powerup_type.Position = powerup_pos9;
				break;
			default:
				GD.Print("Error: Main, powerup_position_odds, powerup_type or Position not found.");
				break;
		}
	}

	public void powerup_remover()
	{

		Node2D all_powerups = (Node2D)GetNode("Powerups");
		for (int i = 0; i < all_powerups.GetChildCount(); i += 1)
		{
			all_powerups.GetChild(i).QueueFree();
		}
	}
}
