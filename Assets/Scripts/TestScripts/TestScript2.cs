using UnityEngine;
using System.Collections;

public class TestScript2 : MonoBehaviour
{
    GameObject[] tgts;
    public float fireRate;
    public GameObject proyectile;
    float step;

	// Use this for initialization
	void Start ()
    {
        tgts = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > step)
        {
            step = fireRate + Time.time;
            GameObject obj = (GameObject)Instantiate(proyectile, transform.position, transform.rotation);

            foreach (GameObject tgt in tgts)
            {
                //obj.SendMessage("SetTarget", tgt.transform);
                obj.SendMessage("Damage", 10);
                obj.name = proyectile.name;
            }
        }
	}
}
