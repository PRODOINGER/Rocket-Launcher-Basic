using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;

    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱)
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        // 연료가 충분할 때만 동작
        if (fuel >= FUELPERSHOOT)
        {
            // 위 방향으로 힘을 가함
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);

            // 연료 감소
            fuel -= FUELPERSHOOT;

            Debug.Log("남은 연료: " + fuel);
        }
        else
        {
            Debug.Log("발사하기에 연료가 충분하지 않습니다!");
        }
    }
}
