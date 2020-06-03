using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPTextFloat : MonoBehaviour
{

	public string nameText;

    void Start()
    {
        
    }


    void Update()
    {
		GetComponent<Text>().text = PlayerPrefs.GetFloat(nameText) + "";
	}
}
