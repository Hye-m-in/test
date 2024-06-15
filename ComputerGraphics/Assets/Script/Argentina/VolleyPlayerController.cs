using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolleyPlayerController : MonoBehaviour
{
    public float speed = 8.0f; // 플레이어 이동 속도
    private Animator animator; // 애니메이터

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        float move = 0;
        int key = 0;        // 좌우방향키 구분 변수 (1; 오른쪽, -1: 왼쪽)

        // 스페이스 키를 누르면 리시브 모션
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("ReceiveTrigger");
        }

        // 오른쪽 방향 키를 누르면 오른쪽으로 반전 후 캐릭터 걷는 모션
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = -1;
            move = 1;
        }

        // 왼쪽 방향 키를 누르면 왼쪽으로 반전 후 캐릭터 걷는 모션
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = 1;
            move = -1;
        }

        // 플레이어 이동
        transform.position += new Vector3(move, 0, 0) * this.speed * Time.deltaTime;

        // 걷는지 판단 후 Walk혹은 Wait 애니메이션을 결정하는 bool WalkCheck 결정 (true; 걷기, false; 정지)
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
            animator.SetBool("WalkCheck", true);
        }
        else
        {
            animator.SetBool("WalkCheck", false);
        }

        // 애니메이션 속도 조절
        animator.SetFloat("Speed", Mathf.Abs(move * this.speed));
    }
}
