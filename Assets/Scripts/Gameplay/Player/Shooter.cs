using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shooterPrefab;
    private bool canShoot = true;
    
    [SerializeField] private float shootCooldownTime = 0.15f;

    public void Shoot()
    {
        if (!canShoot) return;

        Instantiate(shooterPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        StartCoroutine(nameof(ShootCooldown));
        SoundManager.Instance.PlayShootSound();
    }

    private IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldownTime);
        canShoot = true;
    }
}
