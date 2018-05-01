using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigshipControl : MonoBehaviour
{

    public GameObject MainbulletPrefab;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPointA;
    public GameObject bulletSpawnPointB;
    public GameObject bulletSpawnPointC;
    public double halffov = Math.PI / 8.0f;
    public float range = 150;    
    public float speed;
    public int life = 100;
    public GameObject explosionPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire", 0, 0.3f);      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;      
    }

    

    void Fire()
    {
        GameObject[] spawnPoints;
        GameObject currentPoint;
        int index;
        float distA;
        float distB;
        float distC;

        spawnPoints = GameObject.FindGameObjectsWithTag("Target");
        index = UnityEngine.Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];

        distA = Vector3.Distance(currentPoint.transform.position, bulletSpawnPointA.transform.position);
        if(distA<=range){
            GameObject bullet1 = GameObject.Instantiate<GameObject>(bulletPrefab);
            Vector3 toTargetA = currentPoint.transform.position - bulletSpawnPointA.transform.position;
            bullet1.transform.position = bulletSpawnPointA.transform.position;
            bullet1.transform.rotation = Quaternion.LookRotation(toTargetA);
            Destroy(bullet1, 2);
        }
        
        distB = Vector3.Distance(currentPoint.transform.position, bulletSpawnPointB.transform.position);
        if (distB <= range)
        {
            GameObject bullet2 = GameObject.Instantiate<GameObject>(bulletPrefab);
            Vector3 toTargetB = currentPoint.transform.position - bulletSpawnPointB.transform.position;
            bullet2.transform.position = bulletSpawnPointB.transform.position;
            bullet2.transform.rotation = Quaternion.LookRotation(toTargetB);
            Destroy(bullet2, 2);
        }

        Vector3 toTargetC = currentPoint.transform.position - bulletSpawnPointC.transform.position;
        toTargetC = Vector3.Normalize(toTargetC);
        float dot = Vector3.Dot(toTargetC, bulletSpawnPointC.transform.forward);
        float angle = Mathf.Acos(dot);
        if (angle < halffov)
        {
            distC = Vector3.Distance(currentPoint.transform.position, bulletSpawnPointC.transform.position);
            if (distC <= range*2)
            {
                GameObject bullet3 = GameObject.Instantiate<GameObject>(MainbulletPrefab);
                toTargetC = currentPoint.transform.position - bulletSpawnPointC.transform.position;
                bullet3.transform.position = bulletSpawnPointC.transform.position;
                bullet3.transform.rotation = Quaternion.LookRotation(toTargetC);
                Destroy(bullet3, 2);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet4")
        {
            life--;
        }
        if (other.tag == "Bullet5")
        {
            life -= 10;
        }
        if (life <= 0)
        {
            GameObject explpsion = GameObject.Instantiate<GameObject>(explosionPrefab);
            explpsion.transform.position = bulletSpawnPointB.transform.position;
            Destroy(this.gameObject);
        }
    }
}
