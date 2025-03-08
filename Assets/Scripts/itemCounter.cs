using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ItemCounter : MonoBehaviour

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
        Debug.Log(itemCount);

    }

    // public void SetCount(int newCount)
    // {
    //     itemCount = newCount;
    //     UpdateText();
    // }

    public void UpdateText()
    {
        if (itemCountText != null)
        {
            itemCountText.text = itemCount.ToString();
            Debug.Log(itemCountText);

        }
    }
}
