using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            other.gameObject.SetActive(false);
            OSCHandler.Instance.SendMessageToClient("pd","/unity/coin", 0);
        }
    }
}
