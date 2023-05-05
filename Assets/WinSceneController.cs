using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
     private float timer = 0f;
    private float switchTime = 10;

    void Update()
    {
      if(Input.GetAxisRaw("Fire1") > 0) // Om spelaren trycker på "SPACE" när den har vunnit:
        {
            print("WIN");
            SceneManager.LoadScene(0); // led spelaren till start-scenen där spelaren kan börja om
        }  

         timer += Time.deltaTime;

        if(timer >= switchTime) // när den har nått anatalet sekunder till att byta scen:
        {
            SceneManager.LoadScene(5); // så byter spelet scenen 
        }
    }
}
