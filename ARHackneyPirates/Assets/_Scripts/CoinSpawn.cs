using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour {

	public GameObject coin;

	private float timer = 0f;
	[SerializeField] private float minX, maxX;

	public BoatGameController gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 1f && gameController.gameTimer >= 3f) {
			timer = 0f;
			float randomX = Random.Range (minX, maxX);
			Vector3 spawnPos = new Vector3 (randomX, transform.position.y, transform.position.z);
			GameObject go = Instantiate (coin, spawnPos, transform.rotation);
			go.GetComponent<Rigidbody> ().useGravity = false;
			go.GetComponent<Move> ().direction = Vector3.up;
			go.GetComponent<Move> ().speed = -1f;
			go.transform.parent = transform;				
		}		
	}
}
