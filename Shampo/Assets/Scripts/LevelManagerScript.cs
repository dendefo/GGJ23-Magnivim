using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public List<GameObject> Hairs = new();
    static public List<GameObject> Enemies = new();
    static public GameObject Player;

    static public GameObject Head;

    [SerializeField] UnityEngine.UI.Image background;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //background.rectTransform.eulerAngles = new (0,0,Player.transform.rotation.eulerAngles.z);
    }
}
