using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGrab : MonoBehaviour
{
    public bool grabHold;

    //private Animator anim;

    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("grabHold", grabHold);

        if (grabHold)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            body.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 8;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hold")
        {
            grabHold = true;
            Debug.Log("grab");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hold")
        {
            grabHold = false;
        }
    }
}
