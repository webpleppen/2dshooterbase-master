using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0) // Om spelaren trycker "SPACE" startar spelet
        {
            print("START");
            SceneManager.LoadScene(1); // Main-scenen
        }
    }
}
