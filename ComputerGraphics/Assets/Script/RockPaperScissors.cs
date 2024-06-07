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

    private bool isWaiting = false; //대기 상태 판단 변수

    public void OnRockButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = rock;
            SetComHand();
            fight();
        }
    }
    public void OnScissorsButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = scissors;
            SetComHand();
            fight();
        }
    }
    public void OnPaperButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = paper;
            SetComHand();
            fight();
        }
    }

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

    void fight()
    {
        string result_text = "";
        
        if (user.sprite == com.sprite)
        {
            result_text = "Draw";
        }
        else if((user.sprite == rock && com.sprite == scissors) ||
                (user.sprite == scissors && com.sprite == paper) ||
                (user.sprite == paper && com.sprite == rock))
        {
            result_text = "Win";
            user_count += 1;
        }
        else
        {
            result_text = "Lose";
            com_count += 1;
        }

        this.result.GetComponent<TextMeshProUGUI>().text = result_text;
        this.count.GetComponent<TextMeshProUGUI>().text = user_count.ToString() + " : " + com_count.ToString();

        WaitAndReset(1.0f);
        
    }
    public void SceneChange()
    {
        if (user_count == 3) //유저가 3판 이기면 Clear 씬으로 전환
        {
            Wait(3.0f);
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

    IEnumerator WaitAndReset(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        user.sprite = question;
        com.sprite = question;
        this.result.GetComponent<TextMeshProUGUI>().text = "";
        isWaiting = false;
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
        SceneChange();
    }
}
/* 
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

    public void OnRockButtonClick()
    {
        user.sprite = rock;
        SetComHand();
        fight();
    }
    public void OnScissorsButtonClick()
    {
        user.sprite = scissors;
        SetComHand();
        fight();
    }
    public void OnPaperButtonClick()
    {
        user.sprite = paper;
        SetComHand();
        fight();
    }

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

    void fight()
    {
        string result_text = "";
        
        if (user.sprite == com.sprite)
        {
            result_text = "Draw";
        }
        else if((user.sprite == rock && com.sprite == scissors) ||
                (user.sprite == scissors && com.sprite == paper) ||
                (user.sprite == paper && com.sprite == rock))
        {
            result_text = "Win";
            user_count += 1;
        }
        else
        {
            result_text = "Lose";
            com_count += 1;
        }

        this.result.GetComponent<TextMeshProUGUI>().text = result_text;
        this.count.GetComponent<TextMeshProUGUI>().text = user_count.ToString() + " : " + com_count.ToString();

        WaitAndLoadScene(3.0f);
        user.sprite = question;
        com.sprite = question;
    }

    public void Reset()
    {
        
    }
    public void SceneChange()
    {
        if (user_count == 3) //유저가 3판 이기면 Clear 씬으로 전환
        {
            WaitAndLoadScene(3.0f);
            SceneManager.LoadScene("RSCClearScene");
        }
        else if (com_count == 3) //컴퓨터가 3판 이기면 Over씬으로 전환
        {
            WaitAndLoadScene(3.0f);
            SceneManager.LoadScene("RSCOverScene");
        }
    }
    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 지정된 시간 동안 대기
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
        SceneChange();
    }
}
 */