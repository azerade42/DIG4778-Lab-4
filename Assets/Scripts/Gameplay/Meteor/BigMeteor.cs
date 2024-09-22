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
        if (++hitCount >= 5)
        {
            Destroy(gameObject);
            OnMeteorDestroyed?.Invoke(3);
        } 
        healthbar.UpdateHealth(hitCount);
    }
}
