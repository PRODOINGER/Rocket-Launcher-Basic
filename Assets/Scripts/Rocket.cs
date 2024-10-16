using UnityEngine;
// 네임스페이스 추가
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fuel = 100f;
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;
    [SerializeField] private Slider fuelSlider;  // 연료 바를 표시하는 Slider

    private float currentScore = 0f;
    private float HighScore = 0f;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱)
        rb = GetComponent<Rigidbody2D>();

        // 최고 기록 불러오기
        HighScore = PlayerPrefs.GetFloat("High Score", 0);
        HighScoreTxt.text = $"High Score: {HighScore:F1} M";

        // 슬라이더 초기값 설정
        fuelSlider.maxValue = fuel;  // 최대 연료 양
        fuelSlider.value = fuel;  // 현재 연료 양
    }

    void Update()
    {
        // 현재 높이 계산
        currentScore = transform.position.y;
        currentScoreTxt.text = $"Score: {currentScore:F1} M";

        // 최고 기록 갱신
        if (currentScore > HighScore)
        {
            HighScore = currentScore;
            HighScoreTxt.text = $"High Score: {HighScore:F1} M";

            // 최고 기록 저장
            PlayerPrefs.SetFloat("High Score", HighScore);
        }
    }

    public void Shoot()
    {
        // 연료가 충분할 때만 동작
        if (fuel >= FUELPERSHOOT)
        {
            // 위 방향으로 힘을 가함
            rb.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);

            // 연료 감소
            fuel -= FUELPERSHOOT;
            fuelSlider.value = fuel;  // 슬라이더 값 업데이트

            Debug.Log("Fuel: " + fuel);
        }
        else
        {
            Debug.Log("Fuel Not Enough");
        }
    }

    public void OnReButtonClicked()
    {
        // RocketLauncher 씬을 다시 로드
        SceneManager.LoadScene("RocketLauncher");
    }

    private void OnDestroy()
    {
        // PlayerPrefs에 저장된 값을 저장 (게임이 종료되거나 로켓이 파괴될 때)
        PlayerPrefs.Save();
    }
}