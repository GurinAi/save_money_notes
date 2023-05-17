using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Сalculator : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI remainingAmountText;
    [SerializeField] TextMeshProUGUI inputAmountText;
    [SerializeField] TextMeshProUGUI totalAmountText;

    [SerializeField] Transform container;
    [SerializeField] GameObject expenseHistory;
    private GameObject prefab;


    public void OnClickNumber(string number)
    {
        if (inputAmountText.text[0] == '0')
            inputAmountText.text = number;
        else
            inputAmountText.text += number;
    }

    public void OnClickBackspace()
    {
        if (inputAmountText.text.Length == 1)
            inputAmountText.text = "0";
        else
            inputAmountText.text = inputAmountText.text[..^1];
    }

    public void ToDeductExpense()
    {
        float amount = Convert.ToSingle(remainingAmountText.text);
        float expense = Convert.ToSingle(inputAmountText.text);

        if (amount < expense)
        {
            remainingAmountText.text = "0";
            remainingAmountText.color = Color.red;
        }
        else
        {
            remainingAmountText.text = (amount - expense).ToString();
        }        
        if (expense != 0)
        {
            PlayerPrefs.SetString("expense", expense.ToString());
            prefab = Instantiate(expenseHistory, new Vector3(0, 0, 0), Quaternion.identity);
            prefab.transform.SetParent(container);
        }

        inputAmountText.text = "0";
    }
    public void ChangeAmount()
    {
        PlayerPrefs.SetString("totalAmount", inputAmountText.text);
        totalAmountText.text = PlayerPrefs.GetString("totalAmount");
        remainingAmountText.text = (Convert.ToInt32(totalAmountText.text) / 30).ToString();
        PlayerPrefs.SetString("remaining", remainingAmountText.text);
    }

}
