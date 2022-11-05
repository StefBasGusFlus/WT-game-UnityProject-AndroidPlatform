using System.Collections;
using UnityEngine;

public class SpawnBarrier : MonoBehaviour
{
    public GameObject[] barriersTopOrLeft;
    public GameObject[] barriersDownOrRight;

    public GameObject[] portals;

    private Bounds boundsGameField;

    private float x;
    private float y;

    private const float SHIFT = 0.52f;
    private float shiftY;
    private float shiftX;

    private void Start()
    {
        boundsGameField = gameObject.GetComponent<BoxCollider2D>().bounds;

        if (gameObject.tag == "SpaceTwo")
        {
            x = boundsGameField.max.x;
            y = boundsGameField.center.y;
            shiftY = SHIFT;
            shiftX = 0;

        }
        else if (gameObject.tag == "SpaceOne")
        {
            x = boundsGameField.center.x;
            y = boundsGameField.max.y;
            shiftY = 0;
            shiftX = SHIFT;
        }

        Repeat();
    }

    private void Repeat() => StartCoroutine(SpawnGenerator());

    IEnumerator SpawnGenerator()
    {
        yield return new WaitForSeconds(1);
        GameObject clone = Instantiate(barriersTopOrLeft[Random.Range(0, barriersTopOrLeft.Length)],
            new Vector3(x - shiftX, y + shiftY, 0),
            Quaternion.identity);
        clone.transform.SetParent(this.transform);

        yield return new WaitForSeconds(2);
        clone = Instantiate(barriersDownOrRight[Random.Range(0, barriersDownOrRight.Length)], 
            new Vector3(x + shiftX, y - shiftY, 0), 
            Quaternion.identity);
        clone.transform.SetParent(this.transform);

        yield return new WaitForSeconds(2.5f);
        clone = Instantiate(portals[Random.Range(0, portals.Length)], 
            new Vector3(x, y, 0),
            Quaternion.identity);
        clone.transform.SetParent(this.transform);

        Repeat();
    }
}
