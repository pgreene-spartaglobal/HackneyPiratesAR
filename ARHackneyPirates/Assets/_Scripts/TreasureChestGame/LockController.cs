using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour {

	public NumberPanel[] numberPanels;
	[SerializeField] private string lockSolution;
	[SerializeField] private Text lockSolutionText;
	[SerializeField] private Text lockStatusText;
	[SerializeField] private bool isLockOpen = false;
    [SerializeField] private TreasureChest treasureChest;

	void Start () {

		numberPanels = GetComponentsInChildren<NumberPanel> ();

		for (int i = 0; i < numberPanels.Length; i++) {
			int randomNum = Random.Range (0, 10);
			lockSolution += randomNum.ToString ();
		}

		lockSolutionText.text = lockSolution;
	}

	public void CheckCombination () {
		for (int i = 0; i < numberPanels.Length; i++) {
			if (numberPanels [i].currentNumber.ToString() != lockSolution [i].ToString()) {
				CloseLock ();
				return;
			}
		}
		OpenLock ();
	}

	void OpenLock () {
		isLockOpen = true;
		lockStatusText.color = Color.green;
		lockStatusText.text = "OPEN";
        treasureChest.OpenChest();
	}

	void CloseLock () {
		isLockOpen = false;
		lockStatusText.color = Color.red;
		lockStatusText.text = "CLOSED";
        treasureChest.CloseChest();
	}
}
