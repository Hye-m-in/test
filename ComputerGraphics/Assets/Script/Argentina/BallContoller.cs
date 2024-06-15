using UnityEngine;

public class BallContoller : MonoBehaviour
{
    public float launchSpeed = 10.0f; // ���� �ʱ� �ӵ�
    public float launchAngle = 45.0f; // ���� �߻� ���� (�� ������)

    private Rigidbody2D rb;

    // ���� �浹�� ��ü�� �÷��̾�����, ���̳� �ٴ����� ���� �� ���ú� ���� ���� �Ǵ� �Լ�
    private void OnCollisionEnter2D(Collision2D other)
    {
        // �浹�� ��ü�� �̸��� ���ڿ��� ��
        // �÷��̾ ���� �޾��� ���
        if (other.gameObject.name == "receiveCollider01" || other.gameObject.name == "receiveCollider02" ||
            other.gameObject.name == "receiveCollider03" || other.gameObject.name == "receiveCollider04")
        {
            // ���ú� ���� ó��
            receiveSucess();
        }
        // ���� �ε����� �� �Ǵ� �ٴ��� ���
        else if (other.gameObject.name == "Wall" ||  other.gameObject.name == "Floor")
        {
            // ���ú� ���� ó��
            receiveFail();
        }
    }

    // ���ú� ���� �Լ�
    public void receiveSucess()
    {
        // Rigidbody ��Ȱ��ȭ
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        // ���� ������Ʈ ����
        Destroy(gameObject);

        // ArgDirector ��ũ��Ʈ���� ���ú� ���� �Լ��� Sucess() ȣ��
        GameObject director = GameObject.Find("ArgDirector");
        director.GetComponent<ArgDirector>().Sucess();
    }

    // ���ú� ���� �Լ�
    public void receiveFail()
    {
        // Rigidbody ��Ȱ��ȭ
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        // ���� ������Ʈ ����
        Destroy(gameObject);

        // ArgDirector ��ũ��Ʈ���� ���ú� ���� �Լ��� Fail() ȣ��
        GameObject director = GameObject.Find("ArgDirector");
        director.GetComponent<ArgDirector>().Fail();
    }

    void Start()
    {
        // ���� Rigidbody2D ������Ʈ ��������
        this.rb = GetComponent<Rigidbody2D>();

        // ���� ���������� ������ ���� ����
        // �߻� ������ radian���� ��ȯ
        float angleInRadians = launchAngle * Mathf.Deg2Rad;

        // �ʱ� �ӵ��� x, y �������� ������ ����
        float initialVelocityX = launchSpeed * Mathf.Cos(angleInRadians);
        float initialVelocityY = launchSpeed * Mathf.Sin(angleInRadians);

        // �ʱ� �ӵ��� Rigidbody2D�� ����
        this.rb.velocity = new Vector2(initialVelocityX, initialVelocityY);
    }

    void Update()
    {

    }
}
