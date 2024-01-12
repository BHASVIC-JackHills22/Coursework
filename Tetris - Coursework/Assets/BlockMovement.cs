using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BlockMovement : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float timeSinceMove;
    //public Rigidbody2D rigidbody2D;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

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
        rotation();
        autoMoveDown();
        checkForLines();
        hardDrop();
        removeParent();
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

    private void hardDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            do
            {
                transform.position += new Vector3(0, -1, 0);
            }
            while (ValidMove());
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
            {
                transform.position -= new Vector3(0, -1, 0);
                addToGrid();
                this.enabled = false;
                FindObjectOfType<BlockSpawning>().NewTetromino();
            }
            timeSinceMove = Time.time;
        }
    }

    private void rotation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }
    }

    void addToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }

    private void checkForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (hasLine(i))
            {
                removeLine(i);
                rowDown(i);
            }
        }
    }

    bool hasLine(int i)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void removeLine(int i)
    {
        for (int x = 0; x < width; x++)
        {
            DestroyImmediate(grid[x, i].gameObject);
            grid[x, i] = null;
            //Debug.Log(transform.hierarchyCount);
        }
    }

    private void removeParent()
    {
        if (transform.hierarchyCount <= 1)
        {
            Destroy(gameObject);
            Debug.Log("It should have worked??");
        }
    }
    

    private void rowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}