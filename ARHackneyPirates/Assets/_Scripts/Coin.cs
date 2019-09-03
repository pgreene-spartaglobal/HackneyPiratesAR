using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	private Rigidbody rb;

	public float shrinkScale = 5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform.localScale /= shrinkScale;
	}
	
	// Update is called once per frame
	void Update () {
//		if (WaterfallGameController.isWaterfall) {
//			rb.isKinematic = false;
//		} else {
//			rb.isKinematic = true;
//		}

		if (transform.position.y <= -7f)
		{
			Destroy (this.gameObject);
		}
	}
}
