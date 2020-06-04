using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayAgain()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void SelectSong()
	{
		SceneManager.LoadScene("SelectSong");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void ResetHighScore()
	{
		PlayerPrefs.SetInt("HighScore", 0);
	}
}
