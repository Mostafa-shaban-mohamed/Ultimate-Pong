using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM_Manager : MonoBehaviour {

    public Button NewGame;
    public Button Exit;

	// Update is called once per frame
	void Update () {
        NewGame.onClick.AddListener(NewGameFn);
        Exit.onClick.AddListener(ExitFn);
	}
    void NewGameFn()
    {
        SceneManager.LoadScene("Gameplay_Scene");
    }
    void ExitFn()
    {
        Application.Quit();
    }
}
