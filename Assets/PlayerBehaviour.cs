using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //public Color[] colorSwap;
    int currentColor = 0;

    GameObject playerBarrel, playerBody, range, closest;
    Renderer barrelRender, bodyRender;

    Transform target;

    public GameObject bullet;
    public static bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        playerBarrel = this.gameObject.transform.GetChild(2).gameObject;
        playerBody = this.gameObject.transform.GetChild(1).gameObject;
        range = this.gameObject.transform.GetChild(3).gameObject;

        barrelRender = playerBarrel.GetComponent<Renderer>();
        bodyRender = playerBody.GetComponent<Renderer>();

        StartCoroutine(bulletSpawn(1f));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inRange);

        if (inRange == true)
        {
            enemyInRange();

            if (FindClosestEnemy() != null)
            {
                target = FindClosestEnemy().transform;
            }
        }
    }

    private void OnMouseDown()
    {
        switch (currentColor)
        {
            case 0:
                {
                    barrelRender.material.color = Color.red;
                    bodyRender.material.color = Color.red;

                    currentColor = 1;
                    break;
                }

            case 1:
                {
                    barrelRender.material.color = Color.green;
                    bodyRender.material.color = Color.green;

                    currentColor = 2;
                    break;
                }

            case 2:
                {
                    barrelRender.material.color = Color.blue;
                    bodyRender.material.color = Color.blue;

                    currentColor = 0;
                    break;
                }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void enemyInRange()
    {
        this.transform.LookAt(target);
        this.transform.rotation *= Quaternion.FromToRotation(new Vector3(0,0,1f), new Vector3(0, 0, 1f));
    }


    GameObject bulletClone;

    public IEnumerator bulletSpawn(float wait)
    {
        while (true)
        {
            bulletClone = Instantiate(bullet, new Vector3(0, 7.5f, 0), this.transform.rotation);
            Renderer bulletCloneRender = bullet.GetComponent<Renderer>();
            bulletCloneRender.material.color = barrelRender.material.color;
            yield return new WaitForSeconds(wait);

            StartCoroutine(bulletDestroy(5f));
        }
    }

    public IEnumerator bulletDestroy(float wait)
    {
        while (true)
        {
            yield return new WaitForSeconds(wait);
            Destroy(bulletClone);
        }
    }
}
