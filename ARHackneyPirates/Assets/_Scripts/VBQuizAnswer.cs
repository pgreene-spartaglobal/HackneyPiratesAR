using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;


public class VBQuizAnswer : MonoBehaviour, IVirtualButtonEventHandler {

	public Text result;

	VirtualButtonBehaviour VBBehaviour;

	private bool answer1pressed = false;
	private bool answer2pressed = false;
	private bool answer3pressed = false;

	public bool answer1correct = false;
	public bool answer2correct = true;
	public bool answer3correct = false;

	private bool questionAnswered = false;

	private int chosenAnswer = 0;

	private float answer1value = 0f;
	private float answer2value = 0f;
	private float answer3value = 0f;

	public Text value1debug;
	public Text value2debug;
	public Text value3debug;


	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		if (vb.VirtualButtonName == "answer1") {
			result.text = "wrongLeft";
			answer1pressed = true;
		} else if (vb.VirtualButtonName == "answer2") {
			result.text = "correctMiddle";
			answer2pressed = true;
		} else if (vb.VirtualButtonName == "answer3") {
			result.text = "wrongRight";
			answer3pressed = true;
		}
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		if (vb.VirtualButtonName == "answer1") {
			answer1pressed = false;
		} else if (vb.VirtualButtonName == "answer2") {
			answer2pressed = false;
		} else if (vb.VirtualButtonName == "answer3") {
			answer3pressed = false;
		}
	}

	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			vbs [i].RegisterEventHandler (this);
		}
			
		result.text = "nothing";
	}
	
	// Update is called once per frame
	void Update () {
		if (!questionAnswered) {
			if (answer1pressed && answer1value < 3f) {
				answer1value += Time.deltaTime;
			} else if (!answer1pressed && answer1value > 0f) {
				answer1value -= Time.deltaTime;
			}

			if (answer2pressed && answer2value < 3f) {
				answer2value += Time.deltaTime;
			} else if (!answer2pressed && answer2value > 0f) {
				answer2value -= Time.deltaTime;
			}

			if (answer3pressed && answer3value < 3f) {
				answer3value += Time.deltaTime;
			} else if (!answer3pressed && answer3value > 0f) {
				answer3value -= Time.deltaTime;
			}
		}

		value1debug.text = "value1 = " + answer1value.ToString ();
		value2debug.text = "value2 = " + answer2value.ToString ();
		value3debug.text = "value3 = " + answer3value.ToString ();

		if (answer1value >= 3f || answer2value >= 3f || answer3value >= 3f) {
			questionAnswered = true;

			if (answer1value >= 3f) {
				chosenAnswer = 1;
			} else if (answer2value >= 3f) {
				chosenAnswer = 2;
			} else if (answer3value >= 3f) {
				chosenAnswer = 3;
			}

			CheckAnswer (chosenAnswer);


		}
	}

	void CheckAnswer(int answer)
	{
		if (answer1correct && chosenAnswer == answer) {

		} else if (!answer1correct && chosenAnswer == answer) {

		} else if (answer2correct && chosenAnswer == answer) {

		} else if (!answer2correct && chosenAnswer == answer) {

		} else if (answer3correct && chosenAnswer == answer) {

		} else if (!answer3correct && chosenAnswer == answer) {

		}
	}
}
