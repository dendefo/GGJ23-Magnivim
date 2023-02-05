using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float length = 1;
<<<<<<< Updated upstream
=======

    [SerializeField] Rigidbody2D body;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript.Hairs.Add(gameObject);
        var current = gameObject;
        for (int i = 0; i < length; i++)
        {
            current = current.transform.GetChild(0).gameObject;
            var child = Instantiate(current, current.transform).GetComponent<HingeJoint2D>().connectedBody = current.GetComponent<Rigidbody2D>();
            child.transform.localPosition = Vector3.up * 0.9f;
            child.transform.localScale = Vector3.one * 0.9f;

        }
        transform.GetChild(0).GetComponent<HingeJoint2D>().enabled = false;
        transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        transform.GetChild(0).GetComponent<Rigidbody2D>().mass = 1000;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        Vector3 norm = Vector3.Normalize(transform.position - LevelManagerScript.Head.transform.position);
        float Acos = Mathf.Acos(norm.y);
        float z = Acos / Mathf.PI * ((transform.position.x >= 0) ? -180 : 180);

        transform.localEulerAngles = new Vector3(0, 0, z);
>>>>>>> Stashed changes

    }
}
