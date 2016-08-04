using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject bullet;
    public float force;
   
    private GameObject tempBullet;

   
	
	// Update is called once per frame
	public void Fireball () {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        tempBullet = (GameObject)Instantiate(bullet, transform.position, bullet.transform.rotation);
        //tmpdecal.transform.up = -transform.forward;
        tempBullet.transform.up = -transform.forward;
        tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
