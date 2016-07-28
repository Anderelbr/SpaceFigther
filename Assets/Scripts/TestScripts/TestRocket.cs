using UnityEngine;
using System.Collections;

public class TestRocket : MonoBehaviour
{
    public float speed;
    public float damage;

    public Transform target;
    public Transform explosion;

    float time;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        target = GameObject.FindGameObjectWithTag("Enemy").transform;

        time += 0.1f;

        if (time >= 1.0f)
        {
            time = 0;
            FollowTarget(target);
        }

        Destroy(gameObject, 20.0f);
    }

    void FollowTarget(Transform target)
    {
        float step = speed / 4 * Time.deltaTime;

        try
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        catch
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, Vector3.zero, step, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    Transform SetTarget(Transform tgt)
    {
        target = tgt;
        return target;
    }

    public float Damage(float dmg)
    {
        return damage = dmg * 10;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Bulls Eyes");
        col.rigidbody.SendMessage("DamageRecieved", damage);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
