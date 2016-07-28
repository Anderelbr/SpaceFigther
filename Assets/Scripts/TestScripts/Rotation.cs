using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    public Transform tgt;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal") * -5.0f * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * 5.0f * Time.deltaTime;

        transform.Translate(x, y, 0);

        transform.LookAt(tgt.position);
	
	}
}
