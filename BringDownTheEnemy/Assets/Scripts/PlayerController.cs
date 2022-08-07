using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Rigidbody playerRb;
    private GameObject middlePoint;//move the camera z position
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        middlePoint = GameObject.Find("Middle Point");
    }

   
    void Update()
    {
        float verticalValue = Input.GetAxis("Vertical");
        playerRb.AddForce(middlePoint.transform.forward*(verticalValue*moveSpeed));//move the camera z position
        
    }
}
