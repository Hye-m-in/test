using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolleyPlayerController : MonoBehaviour
{
    public float speed = 8.0f; // �÷��̾� �̵� �ӵ�
    private Animator animator; // �ִϸ�����

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        float move = 0;
        int key = 0;        // �¿����Ű ���� ���� (1; ������, -1: ����)

        // �����̽� Ű�� ������ ���ú� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("ReceiveTrigger");
        }

        // ������ ���� Ű�� ������ ���������� ���� �� ĳ���� �ȴ� ���
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = -1;
            move = 1;
        }

        // ���� ���� Ű�� ������ �������� ���� �� ĳ���� �ȴ� ���
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = 1;
            move = -1;
        }

        // �÷��̾� �̵�
        transform.position += new Vector3(move, 0, 0) * this.speed * Time.deltaTime;

        // �ȴ��� �Ǵ� �� WalkȤ�� Wait �ִϸ��̼��� �����ϴ� bool WalkCheck ���� (true; �ȱ�, false; ����)
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
            animator.SetBool("WalkCheck", true);
        }
        else
        {
            animator.SetBool("WalkCheck", false);
        }

        // �ִϸ��̼� �ӵ� ����
        animator.SetFloat("Speed", Mathf.Abs(move * this.speed));
    }
}
