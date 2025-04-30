using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int cardValue;            //ī�� �� (ī�� �ܰ�)
    public Sprite cardlmage;         //ī�� �̹���
    public TextMeshPro cardText;     //ī�� �ؽ�Ʈ

    //ī�� ���� �ʱ�ȭ �Լ�
    public void InitCard(int value, Sprite image)
    {
        cardValue = value;
        cardlmage = image;

        GetComponent<SpriteRenderer>().sprite = image;

        if (cardText != null)
        {
            cardText.text = cardValue.ToString();
        }

    }
}
