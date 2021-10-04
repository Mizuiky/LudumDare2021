using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject tutorialScreen;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public GameObject player;
    public AudioManager manager;

    private bool hasStartGame = false;
    // Start is called before the first frame update
    void Awake()
    {
        callMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void startGame()
    {
        this.hasStartGame = true;
        this.mainMenuScreen.SetActive(false);
        this.player.SetActive(true);
        this.manager.Play("Puzzle1");
        this.tutorialScreen.SetActive(true);
    }

    public void gameOver()
    {
        this.tutorialScreen.SetActive(false);
        this.gameOverScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("fail");
    }

    public void victory()
    {
        this.tutorialScreen.SetActive(false);
        this.manager.Play("victoryBellsound");
        this.manager.Play("victoryJjinglebell");
        this.victoryScreen.SetActive(true);

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void callMainMenu()
    {
        this.manager.Play("menu");
        this.player.SetActive(false);
        this.mainMenuScreen.SetActive(true);
        this.tutorialScreen.SetActive(false);     
        this.gameOverScreen.SetActive(false);
        this.victoryScreen.SetActive(false);
    }
}
