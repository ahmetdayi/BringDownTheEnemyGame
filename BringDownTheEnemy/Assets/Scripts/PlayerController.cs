using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody playerRb;
    private GameObject middlePoint;//move the camera z position
    public bool hasPowerUp = false;
    private float powerForce = 10f;
    public GameObject powerUpIndicator;
    public bool isGameOver = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        middlePoint = GameObject.Find("Middle Point");
    }

   
    void Update()
    {
        float verticalValue = Input.GetAxis("Vertical");
        playerRb.AddForce(middlePoint.transform.forward*(verticalValue*moveSpeed));//move the camera z position
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if (hasPowerUp == true)
        {
            StartCoroutine(PowerUpCountDownRoutine());
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            isGameOver = true;
            powerUpIndicator.SetActive(false);
        }
    }

    IEnumerator PowerUpCountDownRoutine()//aldıgımız gucun 5 sanıye surmesını sagladık
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyPos = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(enemyPos*powerForce,ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp") )
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);

        }
    }
}
