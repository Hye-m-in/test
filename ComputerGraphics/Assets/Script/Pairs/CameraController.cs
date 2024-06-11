using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float initialCameraHeight;  //ó�� ī�޶��� ����
    float maxCameraHeight = 24.0f; //ī�޶� �ִ� ����

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("ch");
    }

    // Update is called once per frame
    void Update()
    {
        float playerHeight = player.transform.position.y;  //���� �÷��̾��� ����

        Vector3 newCameraPosition = transform.position;  //ī�޶��� ���ο� ��ġ ���

        if(playerHeight > initialCameraHeight)  //�÷��̾ ī�޶��� ó�� ���̺��� �������� ���� ī�޶� �̵�
        {
            newCameraPosition.y = playerHeight;
        }

        newCameraPosition.y = Mathf.Max(newCameraPosition.y, initialCameraHeight);  //ī�޶� ���� ���̺��� �������� �ʵ��� ����
        newCameraPosition.y = Mathf.Min(newCameraPosition.y, maxCameraHeight); //ī�޶� �ִ� ���̸� ���� �ʵ��� ����

        transform.position = newCameraPosition;
    }
}
