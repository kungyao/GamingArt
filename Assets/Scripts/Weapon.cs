using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int bulletsPerMag = 30;
    public int bulletsLeft;
    public float fireRate = 0.1f;

    float fireTimer;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (fireTimer < fireRate) return;

    }
}
