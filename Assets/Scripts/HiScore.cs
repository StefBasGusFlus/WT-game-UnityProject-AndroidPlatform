using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public Text hiScoreText;

    private int total;

    void Start()
    {
        int hi = PlayerPrefs.GetInt("HiScore");

        hiScoreText.text = hi.ToString();
    }

    public void OnClickFiveTimes()
    {
        if(total == 5)
        {
            total = 0;
            PlayerPrefs.SetInt("HiScore", total);
            hiScoreText.text = total.ToString();
        }
        total++;
    }
}
