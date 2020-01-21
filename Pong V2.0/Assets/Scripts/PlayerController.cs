using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float speed = 0.1f;
    float range = 3.8f;
    
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position; //position of player in 2D space

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().paused == true)
        {
            speed = 0;
        }
        else
        {
            speed = 0.1f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && pos.y < range)
        {
            pos.y += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && pos.y > (-1*range))
        {
            pos.y -= speed;
        }
        transform.position = pos;
	}
}
