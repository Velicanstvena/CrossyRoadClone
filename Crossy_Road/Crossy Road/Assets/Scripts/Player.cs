using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isJumping;

    [SerializeField] GameObject movementParticle;
    [SerializeField] AudioClip movementSound;
    [SerializeField] AudioClip coinSound;

    Vector3 oldPos;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            float zDiff = 0;

            if (transform.position.z % 1 != 0)
            {
                zDiff = Mathf.Round(transform.position.z) - transform.position.z;
            }

            MovePlayer(new Vector3(1, 0, zDiff));
            FindObjectOfType<GameController>().AddScore();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isJumping)
        {
            MovePlayer(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isJumping)
        {
            MovePlayer(new Vector3(0, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isJumping)
        {
            float zDiff = 0;

            if (transform.position.z % 1 != 0)
            {
                zDiff = Mathf.Round(transform.position.z) - transform.position.z;
            }

            MovePlayer(new Vector3(-1, 0, zDiff));
            FindObjectOfType<GameController>().DecreaseScore();
        }
    }

    private void MovePlayer(Vector3 diff)
    {
        oldPos = transform.position;
        if (FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().mute == false) AudioSource.PlayClipAtPoint(movementSound, transform.position, 0.25f);
        animator.SetTrigger("jump");
        isJumping = true;
        transform.position = (transform.position + diff);
        GameObject particle = Instantiate(movementParticle, transform.position, transform.rotation);
        Destroy(particle, 1);
    }

    public void FinishHop()
    {
        isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }

        if (collision.collider.gameObject.tag == "Obstacle")
        {
            transform.position = oldPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            FindObjectOfType<GameController>().CollectCoin();
            if (FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().mute == false) AudioSource.PlayClipAtPoint(coinSound, transform.position, 0.25f);
            Destroy(other.gameObject);
        }
    }
}
