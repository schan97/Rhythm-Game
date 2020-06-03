using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPText : MonoBehaviour
{
	public string nameText;

    void Start()
    {

    }


    void Update()
    {
		GetComponent<Text>().text = PlayerPrefs.GetInt(nameText) + "";
    }
}
