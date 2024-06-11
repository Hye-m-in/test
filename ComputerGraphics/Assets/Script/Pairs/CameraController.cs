using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float initialCameraHeight;  //처음 카메라의 높이
    float maxCameraHeight = 24.0f; //카메라 최대 높이

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("ch");
    }

    // Update is called once per frame
    void Update()
    {
        float playerHeight = player.transform.position.y;  //현재 플레이어의 높이

        Vector3 newCameraPosition = transform.position;  //카메라의 새로운 위치 계산

        if(playerHeight > initialCameraHeight)  //플레이어가 카메라의 처음 높이보다 높아졌을 때만 카메라 이동
        {
            newCameraPosition.y = playerHeight;
        }

        newCameraPosition.y = Mathf.Max(newCameraPosition.y, initialCameraHeight);  //카메라가 시작 높이보다 내려가지 않도록 설정
        newCameraPosition.y = Mathf.Min(newCameraPosition.y, maxCameraHeight); //카메라가 최대 높이를 넘지 않도록 설정

        transform.position = newCameraPosition;
    }
}
