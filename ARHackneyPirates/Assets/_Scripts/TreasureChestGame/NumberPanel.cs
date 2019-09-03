using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPanel : MonoBehaviour {

	public int currentNumber;
	public Text numberText;
	[SerializeField] private LockController lc;

	[SerializeField] private Transform lockDisc;
	[SerializeField] private Quaternion target;
	[SerializeField] private Vector3 lockDiscRotation;
	[SerializeField] private float speed = 1f;

	float t = 0f;


	void Start () {
		lc = GetComponentInParent<LockController> ();
		RandomiseNumber ();
	}

	void Update () {
		Debug.Log (Time.deltaTime * speed);
		lockDisc.rotation = Quaternion.Slerp(lockDisc.rotation, target, Time.deltaTime * speed);
	}

	public void RandomiseNumber () {
		currentNumber = Random.Range (0, 9);
		numberText.text = currentNumber.ToString ();
	}

	public void IncreaseNumber () {
		if (currentNumber == 9) {
			currentNumber = 0;
		} else {
			currentNumber++;
		}

		numberText.text = currentNumber.ToString();

		//target = Quaternion.Euler(lockDisc.rotation.eulerAngles.x - 35f, 0, 0);
		target.eulerAngles = new Vector3 (lockDisc.rotation.eulerAngles.x - 35f, 0f, 0f);
		Debug.Log (target.eulerAngles);

		lc.CheckCombination ();
	}

	public void DecreaseNumber () {
		if (currentNumber == 0) {
			currentNumber = 9;
		} else {
			currentNumber--;
		}

		numberText.text = currentNumber.ToString();

		//target = Quaternion.Euler(lockDisc.rotation.eulerAngles.x + 35f, 0, 0);
		target.eulerAngles = new Vector3 (lockDisc.rotation.eulerAngles.x + 35f, 0f, 0f);
		Debug.Log (target.eulerAngles);

		lc.CheckCombination ();
	}

//	IEnumerator RotateLockDisk()
//	{
//		lockDisc.rotation = Quaternion.Slerp(lockDisc.rotation, target, Time.deltaTime * speed);
//	}
}
