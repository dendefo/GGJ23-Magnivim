using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Unit
{
    [SerializeField] EnemyTypes type;
    [SerializeField] float enemySpeed = 7;
    [SerializeField] GameObject prefabFireBall;


    [SerializeField] GameObject prefabAcid;
    [SerializeField] GameObject prefabFire;
    [SerializeField] GameObject prefabPlague;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip deathAcid;
    [SerializeField] AudioClip FireballSound;
    float lastTime;
    bool sideToMove;
    int Life = 1;
    Animator animator;

    public float DieTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        LevelManagerScript.Enemies.Add(gameObject);
        base.Start();

        LevelManagerScript.EnemyCount++;
       
        lastTime += Time.deltaTime;
        switch (type)
        {
            case EnemyTypes.Regular:
                stats = new(1, 1);
                break;
            case EnemyTypes.Fire:
                stats = new(2, 2);
                break;
            case EnemyTypes.Pestilent:
                stats = new(4, 2);
                Life = 1;
                break;
            case EnemyTypes.Acid:
                stats = new(1, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Movement();
        lastTime += Time.deltaTime;
        if (lastTime > 1)
        {
            lastTime = 0;
            if (type == EnemyTypes.Fire) Attack();
        }
    }

    void Movement()
    {
        if (transform.position.x - LevelManagerScript.Player.transform.position.x < 0) { sideToMove = true; }
        if (transform.position.x - LevelManagerScript.Player.transform.position.x > 0) { sideToMove = false; }
<<<<<<< Updated upstream
        body.AddRelativeForce(enemySpeed * (sideToMove ? Vector2.right : Vector2.left));
=======

        if (sideToMove) transform.GetChild(0).localEulerAngles = Vector3.down * 180;
        else transform.GetChild(0).localEulerAngles = Vector3.zero;

        body.AddRelativeForce(enemySpeed * (sideToMove ? Vector2.right : Vector2.left));
        
>>>>>>> Stashed changes
    }

    void Attack()
    {
        animator.SetBool("Cast",true);
        var temp = Instantiate<GameObject>(prefabFireBall, transform.localPosition + (sideToMove ? transform.forward : transform.forward*-1), new Quaternion(), transform);
        temp.transform.parent = null;
        temp.GetComponent<FireballScript>().GoRight = sideToMove;
        AudioSource.PlayClipAtPoint(FireballSound, temp.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == EnemyTypes.Acid)
            {
                Debug.Log("Hit");
                collision.gameObject.GetComponent<PlayerControls>().stats.GetDamage();
                Instantiate(prefabAcid, transform.position, transform.rotation).transform.localScale = Vector3.one * 0.2f;
                AudioSource.PlayClipAtPoint(deathAcid, transform.position);
                Destroy(gameObject);
            }
            if (type == EnemyTypes.Pestilent)
            {
                Debug.Log("Hit");
                collision.gameObject.GetComponent<PlayerControls>().stats.GetDamage();

            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Players Attack")
        {
            Debug.Log("Hit");
            stats.GetDamage();
            if (stats.CurrentHp == 0)
            {
                switch (type)
                {
                    case EnemyTypes.Fire:
                        Instantiate(prefabFire, transform.position, transform.rotation).transform.localScale = Vector3.one * 0.2f;
                        AudioSource.PlayClipAtPoint(deathSound, transform.position);
                        Destroy(gameObject);
                        break;
                    case EnemyTypes.Pestilent:
                        
                        gameObject.SetActive(false);
                        DieTime = Time.time;
                        AudioSource.PlayClipAtPoint(deathSound, transform.position);
                        if (Life == 0) Destroy(gameObject);
                        Life--;
                        Instantiate(prefabPlague, transform.position, transform.rotation).transform.localScale = Vector3.one * 0.2f;

                        break;
                    case EnemyTypes.Acid:
                        Instantiate(prefabAcid, transform.position, transform.rotation).transform.localScale = Vector3.one * 0.2f;
                        AudioSource.PlayClipAtPoint(deathAcid, transform.position);
                        Destroy(gameObject);
                        break;
                }
            }
        }
    }
}
enum EnemyTypes
{
    Regular,
    Fire,
    Pestilent,
    Acid
}

public class Unit : MonoBehaviour
{
    public static GameObject leftBorder;
    public static GameObject rightBorder;
    protected Rigidbody2D body;
<<<<<<< Updated upstream
    [SerializeField] protected Stats stats;
=======
    [SerializeField] public Stats stats;
>>>>>>> Stashed changes
    [SerializeField] float z;
    [SerializeField] float Acos;
    [SerializeField] Vector3 norm;
    GameObject copy = null;
    virtual public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {

            if (collision.transform.position.x < 0)
            {
                copy = Instantiate(gameObject, new Vector3(rightBorder.transform.position.x - 2, transform.position.y, transform.position.z), new Quaternion());
                copy.GetComponent<Unit>().copy = gameObject;
            }
            if (collision.transform.position.x > 0)
            {
                copy = Instantiate(gameObject, new(leftBorder.transform.position.x + 2, transform.position.y, transform.position.z), new Quaternion());
                copy.GetComponent<Unit>().copy = gameObject;
            }
        }
    }

    virtual public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {

        }
    }

    virtual public void Update()
    {

        //transform.RotateAround(LevelManagerScript.Head.transform.position, Vector3.forward, 1);
        norm = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position);
        Acos = Mathf.Acos(norm.y);
<<<<<<< Updated upstream
        z = Acos/Mathf.PI * ((transform.position.x >= 0) ? -180 : 180);
=======
        z = Acos / Mathf.PI * ((transform.position.x >= 0) ? -180 : 180);
>>>>>>> Stashed changes

        transform.localEulerAngles = new Vector3(0, 0, z);

        body.AddRelativeForce(Vector2.down * 3 * body.mass);
    }

    [System.Serializable]
    public struct Stats
    {
        public int MaxHP;
        public int CurrentHp;
        public int Damage;

        public Stats(int maxHP, int damage)
        {
            MaxHP = maxHP;
            CurrentHp = maxHP;
            Damage = damage;
        }
        public void GetDamage()
        {
            CurrentHp--;
        }
    }
}