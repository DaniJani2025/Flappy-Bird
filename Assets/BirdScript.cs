using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float camHalfHeight;
    public float margin = 0.5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flapClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        camHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.gameStarted)
        {
            if (FlapPressed())
                logic.StartGame();
            return;
        }

        if (!birdIsAlive)
            return;

        if (birdIsAlive && FlapPressed())
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            audioSource.PlayOneShot(flapClip);
        }

        if (transform.position.y > camHalfHeight + margin ||
            transform.position.y < -camHalfHeight - margin)
        {
            Die();
            Destroy(gameObject);
        }
    }

    bool FlapPressed()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
            return true;

        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame &&
            !EventSystem.current.IsPointerOverGameObject())
            return true;

        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            return true;

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        if (!birdIsAlive) return;

        birdIsAlive = false;
        logic.gameOver();
    }
}
