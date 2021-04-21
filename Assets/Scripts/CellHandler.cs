using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    BoxCollider2D colliderRef;
    SpriteRenderer cellRenderer;
    Vector3 cellNormal;
    GameManager gameManagerInstance;
    void Awake()
    {
        colliderRef = GetComponent<BoxCollider2D>();
        cellRenderer = GetComponent<SpriteRenderer>();
        gameManagerInstance = FindObjectOfType<GameManager>();
    }

    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
     
        if(col.gameObject.layer == 6 && gameObject.layer !=8)
        {
            colliderRef.enabled = false;
            cellRenderer.color = Color.green;
            gameManagerInstance.removeCell(gameObject);
        }


    }

    public Vector3 getWallNormal()
    {
        return cellNormal;
    }
    public void setWallNormal(Vector3 cellNorm)
    {
        cellNormal = cellNorm;
    }

}
