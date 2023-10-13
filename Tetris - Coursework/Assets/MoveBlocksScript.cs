using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        float myTime = (float)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveLeft();
        autoMoveDown();
    }

    private void moveLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    private void autoMoveDown()
    {
        
        if (Time.time >= 1.25)
        {
            transform.position += new Vector3(0, -1, 0);
            frames = 0;
            myTime = Time.time - myTime;
        }
        else
        {
            
        }
    }
}
