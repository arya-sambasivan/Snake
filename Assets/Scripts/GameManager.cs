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
    void Start()
    {
        ArrangeGrid();
        SnakeController snakeObject = GameObject.Instantiate(snakprefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ArrangeGrid()
    {
        for(int i=0;i<gridSizeX;i++)
        {
            for(int j=0;j<gridSizeY;j++)
            {
                GameObject cell = GameObject.Instantiate(Cellprefab);
            

                float width = cell.GetComponent<SpriteRenderer>().bounds.size.x;
                float height = cell.GetComponent<SpriteRenderer>().bounds.size.y;
                Vector2 origin = new Vector2(0 - ((gridSizeX * width) / 2), 0 - ((gridSizeY * height) / 2));
                cell.transform.position = origin+new Vector2(width*i,height*j);
                cell.transform.parent = gridHolder.transform;
                if(i==0 || i == gridSizeX-1 || j == 0 || j == gridSizeY - 1)
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.black;
                    cell.layer = 8;
                    if(i==0)
                    {
                        cell.GetComponent<CellHandler>().setWallNormal(Vector3.right);
                    }
                    if(i==gridSizeX-1)
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
                
            }
        }

    }

}
