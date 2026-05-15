using UnityEngine;

public class NPCMove : MonoBehaviour
{
    [Header("Bounds")]
    public float minY = -6.5f;
    public float maxY = 5.5f;

    [Header("Movement")]
    public float speed = 3f;

    bool goingUp = true;

    void Update()
    {
        float dir = goingUp ? 1f : -1f;

        // Move
        transform.position += new Vector3(0, dir * speed * Time.deltaTime, 0);

        // Clamp + flip direction (prevents jitter/overshoot)
        if (goingUp && transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            goingUp = false;
        }
        else if (!goingUp && transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            goingUp = true;
        }
    }
}
