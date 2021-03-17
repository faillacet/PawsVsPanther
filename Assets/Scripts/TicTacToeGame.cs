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

    public Sounds Sounds;
    public ComputerPlayer ComputerPlayer;
    

    private int numberOfTurnsPlayed;
    private bool isWaitingForComputerToPlay;
 

    private void Start()
    {
        Reset();
      
    }

    public void PlaceMarkerInSlot(Slot slot)
    {
        if (GameNotOver())
        {
            UpdateSlotImage(slot);
            Sounds.PlayRandomMarkerSound();
            CheckForWinner();

            EndTurn();
        }
    }

    public void OnSlotClicked(Slot slot)
    {
        if (!isWaitingForComputerToPlay)
            PlaceMarkerInSlot(slot);
    }

    public void OnResetButtonClick()
    {
        Sounds.PlayResetButtonSound();
        Reset();

    }

    public void Reset()
    {
        //players
        ResetPlayers();
        //displays
        ResetDisplays();
        ResetSlots();
        ResetSounds();
        //sounds

        numberOfTurnsPlayed = 0;
        ResetSlots();
    }

    public void ChangeOpponent() {
        Reset();
    }

    public MarkerType CurrentMarkerType()
    {
        return currentMarkerType;
    }

    public MarkerType FirstPlayerMarkerType()
    {
        return firstPlayerMarkerType;
    }

    private void ResetSlots()
    {
        Slots.Reset();
    }

    private void ResetSounds()
    {
        Sounds.Reset();
    }

    private void ResetPlayers() {
        TicTacToeResolver.Reset();
        RandomizePlayer();
        firstPlayerMarkerType = currentMarkerType;
        isWaitingForComputerToPlay = false;
    }

    private void ResetDisplays() {
        TurnDisplay.Reset(currentMarkerType);
        WinnerDisplay.Reset();
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
        PlayEndOfGameSound();
        WinnerDisplay.Show(TicTacToeResolver.Winner());
    }

    private void PlayEndOfGameSound()
    {
        if (TicTacToeResolver.Winner() == MarkerType.Tie)
            Sounds.PlayTieGameSound();
        else
            Sounds.PlayGameOverSound();
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

    private void PlayComputerTurn()
    {
        StartCoroutine(PauseForComputerPlayer());
    }

    IEnumerator PauseForComputerPlayer()
    {
        isWaitingForComputerToPlay = true;
        float secondsToWait = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(secondsToWait);
        isWaitingForComputerToPlay = false;
        ComputerPlayer.PlayComputerTurnAfterPause();
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
