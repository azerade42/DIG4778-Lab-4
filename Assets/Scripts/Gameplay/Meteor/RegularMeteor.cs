using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMeteor : Meteor
{
    public override void TakeDamage()
    {
        CameraShake.Instance.ShakeCamera(3f, 10f);
        SoundManager.Instance.PlayDestroySound();
        
        OnMeteorDestroyed?.Invoke(1);
        Destroy(gameObject);
    }
}
