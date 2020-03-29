using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausedMenu : MonoBehaviour {
    public bool pause = false;
    public GameObject pauseUI;
	// Use this for initialization
	void Start () {
        pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
	}
    public void resume()
    {
        pause = false;

    }
    public void restart()
    {
        pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }
}
