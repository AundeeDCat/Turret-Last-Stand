using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            PlayerBehaviour.inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerBehaviour.inRange = false;
        }
    }
}
