using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour{
    public GameObject projectilePrefab;
    public float fireRate = 0.5f; 
    private float nextFireTime = .2f;

    void Update() {
    
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))&& Time.time >= nextFireTime) {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot() {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();

        Vector3 shootDirection = transform.forward;
        projectileController.SetDirection(shootDirection);

        Destroy(projectile, 2);
    }

}

