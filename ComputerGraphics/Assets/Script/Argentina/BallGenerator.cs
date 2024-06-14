using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;   // ������ �� ������
    public Transform spawnPoint;    // ���� ������ �⺻ ��ġ
    public float minX = -10f;        // X�� �ּҰ�
    public float maxX = -5f;         // X�� �ִ밪

    // Start is called before the first frame update
    void Start()
    {
        // ó�� �� �� �� ����
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �� �߻� �Լ� (������)
    public void LaunchBall()
    {
        // ���� X���� �������� -10���� -5 ���̿��� ���� ���� �ȴ�.
        // X�� ���� ��ġ ���
        float randomX = Random.Range(minX, maxX);

        // ���� X ��ġ���� �� ������ ����
        Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }
}
