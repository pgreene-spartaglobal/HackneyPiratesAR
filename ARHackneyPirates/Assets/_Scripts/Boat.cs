using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	private float boundary = 8f;
	private float speed = 3f;

	public BoatGameController gameController;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Coin") {
			Destroy (col.gameObject);
			gameController.score++;
		}
	}
		

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float phoneX = Input.acceleration.x;

		Debug.Log (h);

		if (transform.localPosition.z <= -boundary && phoneX < 0f)
		{
			h = 0f;
			phoneX = 0f;
		}

		if (transform.localPosition.z >= boundary && phoneX > 0f)
		{
			h = 0f;
			phoneX = 0f;
		}



		transform.Translate (0, 0, h);
		transform.Translate(0, 0, phoneX * speed * Time.deltaTime);

	}
}
