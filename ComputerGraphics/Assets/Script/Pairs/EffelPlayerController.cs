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
        //����
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //�����̴� ���⿡ ���� �̹��� ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key * 1.3f, 1.3f, 1.3f);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ� ����
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

    //����� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("Parissuccess", 1);
        SceneManager.LoadScene("ParisClearScene");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ������ �浹���� �� ũ�� ����
        if (collision.gameObject.CompareTag("Blackcloud"))
        {
            transform.localScale = defaultScale;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ������ ����� ���� ũ�� ����
        if (collision.gameObject.CompareTag("Blackcloud"))
        {
            transform.localScale = defaultScale;
        }
    }

}