using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<Projectile>().Initialize();
        }
    }
}
