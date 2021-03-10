using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Sprite PawSprite;
    public Sprite PantherSprite;

    public TicTacToeGame Game;
    public void OnSlotClicked(Slot slot)
    {
        Game.OnSlotClicked(slot);
    }

    public void UpdateSlot(Slot slot, MarkerType markerType)
    {
        //Set Image, set Player
        SetSlotImage(slot, markerType);
    }

    private void SetSlotImage(Slot slot, MarkerType marker)
    {
        if (marker == MarkerType.Panther)
            slot.Mark(PantherSprite);
        else
            slot.Mark(PawSprite);
    }
}
