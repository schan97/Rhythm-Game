using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	int multiplier = 1;
	int streak = 0;
	int point_worth = 10;

    void Start()
    {
		PlayerPrefs.SetInt("Score", 0);
    }


    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		GetComponent<GameManager>().ResetStreak();
	}

	public int GetScore()
	{
		return point_worth * multiplier;
	}

	public void AddStreak()
	{
		streak++;

		if (streak >= 50)
			multiplier = 8;
		else if (streak >= 40)
			multiplier = 4;
		else if (streak >= 30)
			multiplier = 3;
		else if (streak >= 20)
			multiplier = 2;
		else
			multiplier = 1;

		UpdateGUI();
	}

	public void ResetStreak()
	{
		streak = 0;
		multiplier = 1;

		UpdateGUI();
	}

	void UpdateGUI()
	{
		PlayerPrefs.SetInt("Streak", streak);
		PlayerPrefs.SetInt("Multiplier", multiplier);
	}
}
