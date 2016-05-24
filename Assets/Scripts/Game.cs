using UnityEngine;
using System;
using System.Collections.Generic;

public class Game
{
	public enum Type { STANDARD, CUSTOM };
	private Type type = Type.STANDARD;

	private GameController controller;

	private List<Square> board = new List<Square> ();
	private GameState currentState;
	private GameState testState;

	private int boardWidth;
	private int boardHeight;

	public Game (GameController controller, Type t, GameObject square_prefab, int numPlayers = 2, int boardWidth = 8, int boardHeight = 8)
	{
		this.controller = controller;
		switch (t) {
		case(Type.STANDARD):
			currentState = new GameState(numPlayers);
			this.boardWidth = boardWidth;
			this.boardHeight = boardHeight;

			for (int i = 0; i < boardHeight; i++) {
				for (int j = 0; j < boardWidth; j++) {
					GameObject sq = GameObject.Instantiate (square_prefab) as GameObject;
					Square square = sq.GetComponent<Square> ();
					square.setPos (new Square.BoardPosition (i, j));
					sq.transform.position = new Vector3 (-3.5f + j, 3.5f - i, 0f);
					if ((i + j) % 2 != 0)
						square.setColor (Color.black);
					
					board.Add (square);
				}
			}

			Piece p = GameObject.Instantiate(controller.queen_prefab).GetComponent<Queen>();
			//currentState.createPiece(p, getSquare(0, 0), 0);


			break;
		
		default:
			break;
		}
	}
	
	
	public int getPlayerCount() {
		return currentState.getPlayerCount();
	}
	
	public Player getPlayer(int num) {
		return currentState.getPlayer (num);
	}

	public List<Piece> getPieces() {
		return currentState.getPieces ();
	}

	public Square getSquare(int row, int column) {
		return board [row * boardWidth + column];
	}

	public void createPiece(GameObject prefab, Square s, Player player) {
		currentState.createPiece (prefab, s, player);
	}
	
	public void createPiece(Piece p, Square s, Player player) {
		currentState.createPiece(p, s, player);
		
		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
	}
	
	public void movePiece(Piece p, Square s) {
		currentState.movePiece (p, s);
	}
}

