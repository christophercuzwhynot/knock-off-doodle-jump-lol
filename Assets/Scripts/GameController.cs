using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //platform gameobject
    [Header("Platform Object")] public GameObject platform;
    //default position for platform
    float pos = 0;
    //Game over Canvas
    [Header("Game OVer UI Canvas Object")]
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++) {
            //Execute SpawnPlatforms
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        //Spawn platforms randomly on the X axis and place them on the Y axis every 2.5
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f ), Quaternion.identity);
        pos+=2.5f;
    }

    public void GameOver()
    {
        //Game Over Canvas is active
        gameOverCanvas.SetActive(true);
    }
}
 