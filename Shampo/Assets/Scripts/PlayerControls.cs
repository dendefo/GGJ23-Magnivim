using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Unit
{
    Camera main;
    [SerializeField] float movingSpeed = 100;
    [SerializeField] float jumpforce = 100;
    [SerializeField] float y;

    [SerializeField] AudioClip[] AttackSounds;
    [SerializeField] AudioClip Cast;

<<<<<<< Updated upstream
=======
    [SerializeField] AudioClip LoseSound;
    bool _lookRight;

    bool alive=true;
    bool lookRight
    {
        get
        {
            return _lookRight;
        }
        set
        {

            //if (_lookRight != value) { if (value) { animator.SetTrigger("Turn_Right"); } else { animator.SetTrigger("Turn_Left"); } }
            _lookRight = value;
            if (_lookRight) transform.GetChild(0).localEulerAngles = Vector3.down * 180;
            else transform.GetChild(0).localEulerAngles = Vector3.zero;
        }
    }
    int jumpCount = 0;


    Animator animator;
    ParticleSystem particle;
>>>>>>> Stashed changes
    //bool lookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript.Player = gameObject;
        main = Camera.main;

<<<<<<< Updated upstream
        //Roof.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, Screen.height)).y);

        //Floor.transform.position = new Vector3(0, main.ScreenToWorldPoint(new(0, 0)).y);

        //LeftBorder.transform.Translate(new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        //Unit.leftBorder = LeftBorder;
        //RightBorder.transform.Translate(-new Vector3(main.ScreenToWorldPoint(new(Screen.width, 0)).x+2, 0));
        //Unit.rightBorder = RightBorder;
        base.Start();
        
=======
        base.Start();
        animator = GetComponentInChildren<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
>>>>>>> Stashed changes

    }

    private void Update()
    {
        base.Update();
        float x = Input.GetAxis("Horizontal") * movingSpeed;
<<<<<<< Updated upstream
        float y = jumpforce * (Input.GetKeyDown(KeyCode.Space) ? 1 : 0);

        //if (x > 0) lookRight = true;
        //else if (x < 0) lookRight = false;
        body.AddRelativeForce(new(x, y));
        main.transform.position = new(transform.position.x, transform.position.y, main.transform.position.z);
=======
        y = jumpforce * (Input.GetKeyDown(KeyCode.Space) ? 1 : 0);
        if (y != 0) jumpCount++;
        if (x > 0) lookRight = true;
        else if (x < 0) lookRight = false;
        if (jumpCount > 2) y = 0;


        if (y!=0){ animator.SetBool("Jump", true); }
        if (x != 0) { animator.SetBool("True", true); }
        body.AddRelativeForce(new(x, y));


        main.transform.position = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position) * 28;
>>>>>>> Stashed changes
        main.transform.rotation = transform.rotation;



<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.Escape)) Time.timeScale = 0;
    }
    

}
=======
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (UnityEngine.SceneManagement.SceneManager.sceneCount == 2)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(3, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                Time.timeScale = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            animator.SetBool("Attack_A",true);
            particle.Play();
            AudioSource.PlayClipAtPoint(AttackSounds[Random.Range(0, 2)], transform.position);
        } //Attack
        if (Input.GetMouseButtonDown(1)) 
        { 
            Debug.Log("Cast");
            animator.SetBool("Cast", true);
            AudioSource.PlayClipAtPoint(Cast, transform.position);
        } //Cast

        if ((stats.CurrentHp <= 0 ||Time.time>100)&&alive)
        {
            animator.SetBool("Death", true);
            GetComponent<AudioSource>().Stop();
            AudioSource.PlayClipAtPoint(LoseSound, transform.position);
            alive = false;
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Head") jumpCount = 0;
        if (collision.transform.tag == "Enemy") animator.SetBool("Hit", true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Weapon")
        {
            stats.GetDamage();
            Destroy(collision.gameObject);
        }

    }


}
>>>>>>> Stashed changes
