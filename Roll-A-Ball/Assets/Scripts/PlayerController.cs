using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int Count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;
        SetCountText();
        WinText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            Count = Count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        CountText.text = "Count: " + Count.ToString();
        if(Count >= 8)
        {
            WinText.text = "You Win!";
        }
    }
}

//Destroy(other.gameObject);
//if(other.gameObject.CompareTag("Player"))
//      gameObject.SetActive (false);