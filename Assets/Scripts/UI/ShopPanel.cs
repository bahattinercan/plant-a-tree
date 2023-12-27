using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public void Open()
    {

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);

    }
}
