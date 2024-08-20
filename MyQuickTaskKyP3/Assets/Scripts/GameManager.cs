using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pausedGame;

    public Camera playerCamera;

    public GameObject pauseScreen;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pausedGame = false;
        player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausedGame)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);
        pausedGame=true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
        pausedGame=false;
    }

    public void BackToMainMenu()
    {

    }
}
