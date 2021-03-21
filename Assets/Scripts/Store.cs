using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Image storeDropDown;
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject fish4;
    private GameObject[] fishes;
    public Button fish1Button;
    public Button fish2Button;
    public Button fish3Button;
    public Button fish4Button;
    private Button[] buttons;
    private bool fish1Purchased;
    private bool fish2Purchased;
    private bool fish3Purchased;
    private bool fish4Purchased;
    private bool[] purchased;

    public Sprite[] fish1NotPurchased = new Sprite[3];
    public Sprite[] fish2NotPurchased = new Sprite[3];
    public Sprite[] fish3NotPurchased = new Sprite[3];
    public Sprite[] fish4NotPurchased = new Sprite[3];
    private Sprite[][] fishNotPurchasedSprites;

    public IonPoints ionPoints;
    public FishPlacement fishPlacement;

    void Start()
    {
        fishes = new GameObject[4] {  fish1, fish2, fish3, fish4 };
        buttons = new Button[4] { fish1Button, fish2Button, fish3Button, fish4Button };
        purchased = new bool[4] { fish1Purchased, fish2Purchased, fish3Purchased, fish4Purchased };
        fishNotPurchasedSprites = new Sprite[][] { fish1NotPurchased, fish2NotPurchased, fish3NotPurchased, fish4NotPurchased };

        for (int i=0; i<buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonStatDisplay>().fish = fishes[i];
            RectTransform buttonTransform = (RectTransform)buttons[i].transform;
            buttons[i].GetComponent<BoxCollider2D>().size = new Vector2(buttonTransform.rect.width, buttonTransform.rect.height);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hideDropDown();
        }

        // set lock images
        for (int i = 0; i<fishes.Length; i++)
        {
            CheckLockImage(buttons[i], i);
        }

        SetButtonImages();
    }

    public void SetButtonImages()
    {
        for (int i=0; i<fishes.Length; i++)
        {
            ButtonImageRender buttonRender = buttons[i].transform.GetChild(0).GetComponent<ButtonImageRender>();
            if (!purchased[i])
            {
                buttonRender.head = fishNotPurchasedSprites[i][0];
                buttonRender.body = fishNotPurchasedSprites[i][1];
                buttonRender.tail = fishNotPurchasedSprites[i][2];
            } else
            {
                buttonRender.head = fishes[i].GetComponent<FishGenerator>().head;
                buttonRender.body = fishes[i].GetComponent<FishGenerator>().body;
                buttonRender.tail = fishes[i].GetComponent<FishGenerator>().tail;
            }
        }
    }

    public void CheckLockImage(Button button, int fishNumber)
    {
        Image lockImage = button.transform.GetChild(1).GetComponent<Image>();

        if (ionPoints.checkIonPoints(fishes[fishNumber].GetComponent<FishIonPoints>().cost))
        {
            lockImage.gameObject.SetActive(false);
        } else
        {
            lockImage.gameObject.SetActive(true);
        }
    }

    public void showDropDown()
    {
        storeDropDown.gameObject.SetActive(true);
    }

    public void hideDropDown()
    {
        storeDropDown.gameObject.SetActive(false);
    }

    public void dropDownButton()
    {
        if (storeDropDown.gameObject.activeSelf)
        {
            hideDropDown();
        } else
        {
            showDropDown();
        }
    }

    private void purchaseFish(int index)
    {
        if (ionPoints.checkIonPoints(fishes[index].GetComponent<FishIonPoints>().cost))
        {
            if (!purchased[index])
            {
                purchased[index] = true;
                fishes[index] = Instantiate(fishes[index], Vector2.zero, Quaternion.identity);
                fishes[index].SetActive(false);
            }
            if (fishes[index] == null)
            {
                Debug.Log("fishes[index] null");
            }
            fishPlacement.ShopFishSelect(fishes[index]);
        }        
    }

    public void shopButton1()
    {
        purchaseFish(0);
    }
    public void shopButton2()
    {
        purchaseFish(1);
    }
    public void shopButton3()
    {
        purchaseFish(2);
    }
    public void shopButton4()
    {
        purchaseFish(3);
    }
}
