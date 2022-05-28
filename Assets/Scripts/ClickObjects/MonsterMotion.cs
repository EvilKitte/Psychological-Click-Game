using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterMotion : MonoBehaviour
{
    [SerializeField] private float speed = 100.0f;

    private Vector3 motionDirection = new Vector3(0, 0, 0);
    private Vector3 velicity = new Vector3(0, 0, 0);

    private AudioSource collisionAudioSource;

    void Start()
    {
        collisionAudioSource = GetComponent<AudioSource>();

        motionDirection = new Vector3(Random.Range(-20, 20), Random.Range(1, 20), Random.Range(-20, 20));
        motionDirection = speed * motionDirection.normalized;
        GetComponent<Rigidbody>().AddForce(motionDirection);        
    }

    void Update()
    {
        if ((transform.position.x > 25) || (transform.position.x < -25) || (transform.position.y > 35)
            || (transform.position.z > 25) || (transform.position.z < -25))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity += new Vector3(5f, 5f, 5f);
        velicity = GetComponent<Rigidbody>().velocity;

        collisionAudioSource.Play();
    }
}
