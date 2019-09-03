using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TestTrackable : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	public Rigidbody objectRigidbody;
	public Transform ARCameraTransform;
	public float thrust;

	bool isTracking;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		Time.timeScale = 0f;
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			// Do something
			print("Do something");
			isTracking = true;
			Time.timeScale = 1f;
		}
		else
		{
			// Stop something
			print("Stop something");
			isTracking = false;
			Time.timeScale = 0f;
		}
	}   

	void FixedUpdate () {
		if (MazeController.isMaze) {
			objectRigidbody.AddForce (ARCameraTransform.forward * thrust);
		}
	}

}
