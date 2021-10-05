using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/EnemyRocket")]

public class EnemyRocket : Rocket
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!="Player")
        {
            
            Destroy(this.gameObject);
            return;
        }
    }

}
