using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float length = 1;
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

    }
}
