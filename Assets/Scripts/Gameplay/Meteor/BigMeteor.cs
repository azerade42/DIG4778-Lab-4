using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : Meteor
{
    private int hitCount = 0;

    public override void TakeDamage()
    {
        if (++hitCount >= 5)
        {
            Destroy(gameObject);
        }
    }
}
