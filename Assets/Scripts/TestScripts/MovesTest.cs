using UnityEngine;
using System.Collections;

public class MovesTest : MonoBehaviour
{
    public Transform tgt;
    bool front, over, right, tgtLock;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Moves());
	}
	
	void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.green);

        if (Physics.Raycast(ray, out hit, 10.0f))
            tgtLock = true;
        else
            tgtLock = false;

        if (tgtLock == false)
        {
            if (right == true)
                transform.Rotate(Vector3.forward * -40.0f * Time.deltaTime);
            else
                transform.Rotate(Vector3.forward * 40.0f * Time.deltaTime);

            if(over == true || front == false)
                transform.Rotate(Vector3.right * -40 * Time.deltaTime);
            else
                transform.Rotate(Vector3.right * 40 * Time.deltaTime);
        }
    }

    IEnumerator Moves()
    {
        while (true)
        {
            Vector3 relativePosition = transform.InverseTransformPoint(tgt.position);
            
            if (relativePosition.x > 0)
                right = true;
            else
                right = false;

            if (relativePosition.z > 0)
                front = true;
            else
                front = false;

            if (relativePosition.y > 0)
                over = true;
            else
                over = false;

            yield return new WaitForSeconds(0.1f);
        }
	}
}
