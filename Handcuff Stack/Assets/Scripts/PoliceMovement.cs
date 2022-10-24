using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{

    public float jumpSpeed, moveSpeed;
    public Rigidbody rb;



    //public GameObject lastObject;

    public int handcuffCount;
    
    

    [SerializeField] private List<GameObject> handcuffList = new List<GameObject>();

    public List<GameObject> criminalList = new List<GameObject>();

    void Start()
    {
        handcuffCount = 0;
        //handcuffList.Add(handcuffPositionFixer);
        criminalList.Add(gameObject);    
    }

    void Update()
    {
        Movement();
        if (handcuffCount < 0)
        {
            handcuffCount = 0;
        }
       
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            rb.velocity += Vector3.up * jumpSpeed;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "handcuff")
        {
            Debug.Log("aaaaaaaaaa");

            if (handcuffCount < 11)
            {
                HandcuffStack();
            }

            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Criminal" && handcuffCount > 1)
        {
            HandcuffCountDecrease();
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        }

        if (other.gameObject.tag == "HandcuffDecrease" && handcuffCount>1)
        {
            HandcuffCountDecrease();
        }

        if (other.gameObject.tag == "PoliceStation" && criminalList.Count>1 )
        {
            CriminalRelease();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Criminal")
        {
            Debug.Log("crrrrrrr");

            
        }
    }

    
        


    private void HandcuffStack()
    {
        handcuffList[handcuffCount].gameObject.SetActive(true);
        handcuffCount++;
    }
    private void HandcuffCountDecrease()
    {
        handcuffList[handcuffCount-1].gameObject.SetActive(false);
        handcuffCount--;
    }

    private void CriminalRelease()
    {
        criminalList[criminalList.Count - 1].gameObject.SetActive(false);
        criminalList.RemoveAt(criminalList.Count - 1);
        HandcuffStack();



    }


}


