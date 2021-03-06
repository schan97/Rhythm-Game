﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

	public KeyCode key;
	bool active = false;
	GameObject note;

	Color actColor;
	SpriteRenderer sr;

	public bool createMode;
	public GameObject createNote;

	GameObject gm;

	public GameObject hitEffect, goodEffect, perfectEffect;

    void Start()
    {
		gm = GameObject.Find("GameManager");
		gm.GetComponent<GameManager>().ResetCombo();

		sr = GetComponent<SpriteRenderer>();
		actColor = sr.color;
	}


    void Update()
    {
		if(createMode)
		{	
			gm.GetComponent<GameManager>().deleteNotesCollider.SetActive(false);
			gm.GetComponent<Collider2D>().enabled = false;
			if (Input.GetKeyDown(key))
			{
				Instantiate(createNote, transform.position, Quaternion.identity);
			}
		}

		else
		{
			if (Input.GetKeyDown(key))
			{
				sr.color = new Color(0, 0, 0);
			}

			if (Input.GetKeyUp(key))
			{
				sr.color = actColor;
			}

			if (Input.GetKeyDown(key) && active)
			{
				Destroy(note);
				gm.GetComponent<GameManager>().AddCombo();
				active = false;

				if(Mathf.Abs(note.transform.position.y) > 0.5f)
				{
					AddScore();
					Instantiate(hitEffect, note.transform.position, hitEffect.transform.rotation);
				}

				else if (Mathf.Abs(note.transform.position.y) > 0.25f)
				{
					AddScoreGood();
					Instantiate(goodEffect, note.transform.position, goodEffect.transform.rotation);
				}

				else
				{
					AddScorePerfect();
					Instantiate(perfectEffect, note.transform.position, perfectEffect.transform.rotation);
				}


			}
			
			else if(Input.GetKeyDown(key) && !active)
			{
				gm.GetComponent<GameManager>().ResetCombo();
			}
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		active = true;
		if(col.gameObject.tag == "Note")
		{
			note = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		active = false;
		//gm.GetComponent<GameManager>().ResetStreak();
	}

	void AddScore()
	{
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore());
	}

	void AddScoreGood()
	{
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScoreGood());
	}

	void AddScorePerfect()
	{
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScorePerfect());
	}

}
