using UnityEngine;
using UnityEngine.UI;

public class StartProcess : MonoBehaviour
{
    public GameObject spaceProcess;

    public static GameObject cloneSpaceOne;
    public static GameObject cloneSpaceTwo;

    private void Start()
    {
        WTPoints.score = default(int);
        WTPoints.hiScore = PlayerPrefs.GetInt("HiScore");

        WTPoints.dimension = true;

        WTPoints.pointsSpaceTwo = default(int);
        WTPoints.pointsSpaceOne = default(int);
        

        cloneSpaceTwo = Instantiate(spaceProcess, Vector3.zero, Quaternion.identity);

        WTPoints.space = GameObject.Find("spaceTwo");
        WTPoints.render = WTPoints.space.GetComponent<SpriteRenderer>();
    }

    private void Update() => AlphaChannel.RegulateSprite(WTPoints.render, 0.7f);

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

public static class WTPoints
{
    public static int hiScore;
    public static int score;

    public static int pointsSpaceTwo;
    public static int pointsSpaceOne;

    public static bool dimension;

    public static GameObject space;
    public static SpriteRenderer render;
}