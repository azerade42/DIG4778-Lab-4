using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Meteor : MonoBehaviour, IDamageable
{
    [SerializeField] protected float destroyYPos = -11f;
    [SerializeField] protected float speed = 2f;
    public static Action<int> OnMeteorDestroyed;

    public int clockwise;

    private void OnEnable()
    {
        RandomRotation();
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);

        if (transform.position.y < destroyYPos)
        {
            Destroy(this.gameObject);
        }

        
        transform.Rotate(0f, 0f, 20f * Time.deltaTime * clockwise, Space.World);
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

    public void RandomRotation()
    {
        clockwise = UnityEngine.Random.Range(0, 2);

        if (clockwise == 0)
        {
            clockwise = -1;
        }
        else return;
    }
}
