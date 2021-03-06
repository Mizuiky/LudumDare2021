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
    public Transform initialPlayerPosition;
    public PuzzleManager puzzleManager;

    private PuzzleManager puzzle;

    private bool hasStartGame = false;
    // Start is called before the first frame update
    public void Start()
    {
        callMainMenu();
    }

    // Update is called once per frame
    public void Update()
    {
       
    }

    public void startGame()
    {
        this.hasStartGame = true;
        this.mainMenuScreen.SetActive(false);
        this.manager.Stop("menu");
        this.manager.Play("Puzzle1");
        this.tutorialScreen.SetActive(true);
        StartCoroutine("startSnow");
    }

    public void gameOver()
    {
        this.manager.Stop("Puzzle1");
        this.tutorialScreen.SetActive(false);
        this.gameOverScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("fail");
    }

    public void victory()
    {
        this.tutorialScreen.SetActive(false);
        this.manager.Stop("Puzzle1");
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
        Debug.Log("call menu");
        this.manager.Play("menu");
        this.mainMenuScreen.SetActive(true);   
        this.gameOverScreen.SetActive(false);
        this.victoryScreen.SetActive(false);
    }

    public void resetGame()
    {
        this.puzzleManager.changeTile(TileType.Ice);
        this.puzzleManager.showTiles();
        this.player.transform.position = this.initialPlayerPosition.position;
        this.victoryScreen.SetActive(false);
        this.gameOverScreen.SetActive(false);
        this.tutorialScreen.SetActive(true);
        this.player.SetActive(true);
        this.manager.Stop("menu");
        this.manager.Stop("fail");
        this.manager.Stop("victoryBellsound");
        this.manager.Stop("victoryJjinglebell");
        this.manager.Play("Puzzle1");
        StartCoroutine("startSnow");
    }

    public IEnumerator startSnow()
    {
        this.puzzleManager.showItens();
        yield return new WaitForSeconds(1.6f);
        this.puzzleManager.changeTile(TileType.Snow);
        this.puzzleManager.hideItens();
        //this.puzzleManager.showItens();    
    }
}
