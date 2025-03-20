using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Collider2D m_ObjectCollider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        m_ObjectCollider = GetComponent<Collider2D>();
        //Here the GameObject's Collider is not a trigger
        m_ObjectCollider.isTrigger = false;
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
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        m_ObjectCollider.isTrigger = true;
        transform.localScale += new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        transform.localScale += new Vector3(-1, -1, 1);
        m_ObjectCollider.isTrigger = false;
    }
}