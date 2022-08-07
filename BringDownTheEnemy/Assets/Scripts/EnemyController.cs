using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection*speed);
        //normalized kullanarak sabit bir güç kullanmasını sağladık yoksa
        //düsman oyuncuya uzak olduğunda daha büyük bir güç uygular
    }
}
