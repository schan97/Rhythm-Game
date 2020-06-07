using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNotes : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col)
	{

		var renderers = col.gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach (var childRenderer in renderers)
		{
			childRenderer.enabled= true;
		}

		col.gameObject.GetComponent<SpriteRenderer>().enabled = true;


		for (int i = 0; i < col.gameObject.transform.childCount - 1; i++)
		{
			if (col.gameObject.transform.GetChild(i).transform.name == "Letter")
			{
				col.gameObject.transform.GetChild(i).transform.gameObject.SetActive(true);
			}
		}

	}

}
