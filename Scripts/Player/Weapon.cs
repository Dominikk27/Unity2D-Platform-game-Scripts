using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Weapon : MonoBehaviour
{
    public Transform WeaponPos;
    public GameObject bulletPrefab;

    public PlayerMovement playerMovement;

    public float ShotTimer, BulletSpeed;

    public bool isShooting;
    public int DealDMG;


    void Start()
    {
        isShooting = false; 
    }

    void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * BulletSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Mouse0) && !isShooting)
        {
           StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        //Debug.Log("RaTATATATA");
        GameObject newBullet = Instantiate(bulletPrefab, WeaponPos.position, Quaternion.identity);
        newBullet.transform.parent = null;
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed * Time.fixedDeltaTime, 0f);
        yield return new WaitForSeconds(ShotTimer);
        isShooting = false;
    }

}
