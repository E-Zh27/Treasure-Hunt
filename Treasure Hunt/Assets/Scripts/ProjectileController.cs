using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
