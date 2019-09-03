using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour 
{   	
	public Rigidbody objectRigidbody;
	public Transform ARCameraTransform;
	public float thrust;

    [SerializeField] Text correctText, incorrectText;
	public static bool isMaze = false;

    public void Correct()
    {
        StartCoroutine("CorrectEffect");
        correctText.enabled = true;
        incorrectText.enabled = false;
    }

    public void Incorrect()
    {
        StartCoroutine("IncorrectEffect");
        correctText.enabled = false;
        incorrectText.enabled = true;
    }

    IEnumerator CorrectEffect()
    {
        yield return new WaitForSeconds(3f);
        correctText.enabled = false;
    }

    IEnumerator IncorrectEffect()
    {
        yield return new WaitForSeconds(1f);
        incorrectText.enabled = false;
    }

	void FixedUpdate () {
		if (MazeController.isMaze) {
			objectRigidbody.AddForce (ARCameraTransform.forward * thrust);
			objectRigidbody.isKinematic = false;
		} else {
			objectRigidbody.isKinematic = true;
		}
	}
}
