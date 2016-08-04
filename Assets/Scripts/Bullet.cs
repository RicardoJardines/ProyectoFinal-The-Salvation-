using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    
   

    void OnCollisionEnter(Collision bulletCollision)
    {
        Destroy(this.gameObject,1f); //this hace referencia a este componente

        if (bulletCollision.gameObject.CompareTag("Player"))
        {
            bulletCollision.gameObject.GetComponent<PlayerController>().damage = true;
            bulletCollision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, 5);
        }
    }
}
