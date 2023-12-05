using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float timeSinceMove;
    public BlockCollisionScript collision;
    private bool Leftmove;
    private bool Rightmove;
    private bool Bottommove;


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
        Leftmove = collision.LeftWallCollision();
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Leftmove == false)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    private void moveRight()
    {
        Rightmove = collision.RightWallCollision();
        if (Input.GetKeyDown(KeyCode.RightArrow) && Rightmove == false)
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    private void moveDown()
    {
        Bottommove = collision.BottomWallCollision();
        if (Input.GetKeyDown(KeyCode.DownArrow) && Bottommove == false)
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }

    private void autoMoveDown()
    {
        Bottommove = collision.BottomWallCollision();
        if (Time.time - timeSinceMove >= 1.25 && Bottommove == false)
        {
            transform.position += new Vector3(0, -1, 0);
            timeSinceMove = Time.time;
        }
    } 
}
