using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    public TicTacToeGame TicTacToeGame;
    public GameMode GameMode;
    public Slots Slots;
    public TicTacToeResolver TicTacToeResolver;

    public void PlayComputerTurnAfterPause()
    {
        if (GameMode.GetOpponentType() == OpponentType.EasyComputer)
        {
            PlayEasyComputerMove();
        }
        else if (GameMode.GetOpponentType() == OpponentType.HardComputer)
        {
            PlayHardComputerMove();
        }
    }

    private void PlayHardComputerMove()
    {
        bool hasWon = TryToWin();
        if (hasWon)
        {
            return;
        }

        bool hasBlocked = TryToBlock();
        if (hasBlocked)
        {
            return;
        }
        PlayMarkerInRandomSlot();

    }

    private bool TryToWin()
    {
        return TryToPlayBestMoveForPlayer(TicTacToeGame.CurrentMarkerType());
    }

    private bool TryToBlock()
    {

        return TryToPlayBestMoveForPlayer(TicTacToeGame.FirstPlayerMarkerType());
    }

    private bool TryToPlayBestMoveForPlayer(MarkerType markerType)
    {
        int bestSlot = TicTacToeResolver.FindBestSlotIndexForPlayer(Slots.SlotOccupants(), markerType);
        if (bestSlot != -1)
        {
            TicTacToeGame.PlaceMarkerInSlot(Slots.GetSlot(bestSlot));
            return true;
        }

        return false;
    }


    private void PlayMarkerInRandomSlot()
    {
        Slot slot = Slots.RandomFreeSlot();
        TicTacToeGame.PlaceMarkerInSlot(slot);
    }

    private void PlayEasyComputerMove()
    {
        PlayMarkerInRandomSlot();
    }
}
