using UnityEngine;
using Gameplay.Systems;

[RequireComponent(typeof(Rigidbody))]
public class ArrowProjectile : MonoBehaviour {
    private float speed = 3f;
    private float lifeTime = 10f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
    }
}
