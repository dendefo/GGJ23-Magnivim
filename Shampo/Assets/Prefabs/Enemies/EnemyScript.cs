using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Unit
{
    [SerializeField] EnemyTypes type;
    Vector3 startPosition;
    [SerializeField] float enemySpeed = 7;

    bool sideToMove;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (startPosition.x - transform.position.x > 5) { sideToMove = true; }
        if (startPosition.x - transform.position.x < -5) { sideToMove = false; }
        body.AddForce(enemySpeed * (sideToMove ? Vector2.right : Vector2.left));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Debug.Log("Touch th player");
                
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
    public Rigidbody2D body;
    virtual public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            if (collision.transform.position.x < 0) transform.position = new(rightBorder.transform.position.x - 2, transform.position.y, transform.position.z);
            if (collision.transform.position.x > 0) transform.position = new(leftBorder.transform.position.x + 2, transform.position.y, transform.position.z);
        }
    }
}