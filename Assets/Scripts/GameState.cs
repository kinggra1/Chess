using System;
using System.Collections.Generic;

public class GameState
{
	private List<Player> players = new List<Player> ();

	public GameState (int numPlayers = 2)
	{
		for (int i = 0; i < numPlayers; i++) {
			players.Add (new Player());
		}
	}
}

