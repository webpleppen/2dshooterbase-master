using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
    
    void Update()
    {
      if(Input.GetAxisRaw("Fire1") > 0)
        {
            print("START");
            SceneManager.LoadScene(0);
        }  
    }
}
