using UnityEngine;

public class EarthColorChanger : MonoBehaviour
{
    private Material groundMat;
    private Material waterMat;
    [SerializeField] private Color groundStartColor, groundEndColor;
    [SerializeField] private Color waterStartColor, waterEndColor;
    private Color groundColorChager;
    private Color waterColorChanger;

    // Start is called before the first frame update
    private void Start()
    {
        groundMat = GetComponent<MeshRenderer>().materials[1];
        waterMat = GetComponent<MeshRenderer>().materials[0];

        groundMat.color = groundStartColor;
        waterMat.color = waterStartColor;

        groundColorChager = groundEndColor - groundStartColor;
        groundColorChager /= GameManager.instance.scoreGoal;

        waterColorChanger = waterEndColor - waterStartColor;
        waterColorChanger /= GameManager.instance.scoreGoal;
        GameManager.instance.OnSuccessfulHit += OnSuccessfulHit;
    }

    private void OnSuccessfulHit()
    {
        ChangeEarthColor();
    }

    public void ChangeEarthColor()
    {
        groundMat.color = groundMat.color + groundColorChager;
        waterMat.color = waterMat.color + waterColorChanger;
    }
}