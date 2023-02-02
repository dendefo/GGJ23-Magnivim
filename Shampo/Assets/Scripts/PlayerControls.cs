using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D body;
    Camera main;

    [SerializeField] float movingSpeed = 100;
    [SerializeField] float jumpforce = 100;

    [SerializeField] GameObject leftBorder;
    [SerializeField] GameObject rightBorder;
    [SerializeField] GameObject Roof;
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Background;

    bool lookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        body = GetComponent<Rigidbody2D>();

        Roof.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, Screen.height)).y);
        Floor.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, 0)).y);
        leftBorder.transform.Translate(new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        rightBorder.transform.Translate(-new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
    }

    private void Update()
    {

        float x = Input.GetAxis("Horizontal") * movingSpeed;
        float y = jumpforce * (Input.GetKeyDown(KeyCode.Space) ? 1 : 0);

        if (x > 0) lookRight = true;
        else if (x < 0) lookRight = false;
        body.AddForce(new(x, y));

        main.transform.position = new(transform.position.x + (lookRight ? 2 : -2), 0, main.transform.position.z);



        if (Input.GetKeyDown(KeyCode.Escape)) Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            if (collision.transform.position.x < 0) transform.position = new(rightBorder.transform.position.x - 2, transform.position.y, transform.position.z);
            if (collision.transform.position.x > 0) transform.position = new(leftBorder.transform.position.x + 2, transform.position.y, transform.position.z);
        }
    }

}
