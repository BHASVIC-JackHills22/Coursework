using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockSpawning : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewTetromino()
    {
        //Instantiate(Tetrominoes[0], transform.position, Quaternion.identity);
        if (gameOver == false)
        {
            Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);
            if (!FindObjectOfType<BlockMovement>().ValidMove())
            {
                FindObjectOfType<LogicScript>().gameOver();
                gameOver = true;
            }
        }
    }

    public void Queue()
    {

    }
}
