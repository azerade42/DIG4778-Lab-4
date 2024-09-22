using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meteor : MonoBehaviour, IDamageable
{
    [SerializeField] protected float destroyYPos = -11f;
    [SerializeField] protected float speed = 2f;


    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < destroyYPos)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.TryGetComponent(out IDestructable destructable))
        {
            destructable.DestroyObject();
            Destroy(gameObject);
        }
    }

    public abstract void TakeDamage();
}
