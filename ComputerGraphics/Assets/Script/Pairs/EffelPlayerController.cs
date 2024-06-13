using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 550.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    Vector3 defaultScale = new Vector3(1.3f, 1.3f, 1.3f);


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        transform.localScale = defaultScale;
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //움직이는 방향에 따라 이미지 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key * 1.3f, 1.3f, 1.3f);
        }

        //플레이어 속도에 맞춰 애니메이션 속도 변경
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("ParisStartScene");
        }
    }

    //꼭대기 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("Parissuccess", 1);
        SceneManager.LoadScene("ParisClearScene");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 구름과 충돌했을 때 크기 유지
        if (collision.gameObject.CompareTag("Blackcloud"))
        {
            transform.localScale = defaultScale;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 구름을 벗어났을 때도 크기 유지
        if (collision.gameObject.CompareTag("Blackcloud"))
        {
            transform.localScale = defaultScale;
        }
    }

}