using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField]
    float moveForce, maxVelocity, jumpForce;
    Rigidbody rigid;

    Transform cam;

    [SerializeField]
    float raycastLenght;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        print(grounded);
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigid.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }


        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical")).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigid.AddForce(moveDir * moveForce);
        }

        rigid.velocity = Vector3.ClampMagnitude(rigid.velocity,maxVelocity);
    }

    private void FixedUpdate()
    {
        int floor = LayerMask.NameToLayer("Floor");
        RaycastHit hit;

        // If it hits something...
        if (Physics.Raycast(transform.position, -Vector2.up,out hit,raycastLenght))
        {
            if (hit.transform.gameObject.layer == floor)
                grounded = true;
            else
                grounded = false;
        }else
            grounded = false;   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,-Vector3.up * raycastLenght);
    }
}
