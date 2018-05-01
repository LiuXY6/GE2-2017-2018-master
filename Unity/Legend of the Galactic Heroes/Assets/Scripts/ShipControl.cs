using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipControl : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public GameObject Target;
    
    public double halffov = Math.PI / 4.0f;
    public float range = 80;
    public int life = 10;
    public GameObject explosionPrefab;
    
    // Use this for initialization
	void Start () {
        InvokeRepeating("Fire", 2.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire()
    {
        GameObject[] spawnPoints;
        Vector3 toTarget;
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        spawnPoints = GameObject.FindGameObjectsWithTag("BigTarget");
        

        foreach (GameObject t in spawnPoints)
        {
            float dist = Vector3.Distance(t.transform.position, bulletSpawnPoint.transform.position);
            if (dist < minDist||dist <range)
            {
                tMin = t;
                minDist = dist;
            }
        }

        toTarget = tMin.transform.position - bulletSpawnPoint.transform.position;
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
            life--;
            if (life<=0)
            {
                GameObject explpsion = GameObject.Instantiate<GameObject>(explosionPrefab);
                explpsion.transform.position = bulletSpawnPoint.transform.position;                
                Destroy(this.gameObject);
            }
        }
    }
}
