using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    [SerializeField] private Text hiScoreText;

    private int countingClicks;

    void Start()
    {
        int hi = PlayerPrefs.GetInt("HiScore");

        hiScoreText.text = hi.ToString();
    }

    public void OnClickFiveTimes()
    {
        if(countingClicks == 5)
        {
            countingClicks = 0;
            PlayerPrefs.SetInt("HiScore", countingClicks);
            hiScoreText.text = countingClicks.ToString();
        }
        countingClicks++;
    }
}
