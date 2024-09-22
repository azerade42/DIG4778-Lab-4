using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] protected float destroyAfterTime = 6f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime(destroyAfterTime));
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterTime(float destroyAfterTime)
    {
        yield return new WaitForSeconds(destroyAfterTime);
        Destroy(gameObject);
    }
}
