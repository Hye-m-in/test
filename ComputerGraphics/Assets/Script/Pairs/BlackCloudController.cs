using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloudController : MonoBehaviour
{
    public float disappearDelay = 1.0f; // 구름이 사라지기 전 딜레이 (초)
    public float fadeDuration = 1.0f; // 구름이 사라지는 데 걸리는 시간 (초)
    private bool playerOnCloud = false; // 플레이어가 구름에 있는지 여부
    private float fadeTimer = 0.0f; // 페이드 타이머
    private Material cloudMaterial; // 구름의 재질

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
            // 플레이어가 구름에 있을 때 타이머를 증가시킵니다.
            fadeTimer += Time.deltaTime;

            // 딜레이 후 페이드 타이머가 시작됩니다.
            if (fadeTimer > disappearDelay)
            {
                // 페이드 효과를 계산합니다.
                float fadeAmount = (fadeTimer - disappearDelay) / fadeDuration;

                // 구름의 투명도를 감소시킵니다.
                Color color = cloudMaterial.color;
                color.a = Mathf.Lerp(1.0f, 0.0f, fadeAmount);
                cloudMaterial.color = color;

                // 구름이 완전히 사라졌으면 오브젝트를 비활성화합니다.
                if (color.a <= 0.0f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 구름에 닿으면 playerOnCloud를 true로 설정합니다.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCloud = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 플레이어가 구름에서 떨어지면 playerOnCloud를 false로 설정합니다.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCloud = false;
            fadeTimer = 0.0f; // 타이머를 초기화합니다.
        }
    }
}
