using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
    
    void Update()
    {
      if(Input.GetAxisRaw("Fire1") > 0) // Om spelaren trycker på "SPACE" när den har vunnit:
        {
            print("WIN");
            SceneManager.LoadScene(0); // led spelaren till start-scenen där spelaren kan börja om
        }  
    }
}
