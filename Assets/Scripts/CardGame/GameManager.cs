using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;          //카드 프리팹
    public Sprite[] cardImages;            //카드 이미지 배열

    public Transform deckArea;             //덱 영역
    public Transform handArea;             //손패 영역

    public Button drawButton;
    public TextMeshProUGUI deckCountText;  //남은 덱 카드 수 표시 텍스트

    public float cardSpacing = 2.0f;       //카드 간격
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
            // 배열 내 카드 교환
            GameObject temp = deckCards[i];
            deckCards[i] = deckCards[j];
            deckCards[j] = temp;
        }
    }

    void InitializeDeck()
    {
        deckCount = prefedinedDeck.Length;

        for (int i = 0; i < prefedinedDeck.Length; i++) // 카드 값 가져오기
        {
            int value = prefedinedDeck[i];

            
            int imageIndex = value - 1; // 값이 1부터 시작하므로 인덱스는 0부터
            if (imageIndex >= cardImages.Length || imageIndex < 0)
            {
                imageIndex = 0; // 이미지가 부족하거나 인덱스가 잘못된 경우 첫 번째 이미지 사용
            }

            
            GameObject newCardObj = Instantiate(cardPrefab, deckArea.position, Quaternion.identity);
            newCardObj.transform.SetParent(deckArea);
            newCardObj.SetActive(false); // 처음에는 비활성화

            
            Card cardComp = newCardObj.GetComponent<Card>();
            if (cardComp != null)
            {
                cardComp.InitCard(value, cardImages[imageIndex]);
            }

            deckCards[i] = newCardObj; // 배열에 저장
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

    public void DrawCardToHand() // 덱에서 카드를 뽑아 손패로 이동
    {
        if (handCount >= maxHandSize) 
        {
            Debug.Log("손패가 가득 찼습니다!");
            return;
        }

        if (deckCount <= 0) 
        {
            Debug.Log("덱에 더 이상 카드가 없습니다.");
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

        ArrangeHand(); // 손패 정렬
    }

}

