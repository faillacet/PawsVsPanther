using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGame : MonoBehaviour
{
    public Slots Slots;
    private MarkerType currentMarkerType;

    private void Start()
    {
        currentMarkerType = MarkerType.Panther;
    }

    public void OnSlotClicked(Slot slot)
    {
        PlaceMarkerInSlot(slot);
    }

    private void PlaceMarkerInSlot(Slot slot)
    {
        UpdateSlotImage(slot);
    }

    private void UpdateSlotImage(Slot slot)
    {
        Slots.UpdateSlot(slot, currentMarkerType);
    }
}
