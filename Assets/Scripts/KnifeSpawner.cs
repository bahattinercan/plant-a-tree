using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject knifePrefab;

    private Text scoreText;
    private Animator scoreTextAnim;

    private void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        scoreTextAnim = scoreText.GetComponent<Animator>();
    }

    private void Start()
    {
        scoreText.text = GameManager.instance.score + "/" + GameManager.instance.scoreGoal;
    }

    public void SpawnKnife()
    {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        go.transform.SetParent(spawnPoint);
    }

    public void IncreaseScore()
    {
        GameManager.instance.score++;
        scoreText.text = GameManager.instance.score.ToString() + "/" + GameManager.instance.scoreGoal;
        scoreTextAnim.Play("scoreText_score");
    }
}