using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class RockPaperSissors : MonoBehaviour
{
    public Image user;
    public Image com;

    public Sprite rock;
    public Sprite scissors;
    public Sprite paper;
    public Sprite question;

    public GameObject result;
    public GameObject count;

    int user_count = 0;
    int com_count = 0;

    //대기 상태 판단 변수
    private bool isWaiting = false; 

    //주먹 버튼 클릭 함수
    public void OnRockButtonClick()  
    {
        if (!isWaiting)
        {
            user.sprite = rock;
            SetComHand();
            fight();
        }
    }

    //가위 버튼 클릭 함수
    public void OnScissorsButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = scissors;
            SetComHand();
            fight();
        }
    }

    //보자기 버튼 클릭 함수
    public void OnPaperButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = paper;
            SetComHand();
            fight();
        }
    }

    //컴퓨터 손 모양 결정 함수
    private void SetComHand()
    {
        int randomHand = Random.Range(0, 3);
        switch (randomHand)
        {
            case 0:
                com.sprite = rock;
                break;
            case 1:
                com.sprite = scissors;
                break;
            case 2:
                com.sprite = paper;
                break;
        }
    }

    //승리 판정 함수
    void fight()
    {
        string result_text = "";
        
        if (user.sprite == com.sprite) //같은 이미지면 Draw 출력
        {
            result_text = "Draw";
        }
        else if((user.sprite == rock && com.sprite == scissors) ||
                (user.sprite == scissors && com.sprite == paper) ||
                (user.sprite == paper && com.sprite == rock))  //플레이어가 이기는 경우들
        {
            result_text = "Win";
            user_count += 1;
        }
        else
        {
            result_text = "Lose";
            com_count += 1;
        }

        this.result.GetComponent<TextMeshProUGUI>().text = result_text; //결과 텍스트 출력
        this.count.GetComponent<TextMeshProUGUI>().text = user_count.ToString() + " : " + com_count.ToString(); //승패 카운트 출력

        StartCoroutine(WaitAndReset(1.0f));
        
    }

    public void SceneChange()
    {
        if (user_count == 3) //유저가 3판 이기면 Clear 씬으로 전환
        {
            Wait(3.0f);
            PlayerPrefs.SetInt("USAsuccess", 1);
            SceneManager.LoadScene("RSCClearScene");
        }
        else if (com_count == 3) //컴퓨터가 3판 이기면 Over씬으로 전환
        {
            Wait(3.0f);
            SceneManager.LoadScene("RSCOverScene");
        }
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 지정된 시간 동안 대기
    }

    IEnumerator WaitAndReset(float waitTime)  //대기 후 결과 이미지, 텍스트 초기화
    {
        if((user_count != 3) && (com_count != 3)){
            isWaiting = true;
            yield return new WaitForSeconds(waitTime);
            user.sprite = question;
            com.sprite = question;
            this.result.GetComponent<TextMeshProUGUI>().text = "";
            isWaiting = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.result = GameObject.Find("Text_Result");
        this.count = GameObject.Find("Text_Count");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            SceneChange();
        }
    }
}