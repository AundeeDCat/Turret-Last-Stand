using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(10, 25);

        Renderer enemyRender = this.GetComponent<Renderer>();

        switch (Random.Range(0, 3))
        {
            case 0:
                {
                    enemyRender.material.color = Color.red;
                    break;
                }
            case 1:
                {
                    enemyRender.material.color = Color.green;
                    break;
                }
            case 2:
                {
                    enemyRender.material.color = Color.blue;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(0.0f, 0.0f, 5.0f);
        float step = speed * Time.deltaTime;

        this.transform.LookAt(target);
        this.transform.position = Vector3.MoveTowards(transform.position, target, step);

        
    }

    void OnDestroy()
    {
        PlayerBehaviour.inRange = false;
    }

    /* Targeting Works but Death Collide doesn't the rb of the player is interfering with its range
     * it keeps triggering it, found out the floor triggered it, FIXED
     * 
     * Once that is fixed, 
     * Bullets need to be made, The Coroutine isn't working properly (Cant be in Void Update)
     * Death of Cubes to correct Bullet
     */

    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            Destroy(other);
        }
        
    }*/
}
    
