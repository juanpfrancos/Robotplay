using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float danger;

    void Update()
    {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);   
    }

}
