using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    BoxCollider2D colliderRef;
    SpriteRenderer cellRenderer;
    Vector3 cellNormal;
    void Awake()
    {
        colliderRef = GetComponent<BoxCollider2D>();
        cellRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame   
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("error");
        if(col.gameObject.layer == 6 && gameObject.layer !=8)
        {
            Debug.Log("error");
            colliderRef.enabled = false;
            cellRenderer.color = Color.green;
        }


    }
    public Vector3 getWallNormal()
    {
        //return Vector3.up;
        return cellNormal;
    }
    public void setWallNormal(Vector3 cellNorm)
    {
        cellNormal = cellNorm;
    }

}
