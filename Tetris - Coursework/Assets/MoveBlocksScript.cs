using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float timeSinceMove;
    private bool colliderC = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        moveLeft();
        moveRight();
        moveDown();
        autoMoveDown();
    }

    private void moveLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && colliderC == true)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    private void moveRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    private void moveDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }

    private void autoMoveDown()
    {
        
        if (Time.time - timeSinceMove >= 1.25)
        {
            transform.position += new Vector3(0, -1, 0);
            timeSinceMove = Time.time;
        }
    }

    private void collisionDetection()
    {
        //if(Collision2D)
        colliderC = false;
    }
}
