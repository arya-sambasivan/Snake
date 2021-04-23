using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public int speed = 1;
    GameManager gameManagerInstance;
    
    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        
        CheckForInput();

        gameObject.transform.position += -transform.up * speed * Time.deltaTime;

    }
    public void CheckForInput()
    {
        float rotationAngle = gameManagerInstance.ControllerObject.GetComponent<SnakeDirectionController>().OutPut;
        
        gameObject.transform.Rotate(new Vector3(0, 0, -rotationAngle));
       
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.layer == 8)
        {
            Vector3 wallnormal = col.GetComponent<CellHandler>().getWallNormal();
            float angle = Vector3.SignedAngle(wallnormal, -transform.up,Vector3.forward);
            float rotationAngle = 180 - (2 * angle);
            gameObject.transform.Rotate(new Vector3(0, 0, rotationAngle));

        }
        if(col.gameObject.layer == 9)
        {
           
            gameManagerInstance.StartCoroutine(gameManagerInstance.reposPizzaObj(0,true));
            gameManagerInstance.UpdateScore();
        }
    }






}
