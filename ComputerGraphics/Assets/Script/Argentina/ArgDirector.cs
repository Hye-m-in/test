using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ArgDirector : MonoBehaviour
{
    public int sucessful;
    public int ballNum;
    GameObject score;    

    // ���� ���� ��� -> ������ ���� ���� ������� ���ú� �ϸ� ���� (�� 10ȸ �� 6ȸ ���� �� Ŭ����)
    void Start()
    {
        // ���ú� ���� Ƚ��, �� ���� �ʱ�ȭ
        sucessful = 0;  // ���ú� ���� ī��Ʈ ����
        ballNum = 10;   // ������ �� ���� ī��Ʈ ���� (10��)

        // ������ �����ִ� UI�� Score
        score = GameObject.Find("Score");

        // BallGenerator�� ���� ù ��° ���� �������Ƿ�, �� ���� -1
        ballNum--;
    }
    void Update()
    {
        // ���� ��� �����Ǿ��� ���
        if (ballNum < 0)
        {
            // 10ȸ �� 6ȸ�� �������� �������Ƿ� ���� ����
            SceneManager.LoadScene("ArgentinaOverScene");
        }
        // ���� �����Ǳ� �� 6ȸ �������� ���
        else if (sucessful >= 6)
        {
            // 6ȸ ���������Ƿ� ���� Ŭ���� 
            PlayerPrefs.SetInt("ARGsuccess", 1);
            SceneManager.LoadScene("ArgentinaClearScene");
        }
    }

    // ���ú� ������ ����Ǵ� �Լ�
    public void Sucess()
    {
        
        sucessful++;    // ���ú� ���� Ƚ�� +1        
        ballNum--;      // �� ���� -1        
        UpdateScore();  // UI ������Ʈ -> �ٲ� ���� Ƚ���� ����

        // BallGenerator ��ũ��Ʈ���� Ball ���� �Լ��� LaunchBall() ȣ��
        GameObject generator = GameObject.Find("BallGenerator");
        generator.GetComponent<BallGenerator>().LaunchBall();
    }

    // ���ú� ���н� ����Ǵ� �Լ�
    public void Fail()
    {
        ballNum--;      // �� ���� -1

        // BallGenerator ��ũ��Ʈ���� Ball ���� �Լ��� LaunchBall() ȣ��
        GameObject generator = GameObject.Find("BallGenerator");
        generator.GetComponent<BallGenerator>().LaunchBall();
    }

    // UI ������Ʈ �Լ�
    void UpdateScore()
    {
        // �� �ڸ� ������ ��ȯ�Ͽ� UI ������Ʈ
        score.GetComponent<TextMeshProUGUI>().text = sucessful.ToString("00");
    }
}
