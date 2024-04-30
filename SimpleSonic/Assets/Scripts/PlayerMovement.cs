using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //OSCHandler.Instance.SendMessageToClient("pd","/unity/trigger","ready");
        OSCHandler.Instance.SendMessageToClient("pd","/unity/test1","ready");
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }

        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = OSCHandler.Instance.Servers;
        //routine for receiving the OSC
        foreach (KeyValuePair<string, ServerLog> item in servers){
            if(item.Value.log.Count >0){
                int lastPacketIndex = item.Value.packets.Count -1; //count text = text obj
                //countText.text = item.Value.packets[lastPacketIndex].Address.ToString();
                //countText.text += item.Value.packets[lastPacketIndex].Data[0].ToString();
            }
        }
        //routine done
    }

    //countText.text = "Count: " + count.ToString();
    //send the message to the client
    //OSCHandler.Instance.SendMessageToClient("pd","/unity/trigger", count);
}
