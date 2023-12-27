using UnityEngine;

public class InventoryPanel : MonoBehaviour
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
