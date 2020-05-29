using System.Collections;
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

    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
		actColor = sr.color;
	}


    void Update()
    {
		if(createMode)
		{
			if(Input.GetKeyDown(key))
			{
				Instantiate(createNote, transform.position, Quaternion.identity);
			}
		}

		else
		{
			if (Input.GetKeyDown(key))
				sr.color = new Color(0, 0, 0);

			if (Input.GetKeyUp(key))
				sr.color = actColor;

			if (Input.GetKeyDown(key) && active)
			{
				Destroy(note);
				AddScore();
				active = false;
			}
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		active = true;
		if (col.gameObject.tag == "Note")
			note = col.gameObject;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		active = false;
	}

	void AddScore()
	{
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
	}
}
