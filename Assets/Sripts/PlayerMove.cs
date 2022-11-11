using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    Animator ac;
    Vector3 dir;
    private CapsuleCollider col;
    public float speed = 10f;
    public float jumpforse = 3f;
    private int lineToMove = 1;
    private float lineDistanse = 3;
    public float gravity;
    public bool CanPlay = false;
    public Vector3 startpoint;
    [SerializeField]private GameObject losePanel;
    [SerializeField] private Text coinText;
    [SerializeField] private int moneybag;
    IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(2);
        speed++;
        StartCoroutine(SpeedIncrease()); //Асинхрон Здарова
    }
    IEnumerator slide()
    {
        col.center = new Vector3(0, 0.55f, 0);
        col.height = 1;
        yield return new WaitForSeconds(1);
        col.center=new Vector3(0, 0, 0);
        col.height = 2;

    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        ac = GetComponent<Animator>();
        startpoint = cc.transform.position;
        col = GetComponent<CapsuleCollider>();
        Time.timeScale = 1;//Анимации не проигрываются 
        moneybag = PlayerPrefs.GetInt("moneybag");
        coinText.text = moneybag.ToString();
        StartCoroutine(SpeedIncrease()); //Асинхрон Здарова



    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeController.swipeUp)
        { if (cc.isGrounded)
                jump();
        }
        if (SwipeController.swipeRight)
            if(lineToMove<2)
                lineToMove++;
        if (SwipeController.swipeLeft)
            if (lineToMove >0)
                lineToMove--;
        if (SwipeController.swipeDown)
        {
            StartCoroutine(slide());
        }    





        Vector3 newPos = transform.position.z*transform.forward+transform.position.y*transform.up;
        if (lineToMove == 0)
            newPos += Vector3.left*lineDistanse;
        else if (lineToMove == 2)
            newPos += Vector3.right* lineDistanse;
        if (transform.position == newPos)
            return;
        Vector3 diff = newPos - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            cc.Move(moveDir);
        else
            cc.Move(diff);
    }
    private void jump()
    {
        ac.SetTrigger("jump");
        dir.y = jumpforse;
        if (cc.velocity.y < 0)
            ac.SetTrigger("fall");


    }
    private void FixedUpdate()// Физика 
    {
        if (CanPlay)
            dir.z = speed;

        dir.y += gravity * Time.deltaTime;
        cc.Move(dir * Time.fixedDeltaTime);

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("trap"))// TrygetCompany
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            moneybag++;
            PlayerPrefs.SetInt("moneybag", moneybag);
            string kek = "coins " + moneybag.ToString();
            coinText.text = kek;
            Destroy(other.gameObject);
        }
    }

}
