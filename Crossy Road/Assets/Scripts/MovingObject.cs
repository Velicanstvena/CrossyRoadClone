using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject smokeParticle;
    [SerializeField] Transform smokePos;
    [SerializeField] AudioClip[] carSounds;
    public bool isLog;
    private int minSpawnTime;
    private int maxSpawnTime;

    void Start()
    {
        //minSpawnTime = 2;
        //maxSpawnTime = 10;
        if (!isLog) Instantiate(smokeParticle, smokePos.position, transform.rotation, smokePos);
        //StartCoroutine(SpawnSmokeParticle());
        if (FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().mute == false) StartCoroutine(PlayCarSounds());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator SpawnSmokeParticle()
    {
        if (!isLog)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
                GameObject particle = Instantiate(smokeParticle, gameObject.transform.GetChild(0).transform.position, transform.rotation);
                Destroy(particle, 1);
            }
        }
    }

    private IEnumerator PlayCarSounds()
    {
        if (!isLog)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(5, 30));
                AudioSource.PlayClipAtPoint(carSounds[Random.Range(0,2)], transform.position, 0.75f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            GetComponent<KillPlayer>().Kill(other.gameObject.transform);
        }
    }
}
