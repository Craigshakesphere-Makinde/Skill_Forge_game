using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunControls : MonoBehaviour
{
    
    [SerializeField] private int damage,magSize, bulletLeft,bulletShot;
    [SerializeField] private TextMeshProUGUI bulletText;

    [SerializeField] private float reloadTime, timeBetweenShots,range=1000f;
    private bool isShooting,reloading, readyToShoot;

    //Reference
    [SerializeField] private RaycastHit hit;
    [SerializeField] private LayerMask shootables;

    //Effects

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject bulletHole;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private AudioSource gunshot;

    [SerializeField] private Camera mainCam;

    [SerializeField] private GameObject bulletInfo;



    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
        bulletLeft = magSize;
        reloading= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.GetComponent<TextMeshProUGUI>().text = bulletLeft.ToString();
        MyInputs();
        
    }

    private void MyInputs()
    {
        if(bulletLeft< 3)
        {
            BulletReloadInfo();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isShooting = true;
        }

        else
        {
            isShooting= false;
        }

        if (isShooting && !reloading && readyToShoot && bulletLeft > 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magSize && !reloading)
        {
            Reload();
        }

    }
    private void BulletReloadInfo()
    {
        bulletInfo.SetActive(true);
    }

    private void Shoot()
    {

        readyToShoot = false;
        if(Physics.Raycast(transform.position,transform.right, out hit, Mathf.Infinity, shootables))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyDamage>().TakeDamage(damage);

            }
            

        }
        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.Euler(0,90,0));
        GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.identity);

        Destroy(flash, 1);
        Destroy(hole, 2);

        Invoke("ShootReset", timeBetweenShots);

        bulletLeft--;
        bulletShot++;
        gunshot.Play();
        






    }

    private void ShootReset()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        bulletInfo.SetActive(false);
        reloading = true;
        bulletLeft = magSize;
        Invoke("ReloadReset", reloadTime);
        


    }

    private void ReloadReset()
    {
        reloading= false;
    }
}
