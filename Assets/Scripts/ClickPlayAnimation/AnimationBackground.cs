using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    public GameObject elementBackground;

    private Bounds background;

    private void Start()
    {
        background = gameObject.GetComponent<BoxCollider2D>().bounds;

        Repeat();
    }

    private void Repeat() => StartCoroutine(SpawnElementsBackground());

    IEnumerator SpawnElementsBackground()
    {
        yield return new WaitForSeconds(0.5f);
        var clone = Instantiate(elementBackground, 
                    new Vector3(background.max.x, Random.Range(background.min.y, background.max.y)), 
                    Quaternion.identity);
        float scale = Random.Range(0.4f, 1);
        clone.transform.localScale = new Vector3(scale, scale);

        Repeat();
    }
}
