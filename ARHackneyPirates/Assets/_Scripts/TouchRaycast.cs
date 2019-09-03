using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRaycast : MonoBehaviour 
{
    //[SerializeField] private Camera cam;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Text debugText;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private int touchLayer = 8; // User Layer 8: TouchRaycast
    private int layerMask;

    private void Start()
    {
        //cam = GetComponent<Camera>();       
        layerMask = 1 << touchLayer; // 1 bit shifted left by an amount equal to the layer that we are looking for. An AND operation is performed to check if the layers match
    }

	private void Update() 
    {
        for (int i = 0; i < Input.touchCount; i++) 
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began) 
            {                
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit, 100, layerMask)) 
                {
                    //hit.transform.gameObject // The game object hit by the ray 
                    cursor.transform.position = hit.point; // Moving the cursor object to the hit position
                    debugText.text = "Hit point: " + hit.point.ToString();
                }
            }
        }
	}    
}
