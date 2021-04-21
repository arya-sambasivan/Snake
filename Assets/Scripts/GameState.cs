using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    
    [SerializeField] GameObject gameStateButton;
    GameManager gameManagerInstance;
    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }
    public void ChangeGameState()
    {
        if(gameManagerInstance.getCurrentGameStatus() == GameStatus.STARTED)
        {
            gameStateButton.transform.Find("Text").GetComponent<Text>().text = "Pause";
            GameStart();
        }
       else if(gameManagerInstance.getCurrentGameStatus() == GameStatus.GAMEPLAY)
        {
            gameStateButton.transform.Find("Text").GetComponent<Text>().text = "Resume";
            GamePause();
        }
        else if(gameManagerInstance.getCurrentGameStatus() == GameStatus.PAUSED)
        {
            gameStateButton.transform.Find("Text").GetComponent<Text>().text = "Pause";
            GameResume();
        }
    }

    private void GameStart()
    {
        gameManagerInstance.StartGame();
        gameManagerInstance.setCurrentGameState(GameStatus.GAMEPLAY);
        
    }
    private void GamePause()
    {
        Debug.Log("buttonClicked for Pause");
        Time.timeScale = 0f;
        gameManagerInstance.setCurrentGameState(GameStatus.PAUSED);
    }
    private void GameResume()
    {
        Debug.Log("buttonClicked for Resume");
        Time.timeScale = 1f;
        gameManagerInstance.setCurrentGameState(GameStatus.GAMEPLAY);
    }
}
