using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

	float health;
	GameObject needle;
    void Start()
    {
		needle = transform.Find("Needle").gameObject;
    }

    void Update()
    {
		health = PlayerPrefs.GetInt("HealthBar");

		needle.transform.localPosition = new Vector3((health-25)/25, 0, 0);
	}
}
