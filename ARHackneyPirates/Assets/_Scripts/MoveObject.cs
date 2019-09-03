using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	public float direction = 1f;

	void OnTriggerEnter (Collider col)
	{
		if (WaterfallGameController.isWaterfall) {
			col.transform.Translate (-transform.forward * direction * Time.deltaTime, Space.World);
		}
	}

	void OnTriggerStay (Collider col)
	{
		if (WaterfallGameController.isWaterfall) {
			col.transform.Translate (-transform.forward * direction * Time.deltaTime, Space.World);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
