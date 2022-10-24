using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class CriminalAI : MonoBehaviour
{
    [SerializeField] PoliceMovement policeMovement;
    [SerializeField] private bool check=true;

    [SerializeField] private bool movementCheck = false;


    public GameObject destinationnn,target;

    Vector3 position;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
       
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {

        

        if (movementCheck)
        {
            CriminalMovement();
        }
    }


   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && check && policeMovement.handcuffCount>0)
        {
            Debug.Log("sadasdasdasd");

            policeMovement.criminalList.Add(gameObject);
            

            check = false;
            movementCheck = true;

            target = policeMovement.criminalList[policeMovement.criminalList.Count - 2].gameObject;

            destinationnn = target;


            position = target.transform.position;

        }
        
    }







    

    public void CriminalMovement()
    {
        destinationnn = target;
        position = target.transform.position;
        navMeshAgent.destination = position;


    }



}
