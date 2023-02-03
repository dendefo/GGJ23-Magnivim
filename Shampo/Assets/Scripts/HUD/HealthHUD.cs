using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public int Health;
    public int NumOfHearts;

    public Image[] Hearts;
    public Sprite FullHeart;

    public Slider slider;
    
    void Update()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (Health > NumOfHearts)
            {
                Health = NumOfHearts;
            }
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = null;
            }
            if (i > NumOfHearts)
            {
                Hearts[i].enabled = true;
            }
        }
    }

    public void SetHealth(int health)
    {
        health = Health;
        slider.value = Health;
    }
}
