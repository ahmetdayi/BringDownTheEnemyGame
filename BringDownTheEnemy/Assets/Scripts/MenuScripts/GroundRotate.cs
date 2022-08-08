using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundRotate : MonoBehaviour
{
    private float rotateSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*(rotateSpeed*Time.deltaTime),Space.World);
    }

    public void startBtn()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
}
