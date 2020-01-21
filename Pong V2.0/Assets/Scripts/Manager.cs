using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public GameObject ball;
    public GameObject Menu;
    public GameObject StartGameMenu;
    public GameObject WinPlayerPanel;
    public GameObject WinAIPanel;

    public Button Cont;
    public Button play;
    public Button[] playAgain;
    public Button[] ReturnMainMenu;

    public Dropdown diffculty;
    public InputField MaxScoreField;

    public Text P_score;
    public Text En_score;

    public int Pscore = 0;
    public int ENscore = 0;
    public int MaxScore = 1;

    public bool isGoal = false;
    public bool paused = false;

    // Use this for initialization
    void Start () {
        isGoal = false;
        Menu.SetActive(false);   //no menu appears
        WinPlayerPanel.SetActive(false);     WinAIPanel.SetActive(false);
        Time.timeScale = 0.0f;   //Pause the game
        StartGameMenu.SetActive(true);
        play.onClick.AddListener(StartMenu);
    }
	
	// Update is called once per frame
	void Update () {
        P_score.text = "Score: " + Pscore;
        En_score.text = "Score: " + ENscore;
        //for pause menu fn
        pauseMenu();
        // to decide who win and show the winner's panel and restart the scene or go to main menu
        Win();
        //Exit button in pause menu
        ReturnMainMenu[2].onClick.AddListener(Application.Quit);
        //to appear and disappear the cursor of mouse
        if (Time.timeScale == 0f)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        //for creating new ball
        if (isGoal == true)
        {
            //create new ball & isGoal = false;
            isGoal = false;
            Instantiate(ball, this.transform.position, Quaternion.Euler(Vector3.zero));
        }
    }

    void pauseMenu()  
    {
        if (Input.GetKeyDown(KeyCode.Escape))     //on clicking on Escape the menu appears.
        {
            paused = !paused;
            togglePause();
            Menu.SetActive(paused);
        }
        else {
            //on clicking on continue button in the menu.
            Cont.onClick.AddListener(togglePause);
        }
    }

    void Win()
    {
        if (MaxScoreField.text == "")
        {
            MaxScore = 1;
        }
        else
        {
            MaxScore = Int32.Parse(MaxScoreField.text);
        }
        if (Pscore == MaxScore && ENscore < MaxScore)  //Player won
        {
            WinPlayerPanel.SetActive(true);  //Show the Panel "The player won"
            Time.timeScale = 0f;
            playAgain[0].onClick.AddListener(ReloadLevel);
            ReturnMainMenu[0].onClick.AddListener(GoToMM);
        }
        if (ENscore == MaxScore && Pscore < MaxScore)  //Player Lost
        {
            WinAIPanel.SetActive(true); //Show the Panel "The AI won"
            Time.timeScale = 0f;
            playAgain[1].onClick.AddListener(ReloadLevel);
            ReturnMainMenu[1].onClick.AddListener(GoToMM);
        }
    }

    void ReloadLevel()  //to reload the level
    {
        SceneManager.LoadScene("Gameplay_Scene");
    }

    void GoToMM()    //go to main menu
    {
        SceneManager.LoadScene("Main_Menu");
    }

    void StartMenu()
    {
        Time.timeScale = 1.0f;   //Pause the game
        StartGameMenu.SetActive(false);
    }

    void OnGUI()    //it has to be this function
    {
        if (paused)
        {
            Menu.SetActive(true);  //if paused is true.
        }
        else
        {
            Menu.SetActive(false); //if paused is false.
        }
    }

   void togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
        }
    }
}
