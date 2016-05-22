using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private static Player player1 = new Player(Color.white);
	private static Player player2 = new Player(Color.black);
	public static List<Square> board = new List<Square>();

	private static GameState currentState;
	private static GameState nextState;

	private static Piece heldPiece;
	
	public GameObject square_prefab;

	public GameObject queen_prefab;
	public GameObject king_prefab;
	public GameObject bishop_prefab;
	public GameObject knight_prefab;
	public GameObject rook_prefab;
	public GameObject pawn_prefab;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				GameObject sq = Instantiate(square_prefab) as GameObject;
				Square square = sq.GetComponent<Square>();
				square.setPos(new Square.BoardPosition(i, j));
				sq.transform.position = new Vector3(-3.5f + i, 3.5f - j, 0f);
				if ((i+j)%2 != 0)
					square.setColor(Color.black);

				board.Add(square);
			}
		}

		GameObject q = Instantiate (queen_prefab) as GameObject;
		Piece queen = q.GetComponent<Piece> ();
		queen.setSquare (board [0]);
		queen.setPlayer (player1);
		placePiece (queen, board [0]);

		q = Instantiate (queen_prefab) as GameObject;
		queen = q.GetComponent<Piece> ();
		queen.setSquare (board [1]);
		queen.setPlayer (player1);
		placePiece (queen, board [1]);
	}
	
	// Update is called once per frame
	void Update () {
		if (heldPiece != null) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			heldPiece.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
		}

		// for cases where we click, drag, and release
		if (Input.GetMouseButtonUp (0) && heldPiece != null) {
			RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
			if (hit.collider != null) {
				Square s = hit.collider.GetComponent<Square>();
				if (s.getPiece() != heldPiece) {
				
					if (heldPiece.canMove(s))
						moveHeldPiece(s);
					else
						dropHeldPiece();
				}
			}
		}
	}

	public static List<Piece> getPieces() {
		List<Piece> pieces = new List<Piece>();
		pieces.AddRange (player1.getPieces());
		pieces.AddRange (player2.getPieces());
		return pieces;
	}

	public static void placePiece(Piece p, Square s) {
		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
	}

	public static void movePiece(Piece p, Square s) {
		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece

		// check to see if we're good?
	}

	public static void moveHeldPiece(Square s) {
		placePiece (heldPiece, s);
		heldPiece = null;
	}

	public static void dropHeldPiece() {
		placePiece (heldPiece, heldPiece.getSquare ());
	}

	public static Piece getHeldPiece() {
		return heldPiece;
	}

	public static void setHeldPiece(Piece p) {
		heldPiece = p;
	}
}
