using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float RotationSpeed;

	void Update () {
		transform.Rotate (0f, RotationSpeed * Time.deltaTime, 0f);
	}
}
