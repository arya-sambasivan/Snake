using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public GameObject Cellprefab;
    public GameObject gridHolder;
    void Start()
    {
        ArrangeGrid();
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
            }
        }

    }

}
