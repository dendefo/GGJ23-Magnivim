using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float movingSpeed = 100;
    [SerializeField] float jumpforce = 100;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal")*movingSpeed;
        float y = jumpforce*(Input.GetKeyDown(KeyCode.Space) ? 1 : 0);

        body.AddForce(new(x, y));
    }
}
