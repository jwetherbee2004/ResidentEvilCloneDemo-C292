using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float mouseSensitivity = 60f;
    [SerializeField] Transform fpsCamera;

    [SerializeField] float verticalLookLimit = 85f;

    [SerializeField] Transform firePoint;

    private bool isGrounded;
    private float xRotation = 0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAround();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetMouseButtonDown(0))
        {
            // Shoot(1);
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;

        Vector3 moveVelocity = move * moveSpeed;
        moveVelocity.y = rb.velocity.y;

        rb.velocity = moveVelocity;
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        fpsCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // private void Shoot(float damage)
    // {
    //     RaycastHit hit;
    //     if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
    //     {
    //         Debug.DrawRay(firePoint.position, firePoint.forward * hit.distance, Color.red, 2f);
    //         if(hit.transform.CompareTag("Zombie"))
    //         {
    //             hit.transform.GetComponent<Zombie>().TakeDamage(damage);
    //         }
    //     }
    // }
}
