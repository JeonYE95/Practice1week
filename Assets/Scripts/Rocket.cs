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

        if (rocketEnergySystem.fuel < 100f)
        {
            rocketEnergySystem.fuel += 0.1f * Time.deltaTime;
            rocketEnergySystem.CheckFuel();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}
