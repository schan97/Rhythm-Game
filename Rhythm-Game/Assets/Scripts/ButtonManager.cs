using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public AudioSource songForLevel;

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

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void ResetHighScore()
	{
		PlayerPrefs.SetInt("HighScore", 0);
	}

	public void HoverSound()
	{
		songForLevel.Play();
	}

	public void LoadRolemusicw1x()
	{
		SceneManager.LoadScene("Rolemusic - w1x");
	}


}
