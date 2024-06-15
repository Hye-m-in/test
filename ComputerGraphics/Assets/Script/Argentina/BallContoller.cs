using UnityEngine;

public class BallContoller : MonoBehaviour
{
    public float launchSpeed = 10.0f; // 공의 초기 속도
    public float launchAngle = 45.0f; // 공의 발사 각도 (몇 도인지)

    private Rigidbody2D rb;

    // 공과 충돌한 물체가 플레이어인지, 벽이나 바닥인지 구분 후 리시브 성공 여부 판단 함수
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 충돌한 객체의 이름을 문자열로 비교
        // 플레이어가 공을 받았을 경우
        if (other.gameObject.name == "receiveCollider01" || other.gameObject.name == "receiveCollider02" ||
            other.gameObject.name == "receiveCollider03" || other.gameObject.name == "receiveCollider04")
        {
            // 리시브 성공 처리
            receiveSucess();
        }
        // 공과 부딪힌게 벽 또는 바닥일 경우
        else if (other.gameObject.name == "Wall" ||  other.gameObject.name == "Floor")
        {
            // 리시브 실패 처리
            receiveFail();
        }
    }

    // 리시브 성공 함수
    public void receiveSucess()
    {
        // Rigidbody 비활성화
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        // 게임 오브젝트 삭제
        Destroy(gameObject);

        // ArgDirector 스크립트에서 리시브 성공 함수인 Sucess() 호출
        GameObject director = GameObject.Find("ArgDirector");
        director.GetComponent<ArgDirector>().Sucess();
    }

    // 리시브 실패 함수
    public void receiveFail()
    {
        // Rigidbody 비활성화
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        // 게임 오브젝트 삭제
        Destroy(gameObject);

        // ArgDirector 스크립트에서 리시브 실패 함수인 Fail() 호출
        GameObject director = GameObject.Find("ArgDirector");
        director.GetComponent<ArgDirector>().Fail();
    }

    void Start()
    {
        // 공의 Rigidbody2D 컴포넌트 가져오기
        this.rb = GetComponent<Rigidbody2D>();

        // 공을 포물선으로 던지기 위한 과정
        // 발사 각도를 radian으로 변환
        float angleInRadians = launchAngle * Mathf.Deg2Rad;

        // 초기 속도를 x, y 방향으로 나누어 설정
        float initialVelocityX = launchSpeed * Mathf.Cos(angleInRadians);
        float initialVelocityY = launchSpeed * Mathf.Sin(angleInRadians);

        // 초기 속도를 Rigidbody2D에 적용
        this.rb.velocity = new Vector2(initialVelocityX, initialVelocityY);
    }

    void Update()
    {

    }
}
