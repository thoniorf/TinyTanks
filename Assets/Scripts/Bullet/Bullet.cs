using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [field: SerializeField]
    public int speed { get; private set; }

    [field: SerializeField]
    private int lifeTimeout { get; set; }

    private Rigidbody _bulletRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
        StartCoroutine(WaitAndDestroy(lifeTimeout));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _bulletRigidBody.velocity = transform.forward * speed;
    }

    private IEnumerator WaitAndDestroy(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
