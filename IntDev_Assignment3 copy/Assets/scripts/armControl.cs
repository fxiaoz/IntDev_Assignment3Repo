using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControl : MonoBehaviour
{
    public Rigidbody2D leftarmBody;
    public Rigidbody2D rightarmBody;
    public Rigidbody2D mainBody;

    public float power = 2f;

    public bool leftarmUsed = false;
    public bool rightarmUsed = false;

    public bool playerLose = false;

    public GameObject loseText;
    public GameObject textBG;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftarmBody.velocity = Vector3.zero;
        rightarmBody.velocity = Vector3.zero;
        mainBody.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            leftarmUsed = true;
        }

        else
        {
            leftarmUsed = false;
        }


        if (Input.GetKey(KeyCode.D))
        {
            rightarmUsed = true;
        }

        else
        {
            rightarmUsed = false;
        }


        if (leftarmUsed == true && Input.GetKey(KeyCode.LeftArrow))
        {
            leftarmBody.velocity = new Vector3(-power, 0, 0);
        }

        if (leftarmUsed == true && Input.GetKey(KeyCode.RightArrow))
        {
            leftarmBody.velocity = new Vector3(power, 0, 0);
        }

        if (leftarmUsed == true && Input.GetKey(KeyCode.UpArrow))
        {
            leftarmBody.velocity = new Vector3(0, power, 0);
        }

        if (leftarmUsed == true && Input.GetKey(KeyCode.DownArrow))
        {
            leftarmBody.velocity = new Vector3(0, -power, 0);
        }



        if (rightarmUsed == true && Input.GetKey(KeyCode.LeftArrow))
        {
            rightarmBody.velocity = new Vector3(-power, 0, 0);
        }

        if (rightarmUsed == true && Input.GetKey(KeyCode.RightArrow))
        {
            rightarmBody.velocity = new Vector3(power, 0, 0);
        }

        if (rightarmUsed == true && Input.GetKey(KeyCode.UpArrow))
        {
            rightarmBody.velocity = new Vector3(0, power, 0);
        }

        if (rightarmUsed == true && Input.GetKey(KeyCode.DownArrow))
        {
            rightarmBody.velocity = new Vector3(0, -power, 0);
        }


        if (transform.position.y <= -9)
        {
            playerLose = true;
            loseText.SetActive(true);
            textBG.SetActive(true);

            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            leftarmBody.GetComponent<Rigidbody2D>().gravityScale = 0;
            rightarmBody.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
