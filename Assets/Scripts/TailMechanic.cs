using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMechanic : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float Offset;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - rb.position).normalized;
            Vector3 velocity = direction * speed;
            Vector3 moveAmount = velocity * Time.deltaTime;

            Vector3 Diff = target.transform.position - rb.position;

            // Offset/space between Head and tail 
            if (Diff.magnitude >= Offset)
            {
                // Ensuring we do not move the object above the target
                if (moveAmount.sqrMagnitude > (target.transform.position - rb.position).sqrMagnitude)
                {
                    rb.MovePosition(target.transform.position);
                }
                else
                {
                    rb.MovePosition(rb.position + moveAmount);
                }
            }

            // Rotation
            if (Diff.normalized != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(Diff.normalized * 2);
                rb.MoveRotation(rotation);
            }
        }
    }
}
