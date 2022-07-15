using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float speed = 20;
    public Text scoreText;
    public Text winText;
    private Rigidbody rb;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCountText();
        winText.text = "";
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed); 
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        { other.gameObject.SetActive(false);
            score = score + 1;
            SetCountText();
        }
    }
    void SetCountText()
    { scoreText.text = "Count:" + score.ToString();
    if(score >= 12)
        { winText.text = "You Win!"; }
    }
}
