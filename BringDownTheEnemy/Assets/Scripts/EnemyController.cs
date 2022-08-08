using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 1f;
    private Rigidbody enemyRb;
    private GameObject player;
    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isGameOver == false)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection*speed);
            //normalized kullanarak sabit bir güç kullanmasını sağladık yoksa
            //düsman oyuncuya uzak olduğunda daha büyük bir güç uygular
        }

        if (enemyRb.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
