using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    // �÷��̾� ���� ������Ʈ �ݶ��̴� (�����Ӻ��� �� 4�� ����)
    public GameObject collider01;
    public GameObject collider02;
    public GameObject collider03;
    public GameObject collider04;

    void Start()
    {

    }

    // ���� Ƣ�ܳ��� ���� Ư���� ���� ���� �ø��� ���� �ʿ�
    // �ö󰡴� �ȿ� ���� �ݶ��̴��� �ٸ��� �����ؾ���
    // �ִϸ��̼� �̺�Ʈ �Լ� ����

    // ù ��° �ݶ��̴� Ȱ��ȭ -> ���ú� ù ��° ���
    public void EnableCollider01()
    {
        collider01.SetActive(true);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }

    // �� ��° �ݶ��̴� Ȱ��ȭ -> ���ú� �� ��° ���
    public void EnableCollider02()
    {
        collider01.SetActive(false);
        collider02.SetActive(true);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }

    // �� ��° �ݶ��̴� Ȱ��ȭ -> ���ú� �� ��° ���
    public void EnableCollider03()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(true);
        collider04.SetActive(false);
    }

    // �� ��° �ݶ��̴� Ȱ��ȭ -> ���ú� �� ��° ���
    public void EnableCollider04()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(true);
    }

    // ��� �ݶ��̴� ���� -> ���ú� ��� �Ϸ� (���� ����)
    public void DisableCollider()
    {
        collider01.SetActive(false);
        collider02.SetActive(false);
        collider03.SetActive(false);
        collider04.SetActive(false);
    }
}

