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
        
    }

  
        
    
}
