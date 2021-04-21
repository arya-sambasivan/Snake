using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    STARTED = 0,
    PAUSED,
    GAMEPLAY,
    END
};
public class GameManager : MonoBehaviour
{
    public int gridSizeX = 20;
    public int gridSizeY = 20;
    [SerializeField] GameObject Cellprefab;
    [SerializeField] GameObject gridHolder;
    [SerializeField] SnakeController snakprefab;
    [SerializeField]GameObject pizzaSlizePrefab;
    GameObject pizzaSliceObject;
    List<GameObject> cellList = new List<GameObject>();
    [SerializeField] float excecutionTimeDelay = 2;
    IEnumerator coroutineForPizza;
    [SerializeField] Text scoreText;
    [SerializeField] Button gameStateButton;
    [SerializeField] GameObject gameEndUI;

    GameStatus currentGameStatus = GameStatus.STARTED;

    void Start()
    {
        FindObjectOfType<Canvas>().enabled = true;
    }
    public void StartGame()
    {
        ArrangeGrid();
        pizzaSliceObject = GameObject.Instantiate(pizzaSlizePrefab);
        coroutineForPizza = reposPizzaObj(0);
        StartCoroutine(coroutineForPizza);
        SnakeController snakeObject = GameObject.Instantiate(snakprefab);
        scoreText.text = "0";
    }

    void Update()
    {

    }
    private void ArrangeGrid()
    {
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                GameObject cell = GameObject.Instantiate(Cellprefab);


                float width = cell.GetComponent<SpriteRenderer>().bounds.size.x;
                float height = cell.GetComponent<SpriteRenderer>().bounds.size.y;
                Vector2 origin = new Vector2(0 - ((gridSizeX * width) / 2), 0 - ((gridSizeY * height) / 2));
                cell.transform.position = origin + new Vector2(width * i, height * j);
                cell.transform.parent = gridHolder.transform;
                if (i == 0 || i == gridSizeX - 1 || j == 0 || j == gridSizeY - 1)
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.black;
                    cell.layer = 8;
                    if (i == 0)
                    {
                        cell.GetComponent<CellHandler>().setWallNormal(Vector3.right);
                    }
                    if (i == gridSizeX - 1)
                    {
                        cell.GetComponent<CellHandler>().setWallNormal(Vector3.left);
                    }
                    if (j == 0)
                    {
                        cell.GetComponent<CellHandler>().setWallNormal(Vector3.up);
                    }
                    if (j == gridSizeY - 1)
                    {
                        cell.GetComponent<CellHandler>().setWallNormal(Vector3.down);
                    }

                }
                else
                {
                    cellList.Add(cell);
                }

            }
        }

    }

    public void removeCell(GameObject obj)
    {
        if (cellList.Contains(obj))
        {
            cellList.Remove(obj);
            if(pizzaSliceObject.transform.position == obj.transform.position)
            {
                coroutineForPizza = reposPizzaObj(excecutionTimeDelay,true);
                StartCoroutine(coroutineForPizza);
            }
            if(cellList.Count == 0)
            {
                GameObject.Destroy(pizzaSliceObject);
                coroutineForPizza = reposPizzaObj(excecutionTimeDelay,true);
                StartCoroutine(coroutineForPizza);
            }
        }

    }

    public IEnumerator reposPizzaObj(float pizzaTime,bool forceChange = false)
    {
        
        if (cellList.Count>0)
        {
            int rand = Random.Range(0, cellList.Count);
            pizzaSliceObject.transform.position = cellList[rand].transform.position;
            
            if(forceChange)
            {
                StopCoroutine(coroutineForPizza);
            }
            yield return new WaitForSeconds(pizzaTime);
            coroutineForPizza = reposPizzaObj(excecutionTimeDelay);
            StartCoroutine(coroutineForPizza);
        }
        else
        {
            // GAME OVER>>>>>>>>>

            GameObject.Destroy(pizzaSliceObject);
            gameEndUI.SetActive(true);
            currentGameStatus = GameStatus.END;
            gameStateButton.transform.Find("Text").GetComponent<Text>().text = "";
            yield return new WaitForSeconds(0);

        }
    }
    public void UpdateScore()
    {
        scoreText.text = System.Convert.ToString(int.Parse(scoreText.text) + 1);
    }

    public void setCurrentGameState(GameStatus status)
    {
        currentGameStatus = status;
    }
    public GameStatus getCurrentGameStatus()
    {
        return currentGameStatus;
    }
}
