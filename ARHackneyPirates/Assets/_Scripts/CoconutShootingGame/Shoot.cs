using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float fireRate = 0.25f;
    private float nextFire;

    private void Update() 
    {
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) 
        {

            nextFire = Time.time + fireRate;

            GameObject go = Instantiate (projectilePrefab, transform);
            go.transform.position = projectileSpawn.transform.position;
            go.transform.rotation = projectileSpawn.transform.rotation;
        }
    }
}
