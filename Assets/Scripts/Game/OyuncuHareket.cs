using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    Animator animator;

    Vector2 velocity;
    
    [SerializeField]
    float hiz=default;

    [SerializeField]
    float hizlanma=default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti = default;


    public int ziplamaSayisi = default;

    Joystick joystick;

    JoystickTouch joystickTouch;

    bool zipliyor;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickTouch = FindObjectOfType<JoystickTouch>();

    }

    // Update is called once per frame
    void Update()
    {
    #if UNITY_EDITOR
            KlavyedenKontrol();
    #else
                    JoystickKontrol();
    #endif

    }
    void KlavyedenKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        
        if (hareketInput > 0)
        {
            scale.x = 0.3f;
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else if (hareketInput < 0)
        {
            scale.x = -0.3f;
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
        }
        transform.localScale = scale;
        transform.Translate(velocity*Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {

            ZiplamayiBaslat();
        }
        if (Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }

    }

    void JoystickKontrol()
    {

        float hareketInput=joystick.Horizontal;
        Vector2 scale = transform.localScale;

        if (hareketInput > 0)
        {
            scale.x = 0.3f;
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else if (hareketInput < 0)
        {
            scale.x = -0.3f;
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);


        if (joystickTouch.tusaBasildi==true && zipliyor==false)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }
        if (joystickTouch.tusaBasildi==false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi < ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            myRigidBody2D.AddForce(new Vector2(0,ziplamaGucu),ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
        
    }
    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    public void ZiplamaSifirlama()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }


    public void OyunBitti()
    {
        Destroy(gameObject);
    }



}
