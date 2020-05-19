using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private int numOfBLocks = 0;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        numOfBLocks = getNumOfBlocks();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private int getNumOfBlocks()
    {
        int blockCount = GameObject.FindObjectsOfType<Block>().Length;
        return blockCount;
    }

    public void BlockWasBroken()
    {
        numOfBLocks -= 1;
        if (numOfBLocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
