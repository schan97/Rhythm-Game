using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public AudioSource songForLevel;

	Scene currScene;

	void Awake()
	{
		currScene = SceneManager.GetActiveScene();
	}

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
		PlayerPrefs.SetInt("HighScore" + currScene.name, 0);
	}

	public void HoverSound()
	{
		songForLevel.Play();
	}

	public void HoverStop()
	{
		songForLevel.Stop();
	}

	public void LoadRolemusicw1x()
	{
		SceneManager.LoadScene("Rolemusic - w1x");
	}


}
