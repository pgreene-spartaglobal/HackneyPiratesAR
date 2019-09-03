using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Penguin : MonoBehaviour 
{
    NavMeshAgent navMeshAgent;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private int touchLayer = 8; // User Layer 8: TouchRaycast
    private int layerMask;

    private Animator anim;
    private bool sliding;

    private PenguinGameController pgc;

    private void Start()
    {
        pgc = FindObjectOfType<PenguinGameController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        layerMask = 1 << touchLayer; // 1 bit shifted left by an amount equal to the layer that we are looking for. An AND operation is performed to check if the layers match
    }

    private void Update()
    {

        if (Input.GetButtonDown ("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

        for (int i = 0; i < Input.touchCount; i++) 
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began) 
            {                
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit, 100, layerMask)) 
                {
                    navMeshAgent.SetDestination(hit.point);
                }
            }
        }

        if (navMeshAgent.remainingDistance >= 1f)
        {
            sliding = true;
        }
        else
        {
            sliding = false;
        }

        Animating();

    }

    private void Animating()
    {
        anim.SetBool("Sliding", sliding);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            if (col.tag == "Coin") {
                Destroy (col.gameObject);
                pgc.IncreaseScore();
                pgc.SpawnCoin();
            }
        }
    }
}

