using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloudController : MonoBehaviour
{
    public float disappearDelay = 1.0f; // ������ ������� �� ������ (��)
    public float fadeDuration = 1.0f; // ������ ������� �� �ɸ��� �ð� (��)
    private bool playerOnCloud = false; // �÷��̾ ������ �ִ��� ����
    private float fadeTimer = 0.0f; // ���̵� Ÿ�̸�
    private Material cloudMaterial; // ������ ����

    // Start is called before the first frame update
    void Start()
    {
       cloudMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnCloud)
        {
            // �÷��̾ ������ ���� �� Ÿ�̸Ӹ� ������ŵ�ϴ�.
            fadeTimer += Time.deltaTime;

            // ������ �� ���̵� Ÿ�̸Ӱ� ���۵˴ϴ�.
            if (fadeTimer > disappearDelay)
            {
                // ���̵� ȿ���� ����մϴ�.
                float fadeAmount = (fadeTimer - disappearDelay) / fadeDuration;

                // ������ ������ ���ҽ�ŵ�ϴ�.
                Color color = cloudMaterial.color;
                color.a = Mathf.Lerp(1.0f, 0.0f, fadeAmount);
                cloudMaterial.color = color;

                // ������ ������ ��������� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
                if (color.a <= 0.0f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ������ ������ playerOnCloud�� true�� �����մϴ�.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCloud = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // �÷��̾ �������� �������� playerOnCloud�� false�� �����մϴ�.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCloud = false;
            fadeTimer = 0.0f; // Ÿ�̸Ӹ� �ʱ�ȭ�մϴ�.
        }
    }
}
