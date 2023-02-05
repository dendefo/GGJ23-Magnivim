using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHUD : MonoBehaviour
{
    UnityEngine.UI.Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (100 - Time.time) / 100;
    }
}
