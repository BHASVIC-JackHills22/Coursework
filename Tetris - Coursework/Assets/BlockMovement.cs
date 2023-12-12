using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BlockMovement : MonoBehaviour
{
    private float timeSinceMove;
    //public Rigidbody2D rigidbody2D;
    public static int height = 20;
    public static int width = 10;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
    }

    private void moveRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }
    }

    private void moveDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
                transform.position -= new Vector3(0, -1, 0);
        }
    }

    private void autoMoveDown()
    {
        if (Time.time - timeSinceMove >= 1.25)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
                transform.position -= new Vector3(0, -1, 0);
            timeSinceMove = Time.time;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
        }
        return true;
    }
}
