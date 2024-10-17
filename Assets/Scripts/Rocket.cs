using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly float SPEED = 5f;

    private RocketDashboard dashboard;
    private RocketEnergySystem energySystem;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private Slider fuelSlider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashboard = new RocketDashboard(currentScoreTxt, highScoreTxt, fuelSlider);
        energySystem = new RocketEnergySystem(100f, 10f, 0.1f);

        dashboard.InitializeHighScore();
        dashboard.InitializeFuelSlider(energySystem.GetFuel());
    }

    void Update()
    {
        dashboard.UpdateScore(transform.position.y);
        dashboard.UpdateHighScore(transform.position.y);
        energySystem.RecoverFuel();
        dashboard.UpdateFuelSlider(energySystem.GetFuel());
    }

    public void Shoot()
    {
        if (energySystem.CanShoot())
        {
            rb.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            energySystem.UseFuel();
            dashboard.UpdateFuelSlider(energySystem.GetFuel());
        }
        else
        {
            Debug.Log("Fuel Not Enough");
        }
    }

    public void OnReButtonClicked()
    {
        SceneManager.LoadScene("RocketLauncher");
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
