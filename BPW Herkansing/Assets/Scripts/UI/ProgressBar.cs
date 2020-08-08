using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public float FillSpeed = 1.0f;
    private float targetProgress = 0;

    public static float progressvalue;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    private void Update()
    {
        targetProgress = progressvalue;
        slider.value = progressvalue;

    }

}
