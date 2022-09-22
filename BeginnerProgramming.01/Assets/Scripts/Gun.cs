using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem ShootingSystem;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private ParticleSystem ImpactParticleSystem;
    [SerializeField] private TrailRenderer BulletTrail;
    [SerializeField] private float ShootDelay = 0.1f;
    [SerializeField] private float Speed = 100;
    [SerializeField] private LayerMask Mask;
    [SerializeField] private bool BouncingBullets;
    [SerializeField] private float BounceDistance = 10f;

    private float LastShootTime;

    public void Shooting()
    {
        
        Debug.Log("Shot");
        if (LastShootTime + ShootDelay < Time.time)
        {
            ShootingSystem.Play();

            Vector3 direction = transform.forward;
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, quaternion.identity);

            if (Physics.Raycast(BulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask))
            {
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, BounceDistance, true));
            }
            else
            {
                StartCoroutine(SpawnTrail(trail, direction * 100, Vector3.zero, BounceDistance, false));
            }

            LastShootTime = Time.time;
        }
    }


    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 Hitpoint, Vector3 HitNormal, float BounceDistance,
        bool MadeImpact)
    {
        Vector3 startPosition = Trail.transform.position;
        Vector3 direction = (Hitpoint - Trail.transform.position).normalized;

        float distance = Vector3.Distance(Trail.transform.position, Hitpoint);
        float startingDistance = distance;

        while (distance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hitpoint, 1 - (distance / startingDistance));
            distance -= Time.deltaTime * Speed;

            yield return null;
        }

        Trail.transform.position = Hitpoint;

        if (MadeImpact)
        {
            Instantiate(ImpactParticleSystem, Hitpoint, Quaternion.LookRotation(HitNormal));

            if (BouncingBullets && BounceDistance > 0)
            {
                Vector3 bounceDirection = Vector3.Reflect(direction, HitNormal);

                if (Physics.Raycast(Hitpoint, bounceDirection, out RaycastHit hit, BounceDistance, Mask))
                {
                    yield return StartCoroutine(SpawnTrail(
                        Trail,
                        hit.point,
                        hit.normal,
                        BounceDistance - Vector3.Distance(hit.point, Hitpoint),
                        true
                    ));
                }
                else
                {
                    yield return StartCoroutine(SpawnTrail(
                        Trail,
                        bounceDirection * BounceDistance,
                        Vector3.zero,
                        0,
                        false
                    ));
                }
            }
        }
        
        Destroy(Trail.gameObject, Trail.time);
    }
    
}
