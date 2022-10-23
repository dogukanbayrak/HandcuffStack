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

            if (handcuffCount < 11                )
            {
                HandcuffStack();
            }

            Destroy(other.gameObject);

            //other.gameObject.transform.SetParent(transform);
            //other.gameObject.transform.localPosition = new Vector3(0f, handcuffList[handcuffList.Count - 1].transform.localPosition.y + 3f, 0f);

            //handcuffList.Add(other.gameObject);

        }

        if (other.gameObject.tag == "Criminal")
        {
            Debug.Log("crrrrrrr");

            //criminalList.Add(other.gameObject);


        }




        //if (other.gameObject.tag == "Criminal")
        //{
        //    Debug.Log("crrrrrrr");

        //    other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, criminalList[criminalList.Count - 1].transform.localPosition, moveSpeed);

        //    criminalList.Add(other.gameObject);

        //}



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Criminal")
        {
            Debug.Log("crrrrrrr");

            //collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position,criminalList[criminalList.Count - 1].transform.localPosition, 1f);;

            //criminalList.Add(collision.gameObject);
            
        }
    }

    
        


    private void HandcuffStack()
    {
        handcuffList[handcuffCount].gameObject.SetActive(true);
        handcuffCount++;
    }



}


