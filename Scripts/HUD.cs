using Godot;
using System;

public class HUD : CanvasLayer
{
	int score = 0;
	
	public override void _Ready()
	{
		
	}
	
	private void Game_Start()
	{
		Timer score_timer = new Timer();
		score_timer.Connect("timeout", this, "score_timer_test");
		score_timer.WaitTime = 1;
		AddChild(score_timer);
		score_timer.Start();
	}

	// This is just a test
	// I actually want the score to increase whenever the player hits the ball
	public void score_timer_test()
	{
		Label score_lab = GetNode<Label>("Score_Label");
		score += 1;
		score_lab.Text = Convert.ToString(score);
	}
}
