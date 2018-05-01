using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl3 : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    // Use this for initialization
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        StartCoroutine(changeCam());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator changeCam()
    {
        yield return new WaitForSeconds(3);
        cam1.enabled = false;
        cam2.enabled = true;
        yield break;
        //this just stops the coroutine immediately

    }
}
