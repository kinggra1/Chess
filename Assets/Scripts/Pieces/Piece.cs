using UnityEngine;
using System.Collections;

public abstract class Piece : MonoBehaviour {

	private Player player;
	private Square square;

	public Piece () {
	
	}

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

	public void setPlayer(Player p) {
		this.player = p;
	}

	public Player getPlayer() {
		return player;
	}

	public void place(Square pos) {

	}

	public abstract bool canMove(int x, int y);
	
}

