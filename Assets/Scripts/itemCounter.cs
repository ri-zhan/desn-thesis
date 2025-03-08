using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class itemCounter : MonoBehaviour
{
    public TMP_Text itemCountText; // UI Text element
    public int itemCount = 0; // Item count

    private void Start() 
    {
        itemCount = 0;
    }

    public void IncrementCount()
    {
        itemCount++;
        UpdateText();
    }

    public void SetCount(int newCount)
    {
        itemCount = newCount;
        UpdateText();
        Debug.Log(itemCount);
    }

    private void UpdateText()
    {
        // if (itemCountText != null)
        // {
            itemCountText.text = itemCount.ToString();

        // }
    }
}
