using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour {

	public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public GameObject Location;
    // Use this for initialization  
    void Start () {  

        GameObject A1;
        GameObject A2;
        GameObject A3;
        for (int i = 0; i < 100; i++) {
            A1 = GameObject.Instantiate<GameObject>(Asteroid1);
            A1.transform.position = Location.transform.TransformPoint(new Vector3(Random.Range(-80.0F, 80.0F), Random.Range(-20.0F, 20.0F), Random.Range(-200.0F, 200.0F)));
            A2 = GameObject.Instantiate<GameObject>(Asteroid2);
            A2.transform.position = Location.transform.TransformPoint(new Vector3(Random.Range(-80.0F, 80.0F), Random.Range(-20.0F, 20.0F), Random.Range(-200.0F, 200.0F)));
            A3 = GameObject.Instantiate<GameObject>(Asteroid3);
            A3.transform.position = Location.transform.TransformPoint(new Vector3(Random.Range(-80.0F, 80.0F), Random.Range(-20.0F, 20.0F), Random.Range(-200.0F, 200.0F)));
       
        }  
    }  
      
    // Update is called once per frame  
    void Update()
    {
    }
}
