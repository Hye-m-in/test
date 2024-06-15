using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGenerator : MonoBehaviour
{
    private float gameTime = 20.0f;   // 제한 시간 20초
    float sec = 0.0f;                 // 게임 시작시 씬 전환과 동시에 타이머 시작 방지 초 카운트 변수

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // UI디렉터 스크립트
        GameObject director = GameObject.Find("timerDirector");

        // 시간 재기
        sec += Time.deltaTime;

        // 게임 씬 전환되자마자 시간 카운팅하는 것을 방지하기 위해 1초 뒤 카운팅 시작
        if (sec >= 1)
        {
            // 게임 시간 종료
            if (gameTime < 0)
            {
                // 시간 내에 틀린 부분을 모두 찾지 못했으므로 게임 오버 -> 0.5초 뒤 게임 오버 씬 이동
                SceneManager.LoadScene("JapanOverScene");
            }
            // 게임 시간 미 종료
            else
            {
                // 1초가 지날 때마다 타이머를 1씩 감소 시킨다.
                gameTime -= Time.deltaTime;
                director.GetComponent<timerDirector>().DecreaseTime(1 / (20 / Time.deltaTime));
            }
        }
    }
}