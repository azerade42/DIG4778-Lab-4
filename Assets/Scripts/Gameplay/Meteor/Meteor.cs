using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Meteor : MonoBehaviour, IDamageable
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float destroyAfterTime = 8f;
    public static Action<int> OnMeteorDestroyed;

    public int clockwise;
    public Vector3 MoveDir;

    private void OnEnable()
    {
        RandomRotation();
    }

    void Start()
    {
        StartCoroutine(DestroyAfterTime(destroyAfterTime));
    }

    void Update()
    {
        transform.Translate(MoveDir * Time.deltaTime * speed, Space.World);        
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

    private IEnumerator DestroyAfterTime(float destroyAfterTime)
    {
        yield return new WaitForSeconds(destroyAfterTime);
        Destroy(gameObject);
    }
}
