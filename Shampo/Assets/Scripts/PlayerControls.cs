using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Unit
{
    Camera main;
    [SerializeField] float movingSpeed = 100;
    [SerializeField] float jumpforce = 100;

    [SerializeField] GameObject LeftBorder;
    [SerializeField] GameObject RightBorder;
    [SerializeField] GameObject Roof;
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Background;

    //bool lookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript.Player = gameObject;
        main = Camera.main;

        //Roof.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, Screen.height)).y);

        //Floor.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, 0)).y);

        //LeftBorder.transform.Translate(new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        //Unit.leftBorder = LeftBorder;
        //RightBorder.transform.Translate(-new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        //Unit.rightBorder = RightBorder;
        base.Start();
        

    }

    private void Update()
    {
        base.Update();
        float x = Input.GetAxis("Horizontal") * movingSpeed;
        float y = jumpforce * (Input.GetKeyDown(KeyCode.Space) ? 1 : 0);

        //if (x > 0) lookRight = true;
        //else if (x < 0) lookRight = false;
        body.AddRelativeForce(new(x, y));
        main.transform.position = new(transform.position.x, transform.position.y, main.transform.position.z);
        main.transform.rotation = transform.rotation;



        if (Input.GetKeyDown(KeyCode.Escape)) Time.timeScale = 0;
    }
    

}
