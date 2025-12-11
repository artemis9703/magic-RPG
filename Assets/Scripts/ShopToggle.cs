using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    public Rigidbody2D rb;
    public  Animator interactAnim;
    private bool shopOpen = false;
    public CanvasGroup shop;
    private bool isHere = false;

    private void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && shopOpen == false && isHere == true)
        {
            shop.alpha = 1;
            shop.interactable = true;
            shop.blocksRaycasts = true;
            shopOpen = true;
        }
        else if (Input.GetButtonDown("Interact") && shopOpen == true && isHere == true)
        {
            shop.alpha = 0;
            shop.interactable = false;
            shop.blocksRaycasts = false;
            shopOpen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            interactAnim.Play("Open");
            isHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactAnim.Play("Close");
            rb.bodyType = RigidbodyType2D.Dynamic;
            isHere = false;
        }
    }
}