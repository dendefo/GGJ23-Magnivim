using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounterHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        foreach (var enemy in LevelManagerScript.Enemies)
        {
            if (enemy != null) i++;
            
        }
        GetComponentInChildren<TMP_Text>().text = $"Enemies Left {i}/{LevelManagerScript.EnemyCount}";
    }
}
