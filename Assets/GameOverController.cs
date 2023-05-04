using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    void Update()
    {
        print("GAMEOVER");

        if(Input.GetAxisRaw("Fire1") > 0)
        {
            print(" GO TO START");
            SceneManager.LoadScene(0);
        }
    }
}
