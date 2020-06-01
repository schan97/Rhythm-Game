using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	int multiplier = 1;
	int combo = 0;
	int point_worth = 100;

	void Awake()
	{
		PlayerPrefs.SetInt("HealthBar", 25);
	}
    void Start()
    {
		PlayerPrefs.SetInt("HealthBar", 25);
		PlayerPrefs.SetInt("Score", 0);
		
		PlayerPrefs.SetInt("Combo", 0);
		PlayerPrefs.SetInt("HighCombo", 0);
		PlayerPrefs.SetInt("Multiplier", 1);
		PlayerPrefs.SetInt("NotesHit", 0);

		PlayerPrefs.SetInt("Start", 1);
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

		if (combo > PlayerPrefs.GetInt("HighCombo"))
			PlayerPrefs.SetInt("HighCombo", combo);

		PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);

		UpdateGUI();
	}

	public void ResetCombo()
	{

		PlayerPrefs.SetInt("HealthBar", PlayerPrefs.GetInt("HealthBar") - 2);


		combo = 0;
		multiplier = 1;

		UpdateGUI();

		if (PlayerPrefs.GetInt("HealthBar") < 1)
		{
			Lose();
		}
	}

	void Lose()
	{
		PlayerPrefs.SetInt("Start", 0);
		SceneManager.LoadScene("LoseScene");
		//print("You Lose");
	}

	void Win()
	{
		PlayerPrefs.SetInt("Start", 0);
		if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
			PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));

		SceneManager.LoadScene("WinScene");
		//print("You Win");
	}

	void UpdateGUI()
	{
		PlayerPrefs.SetInt("Combo", combo);
		PlayerPrefs.SetInt("Multiplier", multiplier);
	}
}
