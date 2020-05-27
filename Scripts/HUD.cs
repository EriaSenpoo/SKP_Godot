using Godot;
using System;

public class HUD : CanvasLayer
{
	Timer score_timer = new Timer();
	int countdown = 3;
	bool sec3 = false;
	bool sec2 = false;
	bool sec1 = false;
	int score = 0;

	private void Game_Start()
	{
		Timer countdown_timer = GetTree().GetRoot().GetNode("Main").GetNode<Timer>("Countdown_Timer");
		Timer ball_timer = GetTree().GetRoot().GetNode("Main").GetNode<Timer>("Ball_Timer");
		RigidBody2D ball = GetTree().GetRoot().GetNode("Main").GetNode<RigidBody2D>("Ball");
		Button start_button = GetNode<Button>("Start_Button");
		score_timer.Connect("timeout", this, "score_timer_test");
		score_timer.WaitTime = 1;
		AddChild(score_timer);
		start_button.Hide();
		countdown_timer.Connect("timeout", this, "start_countdown");
		countdown_timer.OneShot = false;
		ball_timer.Connect("timeout", ball, "start_ball");
		ball_timer.Start();
		countdown_timer.Start();
	}

	public void start_countdown()
	{
		Timer countdown_timer = GetTree().GetRoot().GetNode("Main").GetNode<Timer>("Countdown_Timer");
		Label countdown_label = GetNode<Label>("Countdown_Label");

		if (countdown > 0)
		{
			if (!sec3)
			{
				countdown_label.Text = "3";
				sec3 = true;
			}
			else if (!sec2)
			{
				countdown_label.Text = "2";
				sec2 = true;
			}
			else if (!sec1)
			{
				countdown_label.Text = "1";
				sec1 = true;
			}
			else
			{
				countdown_timer.Stop();
				countdown_label.Text = "GO!";
				score_timer.Start();
			}
		}
	}



	// This is just a test
	// I actually want the score to increase whenever the player hits the ball
	public void score_timer_test()
	{
		Label countdown_label = GetNode<Label>("Countdown_Label");
		countdown_label.Hide();
		Label score_lab = GetNode<Label>("Score_Label");
		score += 1;
		score_lab.Text = Convert.ToString(score);
	}
}
