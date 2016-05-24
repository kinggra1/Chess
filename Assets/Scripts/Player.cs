using UnityEngine;
using System;
using System.Collections.Generic;

public class Player
{
	private Color color = Color.white;

	private List<Piece> pieces = new List<Piece>();

	public Player() {
	}

	public Player(Color color) {
		this.color = color;
	}

	public void setColor(Color color) {
		this.color = color;
	}

	public Color getColor() {
		return color;
	}

	public void addPiece(Piece p) {
		pieces.Add (p);
		p.setPlayer (this);
	}

	public List<Piece> getPieces() {
		return pieces;
	}

}

