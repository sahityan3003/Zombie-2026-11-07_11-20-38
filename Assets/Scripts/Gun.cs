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


    private Quaternion initalRotation;
    private Vector3 initialPosition;
    private Vector3 reloadRotationOffset = new Vector3(60, 50, 50);

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

        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Quaternion targetRotation = Quaternion.Euler(initalRotation.eulerAngles + reloadRotationOffset);
        float halfReload = reloadTime / 2f;
        float t = 0f;

        while(t < halfReload)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(initalRotation, targetRotation, t / halfReload);
            yield return null;

        }

        t = 0f;

        while (t < halfReload)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(targetRotation, initalRotation, t / halfReload);
            yield return null;

        }

        currentAmmo = magSize;
        isReloading = false;
    }
    
    public void TryReload()
    {
        if (isReloading)
            return;

        if (currentAmmo == magSize)
            return;


        StartCoroutine(Reload());
    }
 


}
