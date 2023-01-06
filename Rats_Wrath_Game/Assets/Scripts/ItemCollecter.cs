using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    private int Points = 0;

    [SerializeField] private Text pointsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            Destroy(collision.gameObject);
            Points++;
            //Debug.Log("Points: " + Points);
            pointsText.text = "Points: " + Points;
        }
    }

}
