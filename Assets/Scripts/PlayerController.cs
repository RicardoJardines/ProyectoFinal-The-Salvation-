using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject[] particulas;
    public float force;
    public Vector3 FirstRotation;
    public Image LifeSprite;
    public Text FeithAmount;
    public bool damage;
    public int Feit;
    private Animator playerAnimator;
    private CapsuleCollider capsule;
    private float startColliderHeight;
    private float Life = 100;
    private float currentLife = 100;
    private float speed;
    private int combo=0;
    public Vector3 position;
#if UNITY_IOS || UNITY_ANDROID
    private Vector3 accel;
    private Touch finger;
#endif
    // Use this for initialization
    void Start () {
		playerAnimator = GetComponent<Animator>();
		capsule = GetComponent<CapsuleCollider>();
        startColliderHeight = capsule.height;
        FirstRotation = transform.localEulerAngles;
        position = transform.position;
        if (PlayerPrefs.HasKey("Life"))
            currentLife = PlayerPrefs.GetInt("Life");
        else
            PlayerPrefs.SetInt("Life", (int)Life);

        Life = currentLife;
    }

    // Update is called once per frame
    void Update() {

        LifeSprite.fillAmount = currentLife / Life;

        FeithAmount.text = Feit.ToString();

#if UNITY_STANDALONE
        playerAnimator.SetFloat("speed", Input.GetAxis("Horizontal"));
        
		if (playerAnimator.GetFloat("speed") != 0)
        {
			speed = playerAnimator.GetFloat("speed");
			if(speed<0)
                transform.localEulerAngles = FirstRotation + new Vector3(0,180,0);
			else
                transform.localEulerAngles = FirstRotation + new Vector3(0,0,0);
            transform.Translate(Vector3.forward *2f*Time.deltaTime);

           if(FirstRotation.y == 0 || FirstRotation.y == 180 || FirstRotation.y == 360)
                transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
           else
                transform.position = new Vector3(transform.position.x, transform.position.y, position.z);
        }

		if (Input.GetKeyDown(KeyCode.Space)  )
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            combo++;
            string attac = "Attack" + combo.ToString();
            playerAnimator.SetTrigger(attac);
            if (combo == 3)
                combo = 0;
        }

        if (damage)
        {
            currentLife -= 5;
            playerAnimator.SetTrigger("Damage");
        }
        
        
       


        if(currentLife <= 0)
        {
            StartCoroutine(AnimDie());

        }
#endif

#if UNITY_IOS || UNITY_ANDROID
        accel = Input.acceleration;
        playerAnimator.SetFloat("direction", accel.x);

        if (Input.touchCount > 0)
        {
            for (int i=0; i<Input.touchCount; i++)
            {
                finger = Input.GetTouch(i);
                if (finger.position.x >= Screen.width * 0.5f)
                {
                    playerAnimator.SetFloat("speed", 1);
                }
                else
                {
                    playerAnimator.SetFloat("speed", 0);
                    if (finger.phase == TouchPhase.Began && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
                    playerAnimator.SetTrigger("jump");
                }
            }
            
        }
        else
        {
            playerAnimator.SetFloat("speed", 0);
        }
            

        if (playerAnimator.GetFloat("speed") > 0)
        {
            for(int i = 0; i< particulas.Length; i++)
            {
                particulas[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < particulas.Length; i++)
            {
                particulas[i].SetActive(false);
            }
        }

#endif

        damage = false;

    }


    

    IEnumerator AnimDie()
    {
        playerAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
