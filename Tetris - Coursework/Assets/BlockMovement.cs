using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BlockMovement : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float timeSinceMove;
    private static float fallTime = 1f;    // 1f = 1 second
    private static float level = 1;
    private static float linesRemoved = 0;

    private float keyDelay = 0.1f;  
    private float timePassedLeft = 0f;
    private float timePassedRight = 0f;
    private float timePassedDown = 0f; 

    private static bool isStored = false;

    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    private static Transform[] storeGrid = new Transform[1];

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
        store();
        autoMoveDown();
        checkForLines();
        hardDrop();
    }

    private void moveLeft()
    {
        timePassedLeft += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && timePassedLeft >= keyDelay)
        {
                transform.position += new Vector3(-1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(-1, 0, 0);
            timePassedLeft = 0f;
        }
    }

    private void moveRight()
    {
        timePassedRight += Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && timePassedRight >= keyDelay)
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
            timePassedRight = 0f;
        }
    }

    private void moveDown()
    {
        timePassedDown += Time.deltaTime;
        if (Input.GetKey(KeyCode.S) && timePassedDown >= keyDelay)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
                transform.position -= new Vector3(0, -1, 0);
            timePassedDown = 0f;
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
        if (Time.time - timeSinceMove >= fallTime)
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

    private void store()
    {
        if (Input.GetKeyDown(KeyCode.C) && isStored == false)
        {
            isStored = true;
            gameObject.tag = "currentlyStored";
            storeGrid[1] = transform;
            transform.position = new Vector3(20, 15, 0);
            this.enabled = false;
            FindObjectOfType<BlockSpawning>().NewTetromino();
        }
        else if (Input.GetKeyDown(KeyCode.C) && isStored == false)
        {

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

    public bool ValidMove()
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
        linesRemoved += 1;
        FindObjectOfType<LogicScript>().addLines();
        FindObjectOfType<LogicScript>().addScore(500);
        Debug.Log(linesRemoved);
        levelIncrease();
        //FindObjectOfType<RemoveOldBlockScript>().reduceChildren();
    }

    private void levelIncrease()
    {
        if (linesRemoved >= 10)
        {
            level++;
            FindObjectOfType<LogicScript>().addLevel();
            linesRemoved = 0;
            Debug.Log("Level has been increased");
            reduceFallTime();
        }
    }

    public void reduceFallTime()
    {
        if (fallTime > 0.1f)
        {
            fallTime -= 0.1f;
            Debug.Log(fallTime);
        }
    }
}