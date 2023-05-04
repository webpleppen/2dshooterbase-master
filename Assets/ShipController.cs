using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    int health = 5;

    [SerializeField]
    Slider healthMeter;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunTransform;

    float shootTimer = 0;
    
    [SerializeField]
    float timeBetweenShots = 0.5f;

   
    void Start()
    {
        healthMeter.maxValue = health; // Startar spelet med skeppets healthMätare med maxLiv
        healthMeter.value = health; // Säger att healthMätares värde är maxvärdet på liv

    }

    // Update is called once per frame
    void Update()
    {
        // 30fps = 30*0.02 = 0.6
        // 60fps = 60*0.02 = 1.2
        // 120fps = 120*0.02 = 2.4

        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xMove, yMove) * speed * Time.deltaTime;

        transform.Translate(movement);

        shootTimer += Time.deltaTime;

        if(Input.GetAxisRaw("Fire1") > 0 && shootTimer > timeBetweenShots) // Om "Fire1" i detta fall "SPACE" trycks på:
        {
        Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity); // Ska skott avfyras, samt "gun" ska följa efter skeppets nya position
        shootTimer = 0;
        }

        

        if (transform.position.y >= 4.9f) // Om y-positionen på skeppet är mer eller lika med 4.9 frames i "Main Cameran":
        {
            transform.position = new Vector3(transform.position.x, 4.9f, 0); // Behåll den på samma y-position för att inte låta den överstiga mappens gränser.
        }
        else if (transform.position.y <= -4.9f) // Annars om y-positionen på skeppet är mindre eller lika med -4.9 frames i "Main Cameran":
        {
            transform.position = new Vector3(transform.position.x, -4.9f, 0); // Behåll den på samma y-position för att inte låta den överstiga mappens gränser.
        }

        if (transform.position.x >= 8.85f) // Om x-positionen på skeppet är mer eller lika med 8.85 frames i "Main Cameran":
        {
            transform.position = new Vector3(8.85f, transform.position.y, 0); // Behåll den på samma x-position för att inte låta den överstiga mappens gränser.
        }
        else if (transform.position.x <= -8.85f) // Annars om x-positionen på skeppet är mindre eller lika med -8.85 frames i "Main Cameran":
        {
            transform.position = new Vector3(-8.85f, transform.position.y, 0); // Behåll den på samma x-position för att inte låta den överstiga mappens gränser.
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy") // Om föremål med "taggen" "enemy" kolliderar med skeppet:
        {
            health--; // Ska skeppet fölora liv
            healthMeter.value = health; // Samt visa det nya antalet liv på dess healthMeter/Slider
        }

        if (other.gameObject.tag == "boss") // Om skeppet kolliderar med bossen:
        {
            health = 0; // Ska skeppet dö direkt
        }

        if (health == 0) // Om skeppet har noll liv kvar:
        {
             SceneManager.LoadScene(2); // Ska man tas till "GamerOver" scenen
        }
    }
}
