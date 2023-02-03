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

    int JumpCounter = 0;

    //bool lookRight = true;

    // Start is called before the first frame update

    void Start()
    {
        LevelManagerScript.Player = gameObject;
        main = Camera.main;
        base.Start();

    }

    private void Update()
    {

        base.Update();
        float x = Input.GetAxis("Horizontal") * movingSpeed;
        float y = jumpforce * (Input.GetKeyDown(KeyCode.Space) ? 1 : 0); //Jump

        if (y > 0) JumpCounter++;
        if (JumpCounter >= 2) y = 0;


        body.AddRelativeForce(new(x, y));
        main.transform.localPosition = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position)*27.5f;
        main.transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Escape)) Time.timeScale = 0;  //Pause

        if (Input.GetMouseButtonDown(0)) { } // Attack

        if (Input.GetMouseButtonDown(1)) { } // Cast
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Head") JumpCounter = 0;
    }
}
