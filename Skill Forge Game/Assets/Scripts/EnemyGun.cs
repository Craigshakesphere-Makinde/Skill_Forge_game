using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGun : MonoBehaviour
{
    //Gun stats
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenShooting, range;



    //Distance
    private Transform target;
    [SerializeField] private float attackDistance;

    private int bulletShot;
    //BOols
    private bool readyToShoot;

    //References

    [SerializeField] private Transform attackPoint;
    [SerializeField] private RaycastHit rayHit;
    [SerializeField] private LayerMask whatIsPlayer;

    //Effect

    [SerializeField] private GameObject muzzleFlash, bulletHole;

    [SerializeField] private AudioSource gunShot;

    //public EnemyAi enemyAi;

    //public PlayerDamage playerDamage;

    private void Start()
    {

        readyToShoot = true;

    }


    private void Update()
    {
        target = FindObjectOfType<CarController>().transform;

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackDistance && readyToShoot)
        {

            Shoot();
        }
    }



    private void Shoot()
    {
        gunShot.Play();
        readyToShoot = false;
        //spread


        //float x = Random.Range(-spread, spread);
        //Vector3 direction = carCamera.transform.position + new Vector3(x,x,0);


        //RayCast

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, range, whatIsPlayer))
        {
            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.CompareTag("Player"))
            {
                //playerDamage.TakeDamage(damage);
                //GetComponent<Rigidbody>().AddForce(Vector3.back, ForceMode.Impulse);
                rayHit.collider.GetComponent<PlayerDamage>().TakeDamage(damage);
            }

        }

        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.Euler(0, 90, 0));
        GameObject hole = Instantiate(bulletHole, rayHit.point, Quaternion.identity);
        Destroy(flash, .5f);
        Destroy(hole, 1f);


        Invoke("ShootReset", timeBetweenShooting);
    }

    private void ShootReset()
    {
        readyToShoot = true;
    }


}
