using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectiles : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    
    public void Launch(Vector3 targetPos) {

        GameObject newProjectile = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
        
        
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);

        // euler = rotation of object
        // can use euler angles, don't alwasy need to use quaternions
        // transform.eulerAngles = new Vector3(0,0,0);

        // moes the projectile to travel at speed of 1 unity unit
        newProjectile.GetComponent<Rigidbody2D>().velocity = (newProjectile.transform.up * speed);
        Destroy(newProjectile,10);
    }

}
