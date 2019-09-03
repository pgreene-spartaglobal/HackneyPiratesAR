using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBChest : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject VBButtonChest;
	VirtualButtonBehaviour VBBehaviour;

	public GameObject chestOpen, chestClose;

	void Start () {
		VBButtonChest.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		chestOpen.SetActive (true);
		chestClose.SetActive (false);
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		chestOpen.SetActive (false);
		chestClose.SetActive (true);
	}
}


