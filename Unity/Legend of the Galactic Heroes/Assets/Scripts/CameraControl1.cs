using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl1 : MonoBehaviour {
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
	// Use this for initialization
	void Start () {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        StartCoroutine(changeCam());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator changeCam()
    {
        yield return new WaitForSeconds(15);
        cam1.enabled = false;
        cam2.enabled = true;

        yield return new WaitForSeconds(12);
        cam2.enabled = false;
        cam3.enabled = true;

        yield return new WaitForSeconds(25);
        Application.LoadLevel("scene2 HopeInDespair");
        yield break;
        //this just stops the coroutine immediately

    }
}
