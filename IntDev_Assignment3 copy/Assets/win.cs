using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public bool playerWin = false;

    public GameObject winText;
    public GameObject textBG;

    public Rigidbody2D body;
    public Rigidbody2D leftHand;
    public Rigidbody2D rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin == true)
        {
            winText.SetActive(true);
            textBG.SetActive(true);

            body.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            body.GetComponent<Rigidbody2D>().gravityScale = 0;
            leftHand.GetComponent<Rigidbody2D>().gravityScale = 0;
            rightHand.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            playerWin = true;
        }
    }
}
