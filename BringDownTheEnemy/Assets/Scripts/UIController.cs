using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private PlayerController _playerController;
    public GameObject gameOverImage;
    void Start()
    {
        _playerController = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isGameOver == true)
        {
            gameOverImage.SetActive(true);
        }
    }

    public void RestartBtn()
    {
        
        StartCoroutine(RestartGameRoutine());
    }

    public void MenuBtn()
    {
       
        SceneManager.LoadScene("Scenes/MenuScene");
    }
    IEnumerator RestartGameRoutine()
    {
        gameOverImage.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/GameScene");
    }
}
