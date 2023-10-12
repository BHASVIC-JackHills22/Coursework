using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        
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
            //rigidbody2D.velocity = Vector2.(0,2);
        }
    }

    private void autoMoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
        //rigidbody2D.velocity = Vector2.(0,2);
    }
}
