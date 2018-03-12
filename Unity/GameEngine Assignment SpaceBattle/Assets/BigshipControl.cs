using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigshipControl : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPointA;
    public GameObject bulletSpawnPointB;
    public GameObject bulletSpawnPointC;
    public GameObject Target;
    public GameObject[] spawnPoints;
    public GameObject currentPoint;
    public int index;
    public float speed;


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
        spawnPoints = GameObject.FindGameObjectsWithTag("Target");
        index = UnityEngine.Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];

        GameObject bullet1 = GameObject.Instantiate<GameObject>(bulletPrefab);
        Vector3 toTargetA = currentPoint.transform.position - bulletSpawnPointA.transform.position;
        bullet1.transform.position = bulletSpawnPointA.transform.position;
        bullet1.transform.rotation = Quaternion.LookRotation(toTargetA);

        GameObject bullet2 = GameObject.Instantiate<GameObject>(bulletPrefab);
        Vector3 toTargetB = currentPoint.transform.position - bulletSpawnPointB.transform.position;
        bullet2.transform.position = bulletSpawnPointB.transform.position;
        bullet2.transform.rotation = Quaternion.LookRotation(toTargetB);

        GameObject bullet3 = GameObject.Instantiate<GameObject>(bulletPrefab);
        Vector3 toTargetC = currentPoint.transform.position - bulletSpawnPointC.transform.position;
        bullet3.transform.position = bulletSpawnPointC.transform.position;
        bullet3.transform.rotation = Quaternion.LookRotation(toTargetC);

        Destroy(bullet1, 2);
        Destroy(bullet2, 2);
        Destroy(bullet3, 2);
    }
}
