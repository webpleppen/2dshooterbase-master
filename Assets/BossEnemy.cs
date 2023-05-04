using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
     [SerializeField]
    float speed = 3f;

    [SerializeField]
    GameObject explosionPrefab;

    int health = 1;

    void Start()
    {
        float x = Random.Range(-8f, 8f); // mellan vilka x-kordinater fiender slumpmässigt kan "spawna"
        
        Vector2 position = new Vector2(x, 7); // fienden spawnar vart som helst i x-led på kordinat "7" i y-led 

        transform.position = position;
    }

    void Update()
    {
        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y < -7) // Om fienden passerar frame "-7" i scenen:
        {
            Destroy(this.gameObject); // förstör objektet
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            health--;

            if (health == 0)
            {
              Destroy(this.gameObject);
              Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
        }

        if (other.gameObject.tag == "Player") // Om fienden krockar med spelaren så förstörs fienden
        {
            Destroy(this.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Explosion
        }
    }
}
