using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    private void Start()
    {
        winText.text = "";
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void FixedUpdate ()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
        if (count >= 60)
        {
            winText.text = "You Win!!!";
        }
    }
}
