using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;

    private Rigidbody2D rb2d;
    
    void Start()
    {
        Application.runInBackground = true;
        rb2d = GetComponent<Rigidbody2D>();
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("pd","/unity/trigger","ready");
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }
}
