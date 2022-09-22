using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody myBody;
    private bool onWood;

    private KnifeSpawner knifeSpawner;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        knifeSpawner = GameObject.FindGameObjectWithTag("KnifeSpawner").GetComponent<KnifeSpawner>();
    }

    private void Start()
    {
        speed *= GameManager.instance.levelSO.treeSpeedMultiplier;
        transform.localScale *= GameManager.instance.levelSO.treeScaleMultiplier;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !onWood)
        {
            myBody.velocity = new Vector3(0, speed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            myBody.velocity = Vector3.zero;
            myBody.detectCollisions = false;
            onWood = true;
            gameObject.transform.SetParent(other.transform);            

            if (GameManager.instance.levelSO.willWorldReverseWhenHitSuccessful)
            {
                other.GetComponent<Wood>().ReverseRotate();
            }
            knifeSpawner.SpawnKnife();
            knifeSpawner.IncreaseScore();
            SoundManager.instance.PlaySound(SoundManager.clipTypes.hit);
            GameManager.instance.Invoke_OnSuccessfulHit();
            
            if (GameManager.instance.score >= GameManager.instance.scoreGoal)
            {
                GameManager.instance.OnGameFinished_Invoke(true);
                SoundManager.instance.PlaySound(SoundManager.clipTypes.win);                
            }
        }
        else if (other.gameObject.CompareTag("Knife"))
        {
            GameManager.instance.OnGameFinished_Invoke(false);            
            SoundManager.instance.PlaySound(SoundManager.clipTypes.lose);
            Destroy(gameObject);            
        }
    }
}