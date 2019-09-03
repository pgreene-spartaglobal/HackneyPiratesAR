using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float forceStrength = 500f;

    private void Start() 
    {
        GetComponent<Rigidbody>().AddForce (transform.forward * forceStrength);
        transform.rotation = Random.rotation;
        Destroy (gameObject, 3f);
    }
}
