using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool pausedGame;

    public GameObject soySauce;

    public Camera playerCamera;
    private AudioSource audioSource;

    public GameObject pauseScreen;
    public GameObject winScreen;
    public TextMeshProUGUI textlives;
    private PlayerController player;
    public GameObject playerSprite;
    public GameObject gameOver;

    public AudioClip winSound;
    public AudioClip blowUp;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(3);
        pausedGame = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("spawnSauce", 2, 0.5f);
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
        audioSource.PlayOneShot(blowUp);
        CancelInvoke("spawnSauce");
    }

    public void UpdateHealth(int lives)
    {
        textlives.text = "LIVES: " + lives;
    }
    public void BackToMainMenu()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        CancelInvoke("spawnSauce");
    }

    void spawnSauce()
    {
        Instantiate(soySauce, new Vector3(Random.Range(-22, 30), 45, 0), Quaternion.identity);
    }
}
