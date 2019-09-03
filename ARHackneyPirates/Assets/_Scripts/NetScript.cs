using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour {

	private WaterfallGameController gameController;

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Coin") {
			gameController.score++;
			Destroy (col.transform.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("Canvas").GetComponent<WaterfallGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
