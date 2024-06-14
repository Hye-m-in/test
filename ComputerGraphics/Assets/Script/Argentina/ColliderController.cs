using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    // 플레이어 하위 오브젝트 콜라이더 (프레임별로 총 4개 존재)
    public GameObject collider01;
    public GameObject collider02;
    public GameObject collider03;
    public GameObject collider04;

    void Start()
    {

    }

    // 공을 튀겨내는 동작 특성상 팔을 위로 올리는 동작 필요
    // 올라가는 팔에 따라 콜라이더를 다르게 설정해야함
    // 애니메이션 이벤트 함수 생성

    // 첫 번째 콜라이더 활성화 -> 리시브 첫 번째 모션
    public void EnableCollider01()
    {
        collider01.SetActive(true);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }

    // 두 번째 콜라이더 활성화 -> 리시브 두 번째 모션
    public void EnableCollider02()
    {
        collider01.SetActive(false);
        collider02.SetActive(true);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }

    // 세 번째 콜라이더 활성화 -> 리시브 세 번째 모션
    public void EnableCollider03()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(true);
        collider04.SetActive(false);
    }

    // 네 번째 콜라이더 활성화 -> 리시브 네 번째 모션
    public void EnableCollider04()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(true);
    }

    // 모든 콜라이더 종료 -> 리시브 모션 완료 (정지 상태)
    public void DisableCollider()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }
}

