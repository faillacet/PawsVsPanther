using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGame : MonoBehaviour
{
    public Slots Slots;
    public TicTacToeResolver TicTacToeResolver;
    private MarkerType currentMarkerType;

    private int numberOfTurnsPlayed;
 

    private void Start()
    {
        Reset();
      
    }

    public void OnSlotClicked(Slot slot)
    {
        PlaceMarkerInSlot(slot);
    }

    public void Reset()
    {
        //players
        //displays
        //sounds

        numberOfTurnsPlayed = 0;
        ResetSlots();
        currentMarkerType = MarkerType.Paw;
    }

    private void ResetSlots()
    {
        Slots.Reset();
    }

    private void PlaceMarkerInSlot(Slot slot)
    {
        UpdateSlotImage(slot);
        CheckForWinner();

        EndTurn();
    }

    private void CheckForWinner()
    {
        numberOfTurnsPlayed++;
        if (numberOfTurnsPlayed < 5)
            return;
        // check to see if someone won
        TicTacToeResolver.CheckForEndOfGame(Slots.SlotOccupants());
    }

    private void EndTurn()
    {
        ChangePlayer();
    }

    private void ChangePlayer()
    {

        if (currentMarkerType == MarkerType.Paw)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;
    }

    private void UpdateSlotImage(Slot slot)
    {
        Slots.UpdateSlot(slot, currentMarkerType);
    }
}
