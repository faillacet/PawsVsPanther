using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Sprite PawSprite;
    public Sprite PantherSprite;
    public Sprite BlankSprite;

    private List<MarkerType> slotOccupants;

    public TicTacToeGame Game;
    public List<Slot> SlotsList;
    public void OnSlotClicked(Slot slot)
    {
        Game.OnSlotClicked(slot);
    }

    public void UpdateSlot(Slot slot, MarkerType markerType)
    {
        SetSlotImage(slot, markerType);
        SetSlotOccupant(slot, markerType);
    }

    public List<MarkerType> SlotOccupants()
    {
        return slotOccupants;
    }

    private void SetSlotOccupant(Slot slot, MarkerType markerType)
    {
        int slotIndex = slot.SlotNumber - 1;
        slotOccupants[slotIndex] = markerType;
    }

    private void SetSlotImage(Slot slot, MarkerType marker)
    {
        if (marker == MarkerType.Panther)
            slot.Mark(PantherSprite);
        else
            slot.Mark(PawSprite);
    }

    public void Reset()
    {
        ResetSlotOccupants();
        ResetSlotImages();

      
    }

    private void ResetSlotImages()
    {
        foreach (Slot slot in SlotsList)
            slot.Reset(BlankSprite);
    }

    public void ResetSlotOccupants()
    {
        slotOccupants = new List<MarkerType>();
        for (int i = 0; i < 9; i++)
            slotOccupants.Add(MarkerType.None);
    
    }
}
