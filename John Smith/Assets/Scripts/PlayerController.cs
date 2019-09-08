using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rBSlot;
    public float speedMultiplier;

    public Animator animSlot; //0.0.13N1
    public string destination; //0.0.17N1

    public static PlayerController PCInstance; //0.0.16N1

    public Vector3 bottomLeftCoordLimit; //0.0.26N1
    public Vector3 topRightCoordLimit; //0.0.26N1end

    public bool canMove = true; //0.0.35N1

    private void Awake() //0.0.30N5
    {
        if (PCInstance == null) //0.0.16N2
        {
            PCInstance = this;
            DontDestroyOnLoad(gameObject); //0.0.15N5
        }
        else
            Destroy(gameObject); //0.0.16N2end
    } //0.0.30N5end

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) //0.0.35N2
        {
            rBSlot.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speedMultiplier; //0.0.10N1
            animSlot.SetFloat("moveX", rBSlot.velocity.x); //0.0.13N2
            animSlot.SetFloat("moveY", rBSlot.velocity.y); //0.0.13N2end
        }
        else
            rBSlot.velocity = Vector2.zero; //0.0.35N2end

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) //0.0.13N3
        {
            if(canMove) //0.0.35N3
            {
                animSlot.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                animSlot.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftCoordLimit.x, topRightCoordLimit.x), Mathf.Clamp(transform.position.y, bottomLeftCoordLimit.y, topRightCoordLimit.y), transform.position.z); //0.0.26N4
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight) //0.0.26N2
    {
        bottomLeftCoordLimit = bottomLeft + new Vector3(.5f, .6f, 0f); //0.0.26N5
        topRightCoordLimit = topRight + new Vector3(-.5f, -.6f, 0f); //0.0.26N5end
    } //0.0.26N2end
}
 
