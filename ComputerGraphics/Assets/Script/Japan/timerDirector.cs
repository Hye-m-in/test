using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject timer;   // UI Ÿ�̸�
    void Start()
    {
        this.timer = GameObject.Find("timer");
    }

    // parameter�� �־����� ��(amount)��ŭ UI�� �� ���� -> �ð� ����
    public void DecreaseTime(float amount)
    {
        this.timer.GetComponent<Image>().fillAmount -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
