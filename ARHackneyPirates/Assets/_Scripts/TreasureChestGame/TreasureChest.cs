using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour 
{
    private Animator anim;

	private void Start() 
    {
        anim = GetComponent<Animator>();
	}       

    public void OpenChest()
    {
        anim.SetBool("isOpen", true);
    }

    public void CloseChest()
    {
        anim.SetBool("isOpen", false);
    }  
}
