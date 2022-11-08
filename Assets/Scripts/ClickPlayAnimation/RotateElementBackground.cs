using UnityEngine;

public class RotateElementBackground : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed;

    void Update() => transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime));
}
