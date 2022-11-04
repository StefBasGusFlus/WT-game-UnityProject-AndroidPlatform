using System.Collections;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    public GameObject elementBackground;

    private Bounds areaSpawn;

    private void Start()
    {
        areaSpawn = gameObject.GetComponent<BoxCollider2D>().bounds;

        Repeat();
    }

    private void Repeat() => StartCoroutine(SpawnElementsBackground());

    IEnumerator SpawnElementsBackground()
    {
        yield return new WaitForSeconds(0.5f);
        var clone = Instantiate(elementBackground, 
                    new Vector3(areaSpawn.max.x, Random.Range(areaSpawn.min.y, areaSpawn.max.y)), 
                    Quaternion.identity);

        float scale = Random.Range(0.4f, 1);
        clone.transform.localScale = new Vector3(scale, scale);

        Repeat();
    }
}
