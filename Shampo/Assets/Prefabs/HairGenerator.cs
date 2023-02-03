using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float length = 1;

    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript.Hairs.Add(gameObject);
        var current = gameObject;
        for (int i = 0; i < length; i++)
        {
            current = current.transform.GetChild(0).gameObject;
            var child = Instantiate(current, current.transform);
            child.GetComponent<HingeJoint2D>().connectedBody = current.GetComponent<Rigidbody2D>();
            child.transform.localPosition = Vector3.up * 0.9f;
            child.transform.localScale = Vector3.one * 0.9f;
            child.GetComponent<Rigidbody2D>().mass = 0.9f * current.GetComponent<Rigidbody2D>().mass;

        }
        body = transform.GetChild(0).GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<HingeJoint2D>().enabled = false;
        body.constraints = RigidbodyConstraints2D.FreezePositionX;
        body.mass = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 norm = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position);
        float Acos = Mathf.Acos(norm.y);
        float z = Acos / Mathf.PI * ((transform.position.x >= 0) ? -180 : 180);
        if (z < 0) z += 360;

        transform.localEulerAngles = new Vector3(0, 0, z);

        body.AddRelativeForce(Vector2.down * 5 * body.mass);
    }
}
