using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public CoconutShootingController csc;
    public float moveSpeed;
    public float turnSpeed;
    public GameObject explosionPrefab;
    public int scoreValue = 1;

    private void Start()
    {
        csc = FindObjectOfType<CoconutShootingController>();
    }

    private void FixedUpdate () 
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Coconut")
        {             
            GameObject go = Instantiate(explosionPrefab);
            go.transform.position = transform.position;
            csc.RemoveTarget(this);
            Destroy(gameObject);
        }
    }
}
