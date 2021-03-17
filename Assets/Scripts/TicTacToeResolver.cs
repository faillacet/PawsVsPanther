using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeResolver : MonoBehaviour
{
    private MarkerType winner;

    private List<List<int>> winningConfigurations = new List<List<int>>
    {
        new List<int> {0, 1, 2},
        new List<int> {3, 4, 5},
        new List<int> {6, 7, 8},
        new List<int> {0, 3, 6},
        new List<int> {1, 4, 7},
        new List<int> {2, 5, 8},
        new List<int> {0, 4, 8},
        new List<int> {2, 4, 6}
    };

    public void Reset()
    {
        winner = MarkerType.None;

    }

    public MarkerType Winner() {
        return winner;
    }

    public void CheckForEndOfGame(List<MarkerType> slotOccupants)
    {
        foreach(List<int> winningConfiguration in winningConfigurations)
        {

            if(AllThreeSlotsFull(winningConfiguration, slotOccupants))
            {
                if(SamePlayerInAllThreeSlots(winningConfiguration, slotOccupants))
                {
                    int slotA = winningConfiguration[0];
                    winner = slotOccupants[slotA];
                }

            }
        }
        if (NoWinner())
        {
            if (isTie(slotOccupants))
            {
                winner = MarkerType.Tie;
            }
        }
    }

    public bool NoWinner()
    {
        return winner == MarkerType.None;
    }

    private bool isTie(List<MarkerType> slotOccupants)
    {
        if (AreAllSlotsFull(slotOccupants))
        {
            return true;
        }  
        return false;
    }

    private bool AreAllSlotsFull(List<MarkerType> slotOccupants)
    {
        bool allSlotsFull = true;
        foreach(MarkerType slotOccupant in slotOccupants)
        {
            if (slotOccupant == MarkerType.None)
            {
                allSlotsFull = false;
            }
        }

        return allSlotsFull;

    }

    private bool AllThreeSlotsFull(List<int> winningConfiguaration, List<MarkerType> slotOccupants)
    {
        int slotA = winningConfiguaration[0];
        int slotB = winningConfiguaration[1];
        int slotC = winningConfiguaration[2];

        if (slotOccupants[slotA] != MarkerType.None && //2
            slotOccupants[slotB] != MarkerType.None && //5
            slotOccupants[slotC] != MarkerType.None) //8
        {
            return true;
        }
        return false;

    }

    private bool SamePlayerInAllThreeSlots(List<int> winningConfiguaration, List<MarkerType> slotOccupants)
    {
        int slotA = winningConfiguaration[0];
        int slotB = winningConfiguaration[1];
        int slotC = winningConfiguaration[2];

        if(slotOccupants[slotA] == slotOccupants[slotB] && slotOccupants[slotB] == slotOccupants[slotC])
        {
            return true;
        }
        return false;
    }
}