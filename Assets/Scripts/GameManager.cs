using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public GameObject Cellprefab;
    public GameObject gridHolder;
    public SnakeController snakprefab;
    [SerializeField]GameObject pizzaSlizePrefab;
    GameObject pizzaSliceObject;
    List<GameObject> cellList = new List<GameObject>();
    [SerializeField] float excecutionTimeDelay = 2;
    IEnumerator coroutineForPizza;

    void Start()
    {
        ArrangeGrid();
        pizzaSliceObject = GameObject.Instantiate(pizzaSlizePrefab);
        coroutineForPizza = reposPizzaObj(0);
        StartCoroutine(coroutineForPizza);
        SnakeController snakeObject = GameObject.Instantiate(snakprefab);
        

    }

    // Update is called once per frame
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
            if(cellList.Count == 0)
            {
                GameObject.Destroy(pizzaSliceObject);
            }
        }

    }

    public IEnumerator reposPizzaObj(float pizzaTime,bool forceChange = false)
    {
        Debug.Log("keriiiii");
        if (cellList.Count>0)
        {
            int rand = Random.Range(0, cellList.Count);
            pizzaSliceObject.transform.position = cellList[rand].transform.position;
            Debug.Log("veendum keriiiilllllllaaaaaaaaa");
            if(forceChange)
            {
                StopCoroutine(coroutineForPizza);
            }
            yield return new WaitForSeconds(pizzaTime);
            Debug.Log("veendum keriiii");
            //StopCoroutine(coroutineForPizza);
            coroutineForPizza = reposPizzaObj(excecutionTimeDelay);
            StartCoroutine(coroutineForPizza);
        }
        else
        {
            GameObject.Destroy(pizzaSliceObject);
            yield return new WaitForSeconds(0);
            // GAME OVER>>>>>>>>>
        }
    }
    
}
