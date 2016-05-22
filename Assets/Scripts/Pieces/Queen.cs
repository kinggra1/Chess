using UnityEngine;
using System.Collections;

public class Queen : Piece {

	public Queen(Square s, Player p) : base(s, p) {

	}

	public override bool canMove(Square s) {
		Square.BoardPosition newPos = s.getPos ();
		int newX = newPos.x;
		int newY = newPos.y;
		Square.BoardPosition pos = getSquare().getPos ();
		int x = pos.x;
		int y = pos.y;

		if (x == newX || y == newY || Mathf.Abs(x - newX) == Mathf.Abs(y - newY))
			return true;

		return false;
	}

	public override void updatePossibleMoves() {
		
	}
}
