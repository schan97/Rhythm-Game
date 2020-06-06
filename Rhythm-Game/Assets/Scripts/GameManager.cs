using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	int multiplier = 1;
	int combo = 0;
	int point_worth = 100;
	int point_good = 125;
	int point_perfect = 150;

	private AudioSource music;

	public GameObject resultsScreen;

	public GameObject background;
	public GameObject activatorSet;
	public GameObject beatMap;
	public GameObject deleteNotesCollider;

	void Awake()
	{
		PlayerPrefs.SetInt("HealthBar", 25);
	}
    void Start()
    {
		PlayerPrefs.SetInt("Start", 0);

		music = FindObjectOfType<AudioSource>();
		PlayerPrefs.SetString("MusicName", music.name);

		PlayerPrefs.SetInt("HealthBar", 25);
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.GetInt("HighScore", 0);
		
		PlayerPrefs.SetInt("Combo", 0);
		PlayerPrefs.SetInt("HighCombo", 0);
		PlayerPrefs.SetInt("Multiplier", 1);

		PlayerPrefs.SetInt("NotesHit", 0);

		PlayerPrefs.SetInt("TotalNotes", FindObjectsOfType<Note>().Length);
		
		PlayerPrefs.SetInt("NormalHits", 0);
		PlayerPrefs.SetInt("GoodHits", 0);
		PlayerPrefs.SetInt("PerfectHits", 0);
		PlayerPrefs.SetInt("MissHits", 0);

		PlayerPrefs.SetFloat("PercentHit", 0);
		PlayerPrefs.SetString("RankValue", "");


		//PlayerPrefs.SetInt("Start", 1);
	}


    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Win")
		{
			Results();
		}

		PlayerPrefs.SetInt("MissHits", PlayerPrefs.GetInt("MissHits") + 1);
		GetComponent<GameManager>().ResetCombo();	
	}

	public int GetScore()
	{
		PlayerPrefs.SetInt("NormalHits", PlayerPrefs.GetInt("NormalHits") + 1);
		return point_worth * multiplier;
	}

	public int GetScoreGood()
	{
		PlayerPrefs.SetInt("GoodHits", PlayerPrefs.GetInt("GoodHits") + 1);
		return point_good * multiplier;
	}

	public int GetScorePerfect()
	{
		PlayerPrefs.SetInt("PerfectHits", PlayerPrefs.GetInt("PerfectHits") + 1);
		return point_perfect * multiplier;
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
		if(PlayerPrefs.GetInt("Start") == 1)
		{
			PlayerPrefs.SetInt("HealthBar", PlayerPrefs.GetInt("HealthBar") - 2);
		}

		combo = 0;
		multiplier = 1;

		UpdateGUI();

		if (PlayerPrefs.GetInt("HealthBar") < 1)
		{
			Results();
			//Lose()
		}
	}

	void Results()
	{
		PlayerPrefs.SetInt("Start", 0);

		if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
			PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));

		music.Stop();

		float totalHit = PlayerPrefs.GetInt("NormalHits") + PlayerPrefs.GetInt("GoodHits") + PlayerPrefs.GetInt("PerfectHits");
		float percentHit = (totalHit / PlayerPrefs.GetInt("TotalNotes")) * 100f;
		percentHit = Mathf.Round(percentHit * 100) / 100f;


		PlayerPrefs.SetFloat("PercentHit", percentHit);

		string rankVal = "F";

		if(percentHit > 20)
		{
			rankVal = "D";
			if(percentHit > 35)
			{
				rankVal = "C";
				if (percentHit > 50)
				{
					rankVal = "B";
					if(percentHit > 80)
					{
						rankVal = "A";
						if(percentHit > 90)
						{
							rankVal = "S";
						}
					}
				}
			}
		}

		PlayerPrefs.SetString("RankValue", rankVal);

		resultsScreen.SetActive(true);
		background.SetActive(false);
		activatorSet.SetActive(false);
		beatMap.SetActive(false);
		//SceneManager.LoadScene("WinScene");
		//print("You Win");
	}

	void UpdateGUI()
	{
		PlayerPrefs.SetInt("Combo", combo);
		PlayerPrefs.SetInt("Multiplier", multiplier);
	}
}
