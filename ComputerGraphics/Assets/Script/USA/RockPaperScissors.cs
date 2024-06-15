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

    //��� ���� �Ǵ� ����
    private bool isWaiting = false; 

    //�ָ� ��ư Ŭ�� �Լ�
    public void OnRockButtonClick()  
    {
        if (!isWaiting)
        {
            user.sprite = rock;
            SetComHand();
            fight();
        }
    }

    //���� ��ư Ŭ�� �Լ�
    public void OnScissorsButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = scissors;
            SetComHand();
            fight();
        }
    }

    //���ڱ� ��ư Ŭ�� �Լ�
    public void OnPaperButtonClick()
    {
        if (!isWaiting)
        {
            user.sprite = paper;
            SetComHand();
            fight();
        }
    }

    //��ǻ�� �� ��� ���� �Լ�
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

    //�¸� ���� �Լ�
    void fight()
    {
        string result_text = "";
        
        if (user.sprite == com.sprite) //���� �̹����� Draw ���
        {
            result_text = "Draw";
        }
        else if((user.sprite == rock && com.sprite == scissors) ||
                (user.sprite == scissors && com.sprite == paper) ||
                (user.sprite == paper && com.sprite == rock))  //�÷��̾ �̱�� ����
        {
            result_text = "Win";
            user_count += 1;
        }
        else
        {
            result_text = "Lose";
            com_count += 1;
        }

        this.result.GetComponent<TextMeshProUGUI>().text = result_text; //��� �ؽ�Ʈ ���
        this.count.GetComponent<TextMeshProUGUI>().text = user_count.ToString() + " : " + com_count.ToString(); //���� ī��Ʈ ���

        StartCoroutine(WaitAndReset(1.0f));
        
    }

    public void SceneChange()
    {
        if (user_count == 3) //������ 3�� �̱�� Clear ������ ��ȯ
        {
            Wait(3.0f);
            PlayerPrefs.SetInt("USAsuccess", 1);
            SceneManager.LoadScene("RSCClearScene");
        }
        else if (com_count == 3) //��ǻ�Ͱ� 3�� �̱�� Over������ ��ȯ
        {
            Wait(3.0f);
            SceneManager.LoadScene("RSCOverScene");
        }
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // ������ �ð� ���� ���
    }

    IEnumerator WaitAndReset(float waitTime)  //��� �� ��� �̹���, �ؽ�Ʈ �ʱ�ȭ
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