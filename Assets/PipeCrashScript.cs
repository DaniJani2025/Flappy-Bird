using UnityEngine;

public class PipeCrashScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip crashClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        AudioSource playerAudio =
            collision.gameObject.GetComponent<AudioSource>();

        if (playerAudio != null)
        {
            playerAudio.PlayOneShot(crashClip);
        }

        LogicScript logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.gameOver();
    }
}
