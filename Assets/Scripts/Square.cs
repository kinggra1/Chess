using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	private Color color = Color.white;
	private Piece piece;
	BoardPosition pos;

	public class BoardPosition {
		public int x;
		public int y;
		public BoardPosition(int x, int y) { this.x = x; this.y = y; }
	}

	public BoardPosition getPos() {
		return pos;
	}

	public void setPos(BoardPosition pos) {
		this.pos = pos;
	}

	public Piece getPiece() {
		return piece;
	}

	public void setPiece(Piece piece) {
		this.piece = piece;
		if (piece == null)
			return;
		
		piece.transform.position = this.transform.position;
	}

	void OnMouseEnter() {
		Color c = GetComponent<SpriteRenderer>().color;
		if (color == Color.white) {
			c.r = 0.6f;
			c.b = 0.6f;
		} else {
			c.g = 0.4f;
		}
		GetComponent<SpriteRenderer> ().color = c;
	}

	void OnMouseExit() {
		Color c = GetComponent<SpriteRenderer>().color;
		if (color == Color.white) {
			c.r = 1f;
			c.b = 1f;
		} else {
			c.g = 0f;
		}
		GetComponent<SpriteRenderer> ().color = c;
	}

	void OnMouseDown() {

		Piece heldPiece = GameController.getHeldPiece ();
		if (heldPiece == null) {
			GameController.setHeldPiece(piece);
		} 

		// currently holding a piece
		else {
			if (heldPiece == piece) {
				// drop the piece back where it was
				GameController.dropHeldPiece();
			}
			else {
				// see if we can move the piece here, do so if possible
				if (heldPiece.canMove(this))
					GameController.moveHeldPiece(this);
				else
					GameController.dropHeldPiece();
			}
		}
	}

	public void setColor(Color color) {
		this.color = color;
		GetComponent<SpriteRenderer>().color = color;
	}
}
