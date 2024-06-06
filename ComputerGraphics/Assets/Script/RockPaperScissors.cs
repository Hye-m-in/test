using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    public Image user;
    public Image com;

    public Sprite rock;
    public Sprite scissors;
    public Sprite paper;

    public GameObject result;

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
        else if (user.sprite == rock)
        {
            result_text = (com.sprite == paper) ? "Lose" : "Win";
        }
        else if (user.sprite == scissors)
        {
            result_text = (com.sprite == rock) ? "Lose" : "Win";
        }
        else if (user.sprite == paper)
        {
            result_text = (com.sprite == scissors) ? "Lose" : "Win";
        }
        this.result.GetComponent<TextMeshProUGUI>().text = result_text;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.result = GameObject.Find("Text_Result");
    }

    // Update is called once per frame
    void Update()
    {

    }
}