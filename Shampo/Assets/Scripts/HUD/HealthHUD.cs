using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Image[] Hearts;

    public Slider slider;
    public int hp;

    [SerializeField] AudioClip HPLoss;
    private void Start()
    {
        hp = LevelManagerScript.Player.GetComponent<PlayerControls>().stats.CurrentHp;
    }
    void Update()
    {

        if (LevelManagerScript.Player.GetComponent<PlayerControls>().stats.CurrentHp == hp) return;
        hp = LevelManagerScript.Player.GetComponent<PlayerControls>().stats.CurrentHp;
        AudioSource.PlayClipAtPoint(HPLoss, LevelManagerScript.Player.transform.position);
        for (int i = 0; i < 5; i++)
        {
            if (i < LevelManagerScript.Player.GetComponent<PlayerControls>().stats.CurrentHp)
            { Hearts[i].color = new(255, 255, 0); }
            else Hearts[i].color = new(0, 0, 0);
        }


    }

}
