using UnityEngine;
using System.Collections;

public class Queen : Piece {

	public Queen(Square s, Player p) : base(s, p) {

	}

	public override bool canMove(int x, int y) {
		return true;
	}
}
