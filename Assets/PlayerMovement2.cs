using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    IEnumerator Jump()
    {
        transform.Translate(new Vector3(0,1,0));
        yield return new WaitForSeconds(0.3f);
        transform.Translate(new Vector3(0,-1,0));
    }
}
