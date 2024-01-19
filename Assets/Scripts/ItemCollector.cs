using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int apples = 0;
    [SerializeField] private TextMeshPro cherriesText;
    [SerializeField] private Text applesText;
    //tạo trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            //cherriesText.text = "Cherries: " + cherries;
            Destroy(collision.gameObject);
            Debug.Log(cherries);

        }
        if(collision.gameObject.CompareTag("Apple"))
        {
            apples++;
            applesText.text = "Apples: " + apples;
            Destroy(collision.gameObject);
        }
    }
}
