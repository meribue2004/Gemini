using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPiecesMoveSystemS : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 initialPosition;
    private Collider2D col;
    public string pieceID; // Unique ID for each piece

    //public GameObject gunImage;
    public bool isCorrectlyPlaced = false;
    //private PuzzleManager puzzlemanager;
    void Start()
    {
        col = GetComponent<Collider2D>();
        //puzzlemanager = FindObjectOfType<PuzzleManager>();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        initialPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if(isCorrectlyPlaced)
        {
            Debug.Log("Piece already placed correctly");
            return; 
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider != col && collider.gameObject.CompareTag("Piece1"))
            {
                GunPiecesMoveSystemS otherPiece = collider.GetComponent<GunPiecesMoveSystemS>();
                if (otherPiece != null && otherPiece.pieceID == pieceID)
                {
                    // Matching condition based on piece ID
                    transform.position = collider.transform.position;
                    // Disable dragging for this piece once it's placed
                    isDragging = false;
                    isCorrectlyPlaced = true;
                    //puzzlemanager.CheckPuzzleCompletion();
                    // Add any additional actions for a matched puzzle piece
                    break;
                }
                else
                {
                    // If no match, return the piece to its initial position
                    transform.position = initialPosition;
                }
            }
            if (collider != col && collider.gameObject.CompareTag("Piece2"))
            {
                GunPiecesMoveSystemS otherPiece = collider.GetComponent<GunPiecesMoveSystemS>();
                if (otherPiece != null && otherPiece.pieceID == pieceID)
                {
                    // Matching condition based on piece ID
                    transform.position = collider.transform.position;
                    // Disable dragging for this piece once it's placed
                    isDragging = false;
                    isCorrectlyPlaced = true;
                    //puzzlemanager.CheckPuzzleCompletion();
                    // Add any additional actions for a matched puzzle piece
                    break;
                }

                else
                {
                    // If no match, return the piece to its initial position
                    transform.position = initialPosition;
                }
            }
            if (collider != col && collider.gameObject.CompareTag("Piece3"))
            {
                GunPiecesMoveSystemS otherPiece = collider.GetComponent<GunPiecesMoveSystemS>();
                if (otherPiece != null && otherPiece.pieceID == pieceID)
                {
                    // Matching condition based on piece ID
                    transform.position = collider.transform.position;
                    // Disable dragging for this piece once it's placed
                    isDragging = false;
                    isCorrectlyPlaced = true;
                    //puzzlemanager.CheckPuzzleCompletion();
                    // Add any additional actions for a matched puzzle piece
                    break;
                }

                else
                {
                    // If no match, return the piece to its initial position
                    transform.position = initialPosition;
                }
            }
            if (collider != col && collider.gameObject.CompareTag("Piece4"))
            {
                GunPiecesMoveSystemS otherPiece = collider.GetComponent<GunPiecesMoveSystemS>();
                if (otherPiece != null && otherPiece.pieceID == pieceID)
                {
                    // Matching condition based on piece ID
                    transform.position = collider.transform.position;
                    // Disable dragging for this piece once it's placed
                    isDragging = false;
                    isCorrectlyPlaced = true;
                    //puzzlemanager.CheckPuzzleCompletion();
                    // Add any additional actions for a matched puzzle piece
                    break;
                }

                else
                {
                    // If no match, return the piece to its initial position
                    transform.position = initialPosition;
                }
            }
            if (collider != col && collider.gameObject.CompareTag("Piece5"))
            {
                GunPiecesMoveSystemS otherPiece = collider.GetComponent<GunPiecesMoveSystemS>();
                if (otherPiece != null && otherPiece.pieceID == pieceID)
                {
                    // Matching condition based on piece ID
                    transform.position = collider.transform.position;
                    // Disable dragging for this piece once it's placed
                    isDragging = false;
                    isCorrectlyPlaced = true;
                    //puzzlemanager.CheckPuzzleCompletion();
                    // Add any additional actions for a matched puzzle piece
                    break;
                }

                else
                {
                    // If no match, return the piece to its initial position
                    transform.position = initialPosition;
                }
            }
        }
        if(isCorrectlyPlaced)
        {
            GunCompletion.counter++;
            Debug.Log("Piece placed correctly");
            //puzzlemanager.CheckPuzzleCompletion();
        }
    }
}