using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackStatus : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

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

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			isTracking = true;
			Time.timeScale = 1f;

			if (mTrackableBehaviour.TrackableName == "chips") {
				AllFalse ();
				MazeController.isMaze = true;
				Debug.Log ("maze on");
			}

			if (mTrackableBehaviour.TrackableName == "Astronaut") {
				AllFalse ();
				WaterfallGameController.isWaterfall = true;
				Debug.Log ("waterfall on");
			}


		}
		else
		{
			isTracking = false;
			Time.timeScale = 0f;
		}
	}  

	void AllFalse ()
	{
		WaterfallGameController.isWaterfall = false;
		MazeController.isMaze = false;
	}

}
