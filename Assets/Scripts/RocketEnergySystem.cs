using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    public Slider fuelSlider;
    public float fuel = 100f;
    public readonly float SPEED = 5f;
    public readonly float FUELPERSHOOT = 10f;

    public void CheckFuel()
    {
        if (fuelSlider != null)
        {
            fuelSlider.value = fuel / 100f;
        }
    }

    public void FuelFill()
    {
        if (fuel < 100f)
        {
            fuel += 0.1f;
            CheckFuel();
        }

    }
}