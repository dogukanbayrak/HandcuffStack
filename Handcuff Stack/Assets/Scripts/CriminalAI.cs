using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CriminalAI : MonoBehaviour
{
    [SerializeField] PoliceMovement policeMovement;
    [SerializeField] private bool check=true;

    [Header("Nav Settings")]
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
       
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CriminalMovement();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && check)
        {
            Debug.Log("player temasý");
            policeMovement.criminalList.Add(gameObject);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && check)
        {
            check = false;

        }
    }

    void CriminalMovement()
    {
        navMeshAgent.destination = movePositionTransform.position;

        

    }



}
