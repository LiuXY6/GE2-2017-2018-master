using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") {
            Destroy(this.gameObject);
        }      
    }
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 100f;
	
	}
}
