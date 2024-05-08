using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CoinCollect : MonoBehaviour
{
    public int coins = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            coins ++;
            if(coins == 4){ OSCHandler.Instance.SendMessageToClient("pd","/unity/music", 0); }
            other.gameObject.SetActive(false);

            OSCHandler.Instance.SendMessageToClient("pd","/unity/coin", UnityEngine.Random.Range(0,3));
        }
    }
}
