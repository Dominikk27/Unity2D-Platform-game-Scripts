using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    public GameObject DestroyEffect;

    public float DestroyTimer;

    void Start()
    {
        StartCoroutine(Timer());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            Destroy();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(DestroyTimer);
        Destroy();
    }

    void Destroy()
    {
        if(DestroyEffect != null)
        {
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
