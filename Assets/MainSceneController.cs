using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    
    private float timer = 0f;
    private float switchTime = 25f; // hur många sekunder tills den byter till "BossScenen"


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= switchTime) // när den har nått anatalet sekunder till att byta scen:
        {
            SceneManager.LoadScene(3); // så byter spelet scenen 
        }
    }
}
