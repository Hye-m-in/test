using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGenerator : MonoBehaviour
{
    private float gameTime = 20.0f;   // ���� �ð� 20��
    float sec = 0.0f;                 // ���� ���۽� �� ��ȯ�� ���ÿ� Ÿ�̸� ���� ���� �� ī��Ʈ ����

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // UI���� ��ũ��Ʈ
        GameObject director = GameObject.Find("timerDirector");

        // �ð� ���
        sec += Time.deltaTime;

        // ���� �� ��ȯ���ڸ��� �ð� ī�����ϴ� ���� �����ϱ� ���� 1�� �� ī���� ����
        if (sec >= 1)
        {
            // ���� �ð� ����
            if (gameTime < 0)
            {
                // �ð� ���� Ʋ�� �κ��� ��� ã�� �������Ƿ� ���� ���� -> 0.5�� �� ���� ���� �� �̵�
                SceneManager.LoadScene("JapanOverScene");
            }
            // ���� �ð� �� ����
            else
            {
                // 1�ʰ� ���� ������ Ÿ�̸Ӹ� 1�� ���� ��Ų��.
                gameTime -= Time.deltaTime;
                director.GetComponent<timerDirector>().DecreaseTime(1 / (20 / Time.deltaTime));
            }
        }
    }
}