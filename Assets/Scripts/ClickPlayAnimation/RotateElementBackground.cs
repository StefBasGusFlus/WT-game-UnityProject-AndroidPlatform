using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElementBackground : MonoBehaviour
{
    void Update() => transform.Rotate(new Vector3(0, 0, 40 * Time.deltaTime));
}
