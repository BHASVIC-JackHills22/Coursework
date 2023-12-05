using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionScript : MonoBehaviour
{
    private bool leftCollider = false;
    private bool rightCollider = false;
    private bool bottomCollider = false;
    private bool blockCollider = false;
    public TetrisBlockSpawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool LeftWallCollision()
    {
        if (leftCollider == false && bottomCollider == false)
        {
            return false;
        }
        return true;
    }

    public bool RightWallCollision()
    {
       if (rightCollider == false && bottomCollider == false)
        {
            return false;
        }
       return true;
    }

    public bool BottomWallCollision()
    {
        if (bottomCollider == false)
        {
            return false;
        }
        return true;
    }

    public void BlockCollision()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
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
            spawn.BlockSpawn();
        }

        else if (collision.gameObject.tag == "TetrisBlock")
        {
            blockCollider = true;
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

        else if (collision.gameObject.tag == "TetrisBlock")
        {
            blockCollider = false;
        }
    }
}
