using System.Threading;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour
{
    private float BarrierForce;

    void Start()
    {
        this.BarrierForce = 30.0f;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = (collision.transform.position).normalized;
            rigidBody.velocity = -direction * this.BarrierForce;     
        }   
    }
}