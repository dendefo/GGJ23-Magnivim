using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public bool GoRight = true;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(LevelManagerScript.Head.transform.position, Vector3.forward, 0.05f*(!GoRight ? 1 : -1));
        if (Time.time - time > 3) Destroy(gameObject);
    }
}
