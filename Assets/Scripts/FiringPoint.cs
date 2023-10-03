using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("Rigidbody Projectiles")]
    public GameObject projectileGreenOrb;
    public float projectileSpeed = 1000f;

    [Header("Raycast Projectiles")]
    public GameObject hitSparks;
    public LineRenderer laser;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        
            FireRidgidbody();
        
        if(Input.GetButtonDown("Fire2"))
            FireRaycast();
    }

    void FireRidgidbody()
    {
        //Create a reference to hold our instantiated object
        GameObject projectileInstance;
        //Instantiate our projectile at this object position and rotaion
        projectileInstance = Instantiate(projectileGreenOrb, transform.position, transform.rotation);
        //Add force to the projectile
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

    void FireRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //Create a reference to hold the info on what we hit
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log("We hit " + hit.collider.name + "At point " + hit.point + "Which was" + hit.distance + "Units away");

            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);
            StopAllCoroutines();
            StartCoroutine(StopLaser());
            
            GameObject particles = Instantiate(hitSparks, hit.point, hit.transform.rotation);
            Destroy(particles, 1);

            if(hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        laser.gameObject.SetActive(false);
    }







    
}
