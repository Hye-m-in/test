using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloudController : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;
    private Vector3 defaultScale = new Vector3(1.3f, 1.3f, 1.3f);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f) //거리가 0.05f 이하일 때 목적지 변경
        {
            if (desPos == endPos)
                desPos = startPos;
            else desPos = endPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player 자식 오브젝트로 지정
        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.SetParent(transform);
            collision.transform.localScale = defaultScale; //스케일 유지
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //player 자식 오브젝트 해제
        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.SetParent(null);
            collision.transform.localScale = defaultScale;  //스케일 유지
        }      
    }
}