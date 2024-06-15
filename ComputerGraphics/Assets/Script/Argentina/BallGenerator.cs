using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;   // 생성할 공 프리팹
    public Transform spawnPoint;    // 공이 생성될 기본 위치
    public float minX = -10f;        // X축 최소값
    public float maxX = -5f;         // X축 최대값

    // Start is called before the first frame update
    void Start()
    {
        // 처음 한 번 공 생성
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 공 발사 함수 (프리팹)
    public void LaunchBall()
    {
        // 공은 X축을 기준으로 -10에서 -5 사이에서 랜덤 생성 된다.
        // X축 랜덤 위치 계산
        float randomX = Random.Range(minX, maxX);

        // 랜덤 X 위치에서 공 프리팹 생성
        Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }
}
