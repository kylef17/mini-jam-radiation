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

    void Start()
    {
        radGunActive = false;
        hotBarControl.addedFish += UpdateHotbar;
        hotBarControl.InitHotbar();
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
    }

    private void UpdateHotbar()
    {
        if (hotBarControl.fish.Length == numButtons)
        {
            int i = 0;
            foreach (GameObject fish in hotBarControl.fish)
            {
                Image ButtonImage = hotbar.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>();
                if (fish != null)
                {
                    SetChildrenInactive(ButtonImage.gameObject, true);
                    ButtonImage.transform.GetChild(0).GetComponent<Image>().sprite = fish.GetComponent<FishGenerator>().head;
                    ButtonImage.transform.GetChild(1).GetComponent<Image>().sprite = fish.GetComponent<FishGenerator>().body;
                    ButtonImage.transform.GetChild(2).GetComponent<Image>().sprite = fish.GetComponent<FishGenerator>().tail;
                } else
                {
                    SetChildrenInactive(ButtonImage.gameObject, false);
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
