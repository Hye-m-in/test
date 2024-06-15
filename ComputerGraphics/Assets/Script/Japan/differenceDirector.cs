using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class differenceDirector : MonoBehaviour
{
    // 틀린 그림 5가지 클릭 판정
    static bool diffCheck01;
    static bool diffCheck02;
    static bool diffCheck03;
    static bool diffCheck04;
    static bool diffCheck05;

    // 정답 판정 오브젝트
    GameObject correct01;
    GameObject correct02;
    GameObject correct03;
    GameObject correct04;
    GameObject correct05;

    // 마우스 클릭 이벤트
    private void OnMouseDown()
    {
        // 클릭한 부분이 틀린 부분이 맞을 경우 클릭 판정 변수를 true로 변경 + 정답 표시 오브젝트 활성화
        if (gameObject.name == "difference01")
        {
            diffCheck01 = true;
        }
        if (gameObject.name == "difference02")
        {
            diffCheck02 = true;
        }
        if (gameObject.name == "difference03")
        {
            diffCheck03 = true;
        }
        if (gameObject.name == "difference04")
        {
            diffCheck04 = true;
        }
        if (gameObject.name == "difference05")
        {
            diffCheck05 = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.correct01 = GameObject.Find("correct01");
        this.correct02 = GameObject.Find("correct02");
        this.correct03 = GameObject.Find("correct03");
        this.correct04 = GameObject.Find("correct04");
        this.correct05 = GameObject.Find("correct05");

        // 게임 시작시 틀린 그림 5가지 클릭 판정 변수를 false로 초기화
        diffCheck01 = diffCheck02 = diffCheck03 = diffCheck04 = diffCheck05 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 오브젝트 비활성화 및 활성화 (diffCheck가 true(찾은 경우)면, 정답 표시 오브젝트 활성화, false(못 찾은 경우)면 비활성화)
        correct01.SetActive(diffCheck01);
        correct02.SetActive(diffCheck02);
        correct03.SetActive(diffCheck03);
        correct04.SetActive(diffCheck04);
        correct05.SetActive(diffCheck05);

        // 틀린 부분을 모두 찾으면 게임 클리어 -> 0.5초 뒤에 클리어 씬으로 이동
        if (diffCheck01 == true & diffCheck02 == true & diffCheck03 == true &
            diffCheck04 == true & diffCheck05 == true)
        {
            // 게임 클리어 씬으로 이동
            PlayerPrefs.SetInt("Japansuccess", 1);
            SceneManager.LoadScene("JapanClearScene");
        }
    }
}