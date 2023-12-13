using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject completionImage; // Reference to the completion image or GameObject

    void Start()
    {
        completionImage.SetActive(false);
    }
    // Function to check if all puzzle pieces are in correct positions
    public void CheckPuzzleCompletion()
    {
        GunPiecesMoveSystemS[] puzzlePieces = FindObjectsOfType<GunPiecesMoveSystemS>();
        bool allPiecesCorrect = true;

        foreach (GunPiecesMoveSystemS piece in puzzlePieces)
        {
            if (!piece.isCorrectlyPlaced)
            {
                allPiecesCorrect = false;
                break;
            }
        }

        if (allPiecesCorrect)
        {
            Debug.Log("All pieces correctly placed");
            ActivateCompletionImage();
        }
    }

    // Function to activate the completion image or GameObject
    public void ActivateCompletionImage()
    {
        if (completionImage != null)
        {
            completionImage.SetActive(true);
            Debug.Log("Completion image activated");
        }
    }
}
