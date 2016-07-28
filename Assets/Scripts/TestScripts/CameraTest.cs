using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour
{
    public Transform tgt;
	
	void Update ()
    {
        try
        {
            tgt = GameObject.Find("Rocket").transform;
        }
        catch
        {
            tgt = null;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * 50);
        transform.LookAt(tgt.position);
	}
}
