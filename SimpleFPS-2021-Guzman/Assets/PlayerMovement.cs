using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10;
    [SerializeField]
    float jumpSpeed = 10;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(r.origin, r.direction);
        RaycastHit hit;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);

        if (Physics.Raycast(r, out hit, 1) && hit.transform.tag == "ground")
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }
}
