using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Unit
{
    Camera main;
    Rigidbody2D body;
    [SerializeField] float movingSpeed = 100;
    [SerializeField] float jumpforce = 100;

    [SerializeField] GameObject LeftBorder;
    [SerializeField] GameObject RightBorder;
    [SerializeField] GameObject Roof;
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Background;

    bool lookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
        main = Camera.main;

        Roof.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, Screen.height)).y);

        Floor.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, 0)).y);

        LeftBorder.transform.Translate(new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        Unit.leftBorder = LeftBorder;
        RightBorder.transform.Translate(-new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        Unit.rightBorder = RightBorder;
        base.Start();
        body = GetComponent<Rigidbody2D>();
        

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
    

}
