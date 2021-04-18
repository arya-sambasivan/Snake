using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public int speed = 1;
    public GameObject snakeModel;
    void Start()
    {
        //gameObject.transform.forward = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
       // gameObject.transform.position += -transform.up *speed *  Time.deltaTime;

    }
    public void CheckForInput()
    { 
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 45));
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -45));
        }
        
    }
    
}
