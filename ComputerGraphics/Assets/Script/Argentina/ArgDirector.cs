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

    // 게임 진행 방식 -> 던져진 공을 땅에 닿기전에 리시브 하면 성공 (총 10회 중 6회 성공 시 클리어)
    void Start()
    {
        // 리시브 성공 횟수, 공 개수 초기화
        sucessful = 0;  // 리시브 성공 카운트 변수
        ballNum = 10;   // 던져진 공 개수 카운트 변수 (10개)

        // 점수를 보여주는 UI인 Score
        score = GameObject.Find("Score");

        // BallGenerator을 통해 첫 번째 공이 던져지므로, 공 개수 -1
        ballNum--;
    }
    void Update()
    {
        // 공이 모두 소진되었을 경우
        if (ballNum < 0)
        {
            // 10회 중 6회를 성공하지 못했으므로 게임 오버
            SceneManager.LoadScene("ArgentinaOverScene");
        }
        // 공이 소진되기 전 6회 성공했을 경우
        else if (sucessful >= 6)
        {
            // 6회 성공했으므로 게임 클리어 
            PlayerPrefs.SetInt("ARGsuccess", 1);
            SceneManager.LoadScene("ArgentinaClearScene");
        }
    }

    // 리시브 성공시 수행되는 함수
    public void Sucess()
    {
        
        sucessful++;    // 리시브 성공 횟수 +1        
        ballNum--;      // 공 개수 -1        
        UpdateScore();  // UI 업데이트 -> 바뀐 성공 횟수로 변경

        // BallGenerator 스크립트에서 Ball 생성 함수인 LaunchBall() 호출
        GameObject generator = GameObject.Find("BallGenerator");
        generator.GetComponent<BallGenerator>().LaunchBall();
    }

    // 리시브 실패시 수행되는 함수
    public void Fail()
    {
        ballNum--;      // 공 개수 -1

        // BallGenerator 스크립트에서 Ball 생성 함수인 LaunchBall() 호출
        GameObject generator = GameObject.Find("BallGenerator");
        generator.GetComponent<BallGenerator>().LaunchBall();
    }

    // UI 업데이트 함수
    void UpdateScore()
    {
        // 두 자리 정수로 변환하여 UI 업데이트
        score.GetComponent<TextMeshProUGUI>().text = sucessful.ToString("00");
    }
}
