﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNotes : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Note")
		{
			Destroy(col.gameObject);
		}

	}
}
