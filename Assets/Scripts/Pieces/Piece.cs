using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour {

	private Player player;
	private Square square;

	private List<Square> possibleMoves = new List<Square>();

	public Piece(Square s, Player player) {
		square = s;
		s.setPiece (this);
		this.player = player;
	}

	public void setSquare(Square s) {
		this.square = s;
	}

	public Square getSquare() {
		return square;
	}

	public void setColor(Color color) {
		GetComponent<SpriteRenderer> ().color = color;
	}

	public void setPlayer(Player p) {
		this.player = p;
	}

	public Player getPlayer() {
		return player;
	}

	public void place(Square pos) {

	}

	public abstract bool canMove(Square s);
	public abstract void updatePossibleMoves();
	
}

