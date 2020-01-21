using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour {

    float counter = 0.0f;

	// Update is called once per frame
	void Update () {
        if (counter < 4.0f)
        {
            counter += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
