using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : Bomb
{
    protected override void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Invoke(nameof(Explosion), timeToExplosion);
        }
    }

}
