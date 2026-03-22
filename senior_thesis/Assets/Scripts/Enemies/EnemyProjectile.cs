using System;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float spawnCooldown = 1.0f;
    [SerializeField] private float nextSpawnTime;
    [SerializeField] private float yRange;
    
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            //creating projectile at enemy position
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            //sets nextSpawnTime to the current time + the cooldown time
            nextSpawnTime = Time.time + spawnCooldown;
        }

        if (projectilePrefab.transform.position.y <= (transform.position.y - yRange))
        {
            projectilePrefab.SetActive(false);
        }
    }
}
