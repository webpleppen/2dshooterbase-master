using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    void Update()
    {
        print("GAMEOVER");

        if(Input.GetAxisRaw("Fire1") > 0) // Om spelaren trycker "SPACE" i GAMEOVER-scenen så startar denne om från början
        {
            print(" GO TO START");
            SceneManager.LoadScene(0); // Spelaren tas till start-scenen
        }
    }
}
