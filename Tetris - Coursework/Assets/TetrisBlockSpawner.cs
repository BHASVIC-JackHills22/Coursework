using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockSpawner : MonoBehaviour
{
    public GameObject JBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockSpawn()
    {
        Instantiate(JBlock, new Vector3(1, 7, 0), transform.rotation);
    }
}
