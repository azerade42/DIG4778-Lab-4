using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMeteor : Meteor
{
    public override void TakeDamage()
    {
        Destroy(gameObject);
        OnMeteorDestroyed?.Invoke(1);
    }
}
