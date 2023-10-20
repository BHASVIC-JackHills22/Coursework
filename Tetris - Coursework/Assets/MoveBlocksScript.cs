using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float timeSinceMove;
    private bool leftCollider = false;
    private bool rightCollider = false;
    private bool bottomCollider = false;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && leftCollider == false && bottomCollider == false)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    private void moveRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && rightCollider == false && bottomCollider == false)
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    private void moveDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && bottomCollider == false)
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }

    private void autoMoveDown()
    {
        
        if (Time.time - timeSinceMove >= 1.25 && bottomCollider == false)
        {
            transform.position += new Vector3(0, -1, 0);
            timeSinceMove = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "LeftWall")
        {
            leftCollider = true;
        }

        if (collision.gameObject.tag == "RightWall")
        {
            rightCollider = true;
        }

        if (collision.gameObject.tag == "BottomWall")
        {
            bottomCollider = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            leftCollider = false;
        }

        else if (collision.gameObject.tag == "RightWall")
        {
            rightCollider = false;
        }

        else if (collision.gameObject.tag == "BottomWall")
        {
            bottomCollider = false;
        }
    }
}
