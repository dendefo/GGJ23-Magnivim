using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    static public List<GameObject> Hairs = new();
    static public List<GameObject> Enemies = new();
    static public int EnemyCount = 0;
    static public GameObject Player;

    static public GameObject Head;
<<<<<<< Updated upstream
    
    void Start()
    {
=======


    void Start()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
>>>>>>> Stashed changes
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        foreach (var enemy in Enemies)
        {
            if (enemy == null) continue;
            if (!enemy.active && Time.time - enemy.GetComponent<EnemyScript>().DieTime > 2) { enemy.SetActive(true); enemy.GetComponent<EnemyScript>().stats = new(4, 2); }
        }
>>>>>>> Stashed changes
    }
}
