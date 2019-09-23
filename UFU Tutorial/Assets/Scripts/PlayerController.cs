using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text lifeText;

    private Rigidbody2D rb2d;
    private int count;
    private int life = 3;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        SetLifeText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }

       if (other.gameObject.CompareTag ("Enemy"))
        {
            other.gameObject.SetActive (false);
            life = life - 1;
            SetLifeText();
        }

       if (count == 12)
        {
            transform.position = new Vector2(70.0f, 0.0f);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win! Game created by Wyatt Amorin";
            gameObject.SetActive(false);
        }
    }

    void SetLifeText()
    {
        lifeText.text = "Life: " + life.ToString();
        if (life == 0)
        {
            winText.text = "Game Over! Game created by Wyatt Amorin";
            gameObject.SetActive(false);
        }
    }

}
