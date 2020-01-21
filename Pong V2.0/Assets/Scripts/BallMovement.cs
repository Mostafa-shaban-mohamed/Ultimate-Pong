using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("startGame", 1.0f);
    }

    void startGame()
    {
        transform.position = new Vector2(0, 0);   //For more confirmation (making sure that it will always start there)
        int rand = Random.Range(2, 4);
        if (rand % 2 == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-4.0f, rand);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(4.0f, rand);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "scorewall_P")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().ENscore += 1;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().isGoal = true;
            Destroy(this.gameObject);
        }
        if (hit.gameObject.name == "scorewall_AI")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().Pscore += 1;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().isGoal = true;
            Destroy(this.gameObject);
        }
    }
}
