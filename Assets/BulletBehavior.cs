using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    float speed = 100f;

    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

            if (this.gameObject.GetComponent<Renderer>().material.color == other.gameObject.GetComponent<Renderer>().material.color)
            {
                Destroy(other.gameObject);
            }
                    
        }
        
    }
}
