using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public Slider fuelSlider;
    public float fuel = 100f;
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        if (fuel >= 10f)
        {
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
            CheckFuel();
        }
    }

    public void CheckFuel()
    {
        if (fuelSlider != null)
        {
            fuelSlider.value = fuel / 100f;
        }
    }
}