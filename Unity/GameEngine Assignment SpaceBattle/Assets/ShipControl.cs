using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipControl : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public GameObject Target;
    public Vector3 toTarget;
    public double halffov = Math.PI / 8.0f;
    public int shot = 0;
    
    // Use this for initialization
	void Start () {
        InvokeRepeating("Fire", 2.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire()
    {
        toTarget = Target.transform.position - bulletSpawnPoint.transform.position;
        toTarget = Vector3.Normalize(toTarget);
        float dot = Vector3.Dot(toTarget, bulletSpawnPoint.transform.forward);
        float angle = Mathf.Acos(dot);
        if (angle < halffov)
        {            
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = Quaternion.LookRotation(toTarget);
            Destroy(bullet, 2);
        }       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet2")
        {           
            shot++;
            if (shot > 50)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
