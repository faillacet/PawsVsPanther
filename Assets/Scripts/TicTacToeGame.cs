using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGame : MonoBehaviour
{
    public Slots Slots;
    public TicTacToeResolver TicTacToeResolver;

    private MarkerType currentMarkerType;
    private MarkerType firstPlayerMarkerType;

    public TurnDisplay TurnDisplay;
    public WinnerDisplay WinnerDisplay;
    public GameMode GameMode;

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
        ResetPlayers();
        //displays
        ResetDisplays();
        //sounds

        numberOfTurnsPlayed = 0;
        ResetSlots();
    }

    public void ChangeOpponent() {
        Reset();
    }

    private void ResetSlots()
    {
        Slots.Reset();
    }

    private void ResetPlayers() {
        TicTacToeResolver.Reset();
        RandomizePlayer();
        firstPlayerMarkerType = currentMarkerType;
    }

    private void ResetDisplays() {
        TurnDisplay.Reset(currentMarkerType);
        WinnerDisplay.Reset();
    }

    private void PlaceMarkerInSlot(Slot slot)
    {
        if (GameNotOver()) {
            UpdateSlotImage(slot);
            CheckForWinner();

            EndTurn();
        }
    }

    private bool GameNotOver() {
        return TicTacToeResolver.NoWinner();
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
        if (GameNotOver()) {
            ChangePlayer();
        }
        else {
            ShowWinner();
        }
        
    }

    private void ShowWinner() {
        WinnerDisplay.Show(TicTacToeResolver.Winner());
    }

    private void ChangePlayer()
    {

        if (currentMarkerType == MarkerType.Paw)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;

        TurnDisplay.Show(currentMarkerType);

        SeeIfComputerShouldPlay();
    }

    private void SeeIfComputerShouldPlay() {
        if (IsHumanTurn()) {
            return;
        }
        if (IsPlayingComputerOpponent()) {
            PlayComputerTurn();
        }
    }

    private bool IsPlayingComputerOpponent() {
        return GameMode.GetOpponentType() != OpponentType.Human;
    }

    private void PlayComputerTurn() {
        if (GameMode.GetOpponentType() == OpponentType.EasyComputer) {
            PlayEasyComputerMove();
        }
        else if (GameMode.GetOpponentType() == OpponentType.HardComputer) {
            PlayHardComputerMove();
        }
    }

    private void PlayHardComputerMove() {
        bool hasWon = TryToWin();
        if (hasWon) {
            return;
        }
          
        bool hasBlocked = TryToBlock();
        if (hasBlocked) {
            return;
        }    

        PlayMarkerInRandomSlot();
        return;
    }

    private bool TryToWin() {
        return false;
    }

    private bool TryToBlock() {
        return false;
    }

    private void PlayMarkerInRandomSlot() {
        Slot slot = Slots.RandomFreeSlot();
        PlaceMarkerInSlot(slot);
    }

    private void PlayEasyComputerMove() {
       PlayMarkerInRandomSlot();
    }

    private bool IsHumanTurn() {
        return currentMarkerType == firstPlayerMarkerType;
    }

    private void UpdateSlotImage(Slot slot)
    {
        Slots.UpdateSlot(slot, currentMarkerType);
    }

    private void RandomizePlayer() {
        int randomNumber = Random.Range(1,3);
        if (randomNumber == 1) {
            currentMarkerType = MarkerType.Panther;
        }
        else {
            currentMarkerType = MarkerType.Paw;
        }

    }

}
