using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxSpeed = 10f;
    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, 0f, speed);
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        rb.velocity = velocity.normalized * clampedSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = collision.transform.position;
            Vector3 ballPos = trans.position;
            Vector3 direction = (ballPos - playerPos).normalized;
            float speed = rb.velocity.magnitude;
            rb.velocity = new Vector3(-direction.x * speed, 0f, direction.z * speed);
        }
    }
}
