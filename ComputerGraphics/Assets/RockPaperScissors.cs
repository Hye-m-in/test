using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    enum Hands
    {
        none = 0,
        Rock = 1,
        Scisscors = 2,
        Paper = 3,
    }
    enum results
    {
        idle = 0,
        Win = 1,
        Lose = 2,
        Draw = 3
    }
    GameObject Obj_User;
    GameObject Obj_Com;

    Text Text_result;

    Hands user_hand = Hands.Rock; // ������ �� ��
    Hands com_hand = Hands.Rock; // ��ǻ�Ͱ� �� ��


    //1. ����(Input) - �ڽ��� �� ���а��� �Է��Ѵ�.
    void InputUserHand()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            user_hand = Hands.Rock;
            Debug.Log(user_hand);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            user_hand = Hands.Scisscors;
            Debug.Log(user_hand);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            user_hand = Hands.Paper;
            Debug.Log(user_hand);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"����ڰ� ������ �� ���� �����߽��ϴ�. {user_hand}");
            SetComHand();
        }
    }

    void SetComHand()
    {
        int rand_com = Random.Range(1, 4); //1�̻� 4�̸��� '����'�� �����ϰ� ��ȯ�Ѵ�.

        switch (rand_com)
        {
            case (int)Hands.Rock:
                com_hand = Hands.Rock;
                break;
            case (int)Hands.Scisscors:
                com_hand = Hands.Scisscors;
                break;
            case (int)Hands.Paper:
                com_hand = Hands.Paper;
                break;
        }
        Debug.Log($"��ǻ�Ͱ� ������ �� ���� �����߽��ϴ�. {com_hand}");
        fight_switch();
    }

    // 3. ������ ��ǻ�� ���� ���� �� - 1
    void fight_if()
    {
        string result = "";
        //���ǹ����� �ϴ� ��
        if (user_hand == com_hand)
        {
            result = "Draw";
        }
        else if (user_hand == Hands.Rock)
        {
            result = (com_hand == Hands.Paper) ? "Lose" : "Win";
        }
        else if (user_hand == Hands.Scisscors)
        {
            result = (com_hand == Hands.Rock) ? "Lose" : "Win";
        }
        else if (user_hand == Hands.Paper)
        {
            result = (com_hand == Hands.Scisscors) ? "Lose" : "Win";
        }

        user_hand = Hands.Rock;
        Debug.Log(result);
    }

    // 3. ������ ��ǻ�� ���� ���� �� - 2
    void fight_switch()
    {
        string result = "";
        switch (user_hand)
        {
            case Hands.Rock:
                if (com_hand == Hands.Rock) result = "Draw";
                else if (com_hand == Hands.Scisscors) result = "Win";
                else if (com_hand == Hands.Paper) result = "Lose";
                break;

            case Hands.Scisscors:
                if (com_hand == Hands.Rock) result = "Lose";
                else if (com_hand == Hands.Scisscors) result = "Draw";
                else if (com_hand == Hands.Paper) result = "Win";
                break;

            case Hands.Paper:
                if (com_hand == Hands.Rock) result = "Win";
                else if (com_hand == Hands.Scisscors) result = "Lose";
                else if (com_hand == Hands.Paper) result = "Draw";
                break;
        }

        user_hand = Hands.Rock;
        Debug.Log(result);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputUserHand();
    }
}
