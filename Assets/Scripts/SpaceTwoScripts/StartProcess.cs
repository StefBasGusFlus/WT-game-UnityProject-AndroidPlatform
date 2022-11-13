using UnityEngine;
using UnityEngine.UI;

public class StartProcess : MonoBehaviour
{
    [SerializeField] private GameObject spaceProcess;

    public static GameObject CloneSpaceOne;
    public static GameObject CloneSpaceTwo;

    private void Start()
    {
        DataPoints.Score = default(int);
        DataPoints.HiScore = PlayerPrefs.GetInt("HiScore");

        DataPoints.Dimension = true;

        DataPoints.PointsSpaceTwo = default(int);
        DataPoints.PointsSpaceOne = default(int);
        

        CloneSpaceTwo = Instantiate(spaceProcess, Vector3.zero, Quaternion.identity);

        DataPoints.Space = GameObject.Find("spaceTwo");
        DataPoints.Render = DataPoints.Space.GetComponent<SpriteRenderer>();
    }

    private void Update() => AlphaChannel.RegulateSprite(DataPoints.Render, 0.7f);

}

public class AlphaChannel
{
    public static void RegulateSprite(SpriteRenderer render, float speed) 
    {
        var color = render.color;

        color.a += speed * Time.deltaTime;
        color.a = Mathf.Clamp(color.a, 0, 1);

        render.color = color;
    }

    public static void RegulateText(Text render, float speed)
    {
        var color = render.color;

        color.a += speed * Time.deltaTime;
        color.a = Mathf.Clamp(color.a, 0, 1);

        render.color = color;
    }
}

public static class DataPoints
{
    public static int HiScore;
    public static int Score;

    public static int PointsSpaceTwo;
    public static int PointsSpaceOne;

    public static bool Dimension;

    public static GameObject Space;
    public static SpriteRenderer Render;
}