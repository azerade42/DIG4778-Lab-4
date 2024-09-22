using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : Meteor
{
    public int hitCount = 0;
    [SerializeField] private MeteorHealthbar healthbar;

    private void OnEnable()
    {
        this.GetComponent<Meteor>().clockwise = 0;
    }
    public override void TakeDamage()
    {
        healthbar.UpdateHealth(hitCount);
        if (++hitCount >= 5)
        {
            CameraShake.Instance.ShakeCamera(3f, 10f);
            OnMeteorDestroyed?.Invoke(3);
            Destroy(gameObject);
        } 
    }
}
