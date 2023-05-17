using UnityEngine;
using System;
using TMPro;

public class History : MonoBehaviour
{
    public TextMeshProUGUI expense;
    public TextMeshProUGUI date;

    private void Start()
    {
        if (expense != null)
        {
            date.text = DateTime.Now.ToString();
            expense.text = PlayerPrefs.GetString("expense");
        }
    }

    public void ClearHistory()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            Destroy(gameObject.transform.GetChild(i).gameObject);
    }
}
