using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject player = this.transform.parent.gameObject;
            Destroy(player);
        }
    }
}
