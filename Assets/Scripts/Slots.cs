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

     public void Reset()
    {
        ResetSlotOccupants();
        ResetSlotImages();
    }

    public Slot RandomFreeSlot() {
        List<int> emptySlotIndicies = FindEmptySlotIndicies();

        int randomIndex = Random.Range(0, emptySlotIndicies.Count);
        int randomSlotIndex = emptySlotIndicies[randomIndex];
        return SlotsList[randomSlotIndex];
    }

    private List<int> FindEmptySlotIndicies() {
        List<int> emptySlotIndicies = new List<int>();

        for (int i = 0; i < SlotsList.Count; i++) {
            if (SlotsList[i].isEmpty())
                emptySlotIndicies.Add(i);
        }

        return emptySlotIndicies;
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
