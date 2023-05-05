using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;


    [SerializeField]
    GameObject explosionPrefab;


    [SerializeField]
     int health = 300;

     [SerializeField]
     Slider healthMeter;



    public float speedX = 2f; // the speed at which the boss moves left and right
    public float minX = -6f; // the minimum x position the boss can move to
    public float maxX = 6f; // the maximum x position the boss can move to
    public float targetY = 4f; // the y position the boss will move to before starting to move left and right

    private bool reachedTargetY = false; // flag to track if the boss has reached the target y position


    void Start()
    {
         // Find the BossSlider GameObject by name and retrieve its slider component
    Slider bossSlider = GameObject.Find("BossSlider").GetComponent<Slider>();

    // Set the maximum value of the slider to the initial health value
    bossSlider.maxValue = health;

    // Set the current value of the slider to the initial health value
    bossSlider.value = health;

    // Assign the slider component to the healthMeter field
    healthMeter = bossSlider;
    }
    
    void Update()
    {
         if (!reachedTargetY)
        {
            // if the boss hasn't reached the target y position yet, move it downwards
            transform.position += Vector3.down * speed * Time.deltaTime;
            
            // check if the boss has reached the target y position yet
            if (transform.position.y <= targetY)
            {
                reachedTargetY = true;
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
            }
        }
        else
        {
            // if the boss has reached the target y position, move it left and right
            float newX = Mathf.PingPong(Time.time * speedX, maxX - minX) + minX;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shot") // Om bosssen träffas av ett skott:
        {
            health--; // minskar bossens liv
            healthMeter.value = health; // och minskar samma värde i healthMätaren

            if (health == 0) // Om bossen har noll liv kvar:
            {
              Destroy(this.gameObject); // ska bossen försvinna samt skapa en explosion
              Instantiate(explosionPrefab, transform.position, Quaternion.identity);
              SceneManager.LoadScene(4); // spelaren ska sedan ledas till den sista scenen; vinnar-scenen    
            }
        }
    }
}
