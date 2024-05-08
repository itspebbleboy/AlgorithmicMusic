using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class TreeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Tree")) {
            OSCHandler.Instance.SendMessageToClient("pd","/unity/wallCollision",0);
        }
    }
}
