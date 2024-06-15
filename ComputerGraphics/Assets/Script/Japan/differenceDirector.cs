using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class differenceDirector : MonoBehaviour
{
    // Ʋ�� �׸� 5���� Ŭ�� ����
    static bool diffCheck01;
    static bool diffCheck02;
    static bool diffCheck03;
    static bool diffCheck04;
    static bool diffCheck05;

    // ���� ���� ������Ʈ
    GameObject correct01;
    GameObject correct02;
    GameObject correct03;
    GameObject correct04;
    GameObject correct05;

    // ���콺 Ŭ�� �̺�Ʈ
    private void OnMouseDown()
    {
        // Ŭ���� �κ��� Ʋ�� �κ��� ���� ��� Ŭ�� ���� ������ true�� ���� + ���� ǥ�� ������Ʈ Ȱ��ȭ
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

        // ���� ���۽� Ʋ�� �׸� 5���� Ŭ�� ���� ������ false�� �ʱ�ȭ
        diffCheck01 = diffCheck02 = diffCheck03 = diffCheck04 = diffCheck05 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ������Ʈ ��Ȱ��ȭ �� Ȱ��ȭ (diffCheck�� true(ã�� ���)��, ���� ǥ�� ������Ʈ Ȱ��ȭ, false(�� ã�� ���)�� ��Ȱ��ȭ)
        correct01.SetActive(diffCheck01);
        correct02.SetActive(diffCheck02);
        correct03.SetActive(diffCheck03);
        correct04.SetActive(diffCheck04);
        correct05.SetActive(diffCheck05);

        // Ʋ�� �κ��� ��� ã���� ���� Ŭ���� -> 0.5�� �ڿ� Ŭ���� ������ �̵�
        if (diffCheck01 == true & diffCheck02 == true & diffCheck03 == true &
            diffCheck04 == true & diffCheck05 == true)
        {
            // ���� Ŭ���� ������ �̵�
            PlayerPrefs.SetInt("Japansuccess", 1);
            SceneManager.LoadScene("JapanClearScene");
        }
    }
}