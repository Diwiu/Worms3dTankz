using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100;
    
    [SerializeField] private int playerIndex;

    // Update is called once per frame
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex) && Input.GetKeyDown(KeyCode.G))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
