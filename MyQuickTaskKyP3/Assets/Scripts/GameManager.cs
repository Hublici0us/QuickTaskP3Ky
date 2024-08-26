using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pausedGame;

    public Camera playerCamera;
    private AudioSource audioSource;

    public GameObject pauseScreen;
    public GameObject winScreen;
    public TextMeshProUGUI lives;
    private PlayerController player;
    private GameObject playerSprite;

    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        pausedGame = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        playerSprite = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerCamera.transform.position = new Vector3(playerSprite.transform.position.x, playerSprite.transform.position.y + 7, -10);
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

    public void UpdateHealth()
    {
        lives.text = ("LIVES: " + player.lives);
    }
    public void BackToMainMenu()
    {

    }

    
}
