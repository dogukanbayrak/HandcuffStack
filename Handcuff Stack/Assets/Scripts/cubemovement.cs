using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using DG.Tweening;


public class cubemovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public float jumpForce;
    public float stackTime;
    public Transform hedef;


    [Header("Instantiate")]
    [SerializeField] private GameObject cubePrefab;
    public GameObject newStackable;
    [SerializeField] private float offset;
    [SerializeField] private Vector3 stackVector;



    void Start()
    {

        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

        stackVector = new Vector3(transform.position.x, hedef.transform.position.y + offset, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("stackable"))
        {
            Debug.Log("debug");
            
            //other.gameObject.transform.DOMove(new Vector3(hedef.transform.position.x, hedef.transform.position.y + offset, hedef.transform.position.z), stackTime).OnComplete(() =>
            //other.gameObject.transform.DOMove(stackVector, stackTime).OnComplete(() =>

            //{
            //    Destroy(other.gameObject);
            //    CreateStackableObject();
            //}
            //);
            other.gameObject.transform.DOMove(new Vector3(transform.position.x, hedef.transform.position.y/2 + offset, transform.position.z), stackTime).OnComplete(() =>

            {
                other.gameObject.transform.DOMove(stackVector, stackTime/2).OnComplete(() =>

                {
                    Destroy(other.gameObject);
                    CreateStackableObject();
                }
            );
            }
            );

        }
    }



    void CreateStackableObject()
    {
        newStackable = Instantiate(cubePrefab, new Vector3(hedef.transform.position.x, hedef.transform.position.y + offset, hedef.transform.position.z), Quaternion.identity);
        newStackable.transform.parent=gameObject.transform;
        hedef = newStackable.transform;

    }
}
