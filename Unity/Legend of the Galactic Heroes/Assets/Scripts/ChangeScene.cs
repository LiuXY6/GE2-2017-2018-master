using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    private static bool created = false;
    // Use this for initialization

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
	
	void Start () {
        StartCoroutine(changeScene());
	}
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(22);
        Application.LoadLevel("scene3 Impasse");
        yield break;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
