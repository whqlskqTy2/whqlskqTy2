using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;          //ī�� ������
    public Sprite[] cardImages;            //ī�� �̹��� �迭

    public Transform deckArea;             //�� ����
    public Transform handArea;             //���� ����

    public Button drawButton;
    public TextMeshProUGUI deckCountText;  //���� �� ī�� �� ǥ�� �ؽ�Ʈ

    public float cardSpacing = 2.0f;       //ī�� ����
    public int maxHandSize = 6;

    public GameObject[] deckCards;
    public int deckCount;

    public GameObject[] handCards;
    public int handCount;


    private int[] prefedinedDeck = new int[]
    {
        1,1,1,1,1,1,1,1,
        2,2,2,2,2,2,
        3,3,3,3,
        4,4,
    };
    void Start()
    {
        deckCards = new GameObject[prefedinedDeck.Length];
        handCards = new GameObject[maxHandSize];

        InitializeDeck();
        ShuffleDeck();

        if (drawButton != null)
        {
            drawButton.onClick.AddListener(OnDrawButtonClicked);
        }
    }

    void Update()
    {

    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deckCount - 1; i++)
        {
            int j = Random.Range(i, deckCount);
            // �迭 �� ī�� ��ȯ
            GameObject temp = deckCards[i];
            deckCards[i] = deckCards[j];
            deckCards[j] = temp;
        }
    }

    void InitializeDeck()
    {
        deckCount = prefedinedDeck.Length;

        for (int i = 0; i < prefedinedDeck.Length; i++) // ī�� �� ��������
        {
            int value = prefedinedDeck[i];

            
            int imageIndex = value - 1; // ���� 1���� �����ϹǷ� �ε����� 0����
            if (imageIndex >= cardImages.Length || imageIndex < 0)
            {
                imageIndex = 0; // �̹����� �����ϰų� �ε����� �߸��� ��� ù ��° �̹��� ���
            }

            
            GameObject newCardObj = Instantiate(cardPrefab, deckArea.position, Quaternion.identity);
            newCardObj.transform.SetParent(deckArea);
            newCardObj.SetActive(false); // ó������ ��Ȱ��ȭ

            
            Card cardComp = newCardObj.GetComponent<Card>();
            if (cardComp != null)
            {
                cardComp.InitCard(value, cardImages[imageIndex]);
            }

            deckCards[i] = newCardObj; // �迭�� ����
        }
    }
    public void ArrangeHand()
    {
        if (handCount == 0)
            return;

        float startX = -(handCount - 1) * cardSpacing / 2;

        for (int i = 0; i < handCount; i++)
        {
            if (handCards[1] != null)
            {
                Vector3 newPos = handArea.position + new Vector3(startX + i * cardSpacing, 0, -0.005f);
                handCards[i].transform.position = newPos;
            }
        }

        
    }

    void OnDrawButtonClicked()
    {
        DrawCardToHand();
    }

    public void DrawCardToHand() // ������ ī�带 �̾� ���з� �̵�
    {
        if (handCount >= maxHandSize) 
        {
            Debug.Log("���а� ���� á���ϴ�!");
            return;
        }

        if (deckCount <= 0) 
        {
            Debug.Log("���� �� �̻� ī�尡 �����ϴ�.");
            return;
        }

        GameObject drawnCard = deckCards[0]; 

        for (int i = 0; i < deckCount - 1; i++) 
        {
            deckCards[i] = deckCards[i + 1];
        }

        deckCount--;

        drawnCard.SetActive(true); 
        handCards[handCount] = drawnCard; 
        handCount++;

        drawnCard.transform.SetParent(handArea); 

        ArrangeHand(); // ���� ����
    }

}

