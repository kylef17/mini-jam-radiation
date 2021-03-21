using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool radGunActive;
    public RadiationGun radGun;
    public CursorController cursorController;
    public HotbarControl hotBarControl;
    public GameObject hotbar;
    public int numButtons;
    public FishPickup fishPickup;
    public IonPoints ionPoints;

    private int prevIonPoints;

    void Start()
    {
        radGunActive = false;
        hotBarControl.addedFish += UpdateHotbar;
        hotBarControl.InitHotbar();
        InitHotbarHitbox();
    }
    void Update()
    {
        if (radGunActive)
        {
            fishPickup.noOtherTools = false;
        }
        if (!radGunActive)
        {
            radGun.gameObject.SetActive(false);
            fishPickup.noOtherTools = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            radGun.gameObject.SetActive(false);
            radGunActive = false;
            cursorController.ResetCursor();
        }

        if (prevIonPoints != ionPoints.ionPoints)
        {
            UpdateHotbar();
        }
    }

    private void InitHotbarHitbox()
    {
        for(int i=0; i<numButtons; i++)
        {
            Button button = hotbar.transform.GetChild(i).GetComponent<Button>();
            RectTransform buttonTransform = (RectTransform)button.transform;
            button.GetComponent<BoxCollider2D>().size = new Vector2(buttonTransform.rect.width, buttonTransform.rect.height);
        }
    }

    private void UpdateHotbar()
    {
        if (hotBarControl.fish.Length == numButtons)
        {
            int i = 0;
            foreach (GameObject fish in hotBarControl.fish)
            {
                Button button = hotbar.transform.GetChild(i).GetComponent<Button>();
                Image ButtonImage = hotbar.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>();
                Image LockImage = hotbar.transform.GetChild(i).gameObject.transform.GetChild(1).GetComponent<Image>();
                prevIonPoints = ionPoints.ionPoints;
                if (fish != null)
                {
                    SetChildrenInactive(ButtonImage.gameObject, true);
                    ButtonImageRender buttonRender = ButtonImage.gameObject.GetComponent<ButtonImageRender>();
                    buttonRender.head = fish.GetComponent<FishGenerator>().head;
                    buttonRender.body = fish.GetComponent<FishGenerator>().body;
                    buttonRender.tail = fish.GetComponent<FishGenerator>().tail;

                    if (!ionPoints.checkIonPoints(fish.GetComponent<FishIonPoints>().cost))
                    {
                        LockImage.gameObject.SetActive(true);
                    } else
                    {
                        LockImage.gameObject.SetActive(false);
                    }

                    button.GetComponent<ButtonStatDisplay>().fish = fish;
                } else
                {
                    SetChildrenInactive(ButtonImage.gameObject, false);
                    LockImage.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }

    private void SetChildrenInactive(GameObject gameObject, bool setting)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(setting);
        gameObject.transform.GetChild(1).gameObject.SetActive(setting);
        gameObject.transform.GetChild(2).gameObject.SetActive(setting);
    }

    public void RadiationGunButton()
    {
        radGun.gameObject.SetActive(true);
        radGunActive = true;
    }
}
