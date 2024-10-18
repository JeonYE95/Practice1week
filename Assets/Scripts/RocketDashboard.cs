using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RocketDashboard : MonoBehaviour
{
    public int currentScore;
    public int HighScore;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    public void UpdateUI()
    {
        currentScore = (int)transform.position.y;
        currentScoreTxt.text = $"{currentScore} M";

        if (currentScore > HighScore)
        {
            HighScore = currentScore;
            HighScoreTxt.text = $"{currentScore} M";
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}