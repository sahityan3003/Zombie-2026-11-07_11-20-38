using UnityEngine;
using System.Collections;
using Unity.Mathematics;
public class Gun : MonoBehaviour
{
    public float reloadTime = 1f;
    public float fireRate = 0.15f;
    public int magSize = 20;


    public GameObject bullet;
    public Transform bulletSpawnPoint;


    private int currentAmmo;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;


    private quaternion initalRotation;
    private Vector3 initialPosition;
    private Vector3 reloadPosition = new Vector3(60, 50, 50);

    void Start()
    {
        currentAmmo = magSize;
        initalRotation = transform.localRotation;
        initialPosition = transform.localPosition;
    }
    public void shoot()
    {
        if (isReloading) return;
        if (Time.time < nextTimeToFire) return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        nextTimeToFire = Time.time + fireRate;
        currentAmmo--;

        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation)
    }
    
 


}
