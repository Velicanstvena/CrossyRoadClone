using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] GameObject killParticle;
    [SerializeField] AudioClip deathSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            Kill(collision.gameObject.transform);
        }
    }

    public void Kill(Transform playerPos)
    {
        GameObject particle = Instantiate(killParticle, playerPos.position, Quaternion.Euler(90, 0, 0));
        if (FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().mute == false) AudioSource.PlayClipAtPoint(deathSound, playerPos.position, 0.75f);
        Destroy(particle, 1);
        Destroy(playerPos.gameObject);
        StartCoroutine(FindObjectOfType<GameController>().DisplayResults());
    }
}
