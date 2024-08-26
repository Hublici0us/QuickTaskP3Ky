using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pausedGame;

    public Camera playerCamera;
    private AudioSource audioSource;

    public GameObject pauseScreen;
    public GameObject winScreen;
    private GameObject player;

    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        pausedGame = false;
        player = GameObject.Find("Player").gameObject;
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
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
        audioSource.pitch = 0.95f;
        audioSource.spatialBlend = 0.6f;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
        pausedGame=false;
        audioSource.pitch=1.0f;
    }

    public void win()
    {
        winScreen.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
    }

    public void BackToMainMenu()
    {

    }

    
}
