using UnityEngine;

public class RocketEnergySystem
{
    private float fuel;
    private readonly float maxFuel;
    private readonly float fuelPerShoot;
    private readonly float fuelRecoveryRate;

    public RocketEnergySystem(float maxFuel, float fuelPerShoot, float fuelRecoveryRate)
    {
        this.maxFuel = maxFuel;
        this.fuel = maxFuel;
        this.fuelPerShoot = fuelPerShoot;
        this.fuelRecoveryRate = fuelRecoveryRate;
    }

    public void RecoverFuel()
    {
        fuel = Mathf.Min(fuel + fuelRecoveryRate, maxFuel);
    }

    public bool CanShoot()
    {
        return fuel >= fuelPerShoot;
    }

    public void UseFuel()
    {
        if (fuel >= fuelPerShoot)
        {
            fuel -= fuelPerShoot;
        }
    }

    public float GetFuel()
    {
        return fuel;
    }
}
