using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlaneEnemyController : FlyingEnemyController
{
    // Start is called before the first frame update
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    protected void Start()
    {
        base.Start();
    }
     void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("On Strigger Con");
        if (other.gameObject.tag == "bullet")
        {
            OnTriggerBulletEnter(other.gameObject);
            gameObject.GetComponent<ControllerTrailEnemy>().DestroyTrailOfEnemy();
            Destroy(gameObject, soundExplosion.length + 0.5f);
        }
        else if (other.gameObject.tag == "Player")
        {
            OnTriggerPlayerEnter(other.gameObject);
        }
    }
}
