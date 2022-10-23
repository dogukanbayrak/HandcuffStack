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


    //[Header("Nav Settings")]
    //[SerializeField] private Transform movePositionTransform;

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

    // Update is called once per frame
    void Update()
    {

        

        if (movementCheck)
        {
            CriminalMovement();
        }
    }


   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && check)
        {
            Debug.Log("sadasdasdasd");

            policeMovement.criminalList.Add(gameObject);

            check = false;
            movementCheck = true;

            target = policeMovement.criminalList[policeMovement.criminalList.Count - 2].gameObject;

            destinationnn = target;

            //position = policeMovement.criminalList[policeMovement.criminalList.Count - 1].gameObject.transform.position;

            position = target.transform.position;


        }
        
    }







    

    public void CriminalMovement()
    {
        destinationnn = target;
        position = target.transform.position;
        navMeshAgent.destination = position;

        //Vector3 position = movePositionTransform.position;


    }



}
