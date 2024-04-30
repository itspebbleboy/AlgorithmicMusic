using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrowningTimer : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float maxTime = 5;
    private float timer = 0;
    private bool isUnderwater = false;

    void Start()
    {
        slider.maxValue = maxTime;
    }

    void Update()
    {
        // slider should follow sonic
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0));
        slider.value = maxTime - timer;

        // slider should show up if underwater
        slider.gameObject.SetActive(isUnderwater);
        // timer should count if underwater
        if (isUnderwater) {
            timer += Time.deltaTime;
            if (timer > maxTime) {
                // Death
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Water")) {
            isUnderwater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Water")) {
            isUnderwater = false;
            timer = 0;
        }
    }
}
