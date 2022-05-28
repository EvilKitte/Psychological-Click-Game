using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
    public float lifeTime = 5.0f;

    void Awake()
    {
        Invoke("Destroy", lifeTime);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
