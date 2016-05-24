using UnityEngine;
using System;
using System.Collections.Generic;

public class GameState
{
	private List<Player> players = new List<Player>();

	public GameState (int numPlayers = 2)
	{
		for (int i = 0; i < numPlayers; i++) {
			players.Add (new Player());
		}
	}

	/// <summary>
	/// Copy Constructor
	/// </summary>
	/// <param name="state">State.</param>
	public GameState(GameState state) {
		this.players = state.players;
	}


	public int getPlayerCount() {
		return players.Count;
	}

	public Player getPlayer(int num) {
		return players [num];
	}

	public List<Piece> getPieces() {
		List<Piece> pieces = new List<Piece>();
		foreach (Player p in players) {
			pieces.AddRange(p.getPieces());
		}
		return pieces;
	}

	public void createPiece(GameObject prefab, Square s, Player player) {
		
	}
	
	public void createPiece(Piece p, Square s, Player player) {
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
		player.addPiece (p);
	}
	
	public void movePiece(Piece p, Square s) {
		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
	}
}

