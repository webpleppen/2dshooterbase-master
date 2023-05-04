using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    [SerializeField]
    float speed = 3f; // skottens hastighet

    void Update()
    {
       Vector2 movement = new Vector2(0, speed) * Time.deltaTime;

       transform.Translate(movement);

       if (transform.position.y > 7) // Om skotten når en viss gräns (7) ska de förstöras
       {
            Destroy(this.gameObject);
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy") // Om skotten kolliderar med fiender:
        {
            Destroy(this.gameObject); // så ska skotten förstöras
        }
        else if (other.gameObject.tag == "boss") // Om skotten kolliderar med bossen:
        {
            Destroy(this.gameObject); // så ska de förstöras
        }
    }
}
