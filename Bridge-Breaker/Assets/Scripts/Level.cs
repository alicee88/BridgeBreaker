using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int totalBlocks = 0;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBlock()
    {
        totalBlocks++;
    }

    public void RemoveBlock()
    {
        totalBlocks--;
        if(totalBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
