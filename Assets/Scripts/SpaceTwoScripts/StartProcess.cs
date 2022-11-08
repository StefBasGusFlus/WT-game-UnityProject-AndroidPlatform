using UnityEngine;
using UnityEngine.UI;

public class StartProcess : MonoBehaviour
{
    [SerializeField] private GameObject spaceProcess;

    public static GameObject cloneSpaceOne;
    public static GameObject cloneSpaceTwo;

    private void Start()
    {
        DataPoints.score = default(int);
        DataPoints.hiScore = PlayerPrefs.GetInt("HiScore");

        DataPoints.dimension = true;

        DataPoints.pointsSpaceTwo = default(int);
        DataPoints.pointsSpaceOne = default(int);
        

        cloneSpaceTwo = Instantiate(spaceProcess, Vector3.zero, Quaternion.identity);

        DataPoints.space = GameObject.Find("spaceTwo");
        DataPoints.render = DataPoints.space.GetComponent<SpriteRenderer>();
    }

    private void Update() => AlphaChannel.RegulateSprite(DataPoints.render, 0.7f);

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
    public static int hiScore;
    public static int score;

    public static int pointsSpaceTwo;
    public static int pointsSpaceOne;

    public static bool dimension;

    public static GameObject space;
    public static SpriteRenderer render;
}