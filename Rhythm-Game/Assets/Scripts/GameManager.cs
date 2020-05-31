using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	int multiplier = 1;
	int combo = 0;
	int point_worth = 100;

    void Start()
    {
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.SetInt("HealthBar", 25);
    }


    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Win")
		{
			Win();
		}
		GetComponent<GameManager>().ResetCombo();	
	}

	public int GetScore()
	{
		return point_worth * multiplier;
	}

	public void AddCombo()
	{
		if(PlayerPrefs.GetInt("HealthBar") + 1 < 50)
		{
			PlayerPrefs.SetInt("HealthBar", PlayerPrefs.GetInt("HealthBar") + 1);
		}
		

		combo++;

		if (combo >= 50)
			multiplier = 8;
		else if (combo >= 40)
			multiplier = 4;
		else if (combo >= 30)
			multiplier = 3;
		else if (combo >= 20)
			multiplier = 2;
		else
			multiplier = 1;

		UpdateGUI();
	}

	public void ResetCombo()
	{

		PlayerPrefs.SetInt("HealthBar", PlayerPrefs.GetInt("HealthBar") - 2);


		combo = 0;
		multiplier = 1;

		UpdateGUI();

		if (PlayerPrefs.GetInt("HealthBar") < 0)
		{
			Lose();
		}
	}

	void Lose()
	{
		print("You Lose");
	}

	void Win()
	{
		print("You Win");
	}

	void UpdateGUI()
	{
		PlayerPrefs.SetInt("Combo", combo);
		PlayerPrefs.SetInt("Multiplier", multiplier);
	}
}
