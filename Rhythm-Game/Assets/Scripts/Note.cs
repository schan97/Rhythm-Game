﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
	Rigidbody2D rb;
	float speed;
	public float BPM;

	bool called = false;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		speed = BPM / 60 * 4;
	}

    void Start()
    {
		//rb.velocity = new Vector2(0, -speed);
    }


    void Update()
    {
		if(PlayerPrefs.GetInt("Start") == 1 && !called)
		{
			rb.velocity = new Vector2(0, -speed);
			called = true;
		}

		else if(PlayerPrefs.GetInt("Start") == 0 && called)
		{
			rb.velocity = new Vector2(0, 0);
			called = false;
		}
		
	}
}
