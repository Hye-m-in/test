using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject timer;   // UI 타이머
    void Start()
    {
        this.timer = GameObject.Find("timer");
    }

    // parameter로 주어지는 양(amount)만큼 UI의 양 감소 -> 시간 감소
    public void DecreaseTime(float amount)
    {
        this.timer.GetComponent<Image>().fillAmount -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
