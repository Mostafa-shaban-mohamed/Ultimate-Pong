using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    float[] delay = { 1.8f, 2.0f, 2.3f };   //get the diffculty [easy: 0.4   medium: 0.8    hard: 0.95  ] yet to be defined -------- !
    public float currentDelay;
	
	// Update is called once per frame
	void Update () {
        currentDelay = delay[GameObject.Find("SceneManger").GetComponent<Manager>().diffculty.value];
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, ball.transform.position.y), Time.deltaTime * currentDelay);
    }
}
