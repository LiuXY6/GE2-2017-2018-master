using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    // Use this for initialization
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        StartCoroutine(changeCam());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator changeCam()
    {
        yield return new WaitForSeconds(7);
        cam1.enabled = false;
        cam2.enabled = true;

        yield return new WaitForSeconds(41);
        cam2.enabled = false;
        cam3.enabled = true;

        yield return new WaitForSeconds(7);
        Application.LoadLevel("scene4 Retreat");
        yield break;
        //this just stops the coroutine immediately

    }
}
