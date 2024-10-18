using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.Threading;

public class Rocket : MonoBehaviour
{
    public RocketEnergySystem rocketEnergySystem;
    public RocketDashboard rocketDashboard;
    private Rigidbody2D _rb2d;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
        rocketEnergySystem.CheckFuel();
    }

    private void Update()
    {
        rocketDashboard.UpdateUI();
        rocketEnergySystem.FuelFill();
    }

    public void Shoot()
    {
        if (rocketEnergySystem.fuel >= 10f)
        {
            _rb2d.AddForce(Vector2.up * rocketEnergySystem.SPEED, ForceMode2D.Impulse);
            rocketEnergySystem.fuel -= rocketEnergySystem.FUELPERSHOOT;
            rocketEnergySystem.CheckFuel();
        }
    }
}
