using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);

        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
	}

    float DamageRecieved(float dmg)
    {
        return currentHealth -= dmg ;
    }
}
