using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Countdown : MonoBehaviour
{
    public bool isFinish = true;
    
    public TMP_Text timer;
    [SerializeField] private float time = 15f;
    public static Countdown instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (!isFinish)
        {
            time -= Time.deltaTime;

            if (time <= 0f)
            {
                time = 0f;
                isFinish = true;
                RegionCollider.instance.control = true;
            }
            countdowntext();
        }
        else if (isFinish && RegionCollider.instance.generate)
        {
            time = 15f;
            isFinish = false;
            
        }
    }

    private void countdowntext()
    {
        int seconds = Mathf.CeilToInt(time);
        timer.text = "   Time: " + seconds;

    }
}
