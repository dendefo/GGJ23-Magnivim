using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Unit
{
    [SerializeField] EnemyTypes type;
    Vector3 startPosition;
    [SerializeField] float enemySpeed = 7;
    [SerializeField] GameObject prefabFireBall;

    float lastTime;
    bool sideToMove;
    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript.Enemies.Add(gameObject);
        base.Start();
        startPosition = transform.position;
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
                stats = new(1,0);
                break;
            case EnemyTypes.Acid:
                stats = new(4, 2);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Movement();
        if (lastTime > 1)
        {
            lastTime = 0;
            Attack();
        }
    }

    void Movement()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, LevelManagerScript.Player.transform.position- transform.position);
        if (hit != null)
        {
            if (hit.transform.tag == "Player")
            {
                if (Mathf.Abs(LevelManagerScript.Player.GetComponent<PlayerControls>().z - z) < z+360-LevelManagerScript.Player.GetComponent<PlayerControls>().z) { sideToMove = true; }
                else { sideToMove = false; }
                body.AddRelativeForce(enemySpeed * (sideToMove ? Vector2.right : Vector2.left));
            }
        }
        
    }

    void Attack()
    {
        var temp = Instantiate<GameObject>(prefabFireBall,new Vector2(transform.position.x,transform.position.y)+ (sideToMove ? Vector2.right : Vector2.left),new Quaternion(),transform);
        temp.transform.parent = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Debug.Log("Touch the player");
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.point.y > transform.position.y) Debug.Log("Enemy Died");
                return;
            }
            Debug.Log("Player Died");
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
    [SerializeField] protected Stats stats;
    [SerializeField] public float z;
    [SerializeField] float Acos;
    [SerializeField] Vector3 norm;
    GameObject copy = null;
    virtual public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    virtual public void Update()
    {

        norm = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position);
        Acos = Mathf.Acos(norm.y);
        z = Acos/Mathf.PI * ((transform.position.x >= 0) ? -180 : 180);
        if (z < 0) z += 360;

        transform.localEulerAngles = new Vector3(0, 0, z);

        body.AddRelativeForce(Vector2.down * 5 * body.mass);
    }

    [System.Serializable]
    public struct Stats
    {
        public float MaxHP;
        public float CurrentHp;
        public float Damage;

        public Stats(float maxHP, int damage)
        {
            MaxHP = maxHP;
            CurrentHp = maxHP;
            Damage = damage;
        }
    }
}