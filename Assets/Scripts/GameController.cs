using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private static Game game;

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
		game = new Game (Game.Type.STANDARD, square_prefab, 2, 8, 8);

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
		return game.getPieces();
	}

	public static void createPiece(Piece p, Square s, Player player) {
		game.createPiece(p, s, player);

		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
	}

	public static void movePiece(Piece p, Square s) {
		game.movePiece (p, s);
	}

	public static void moveHeldPiece(Square s) {
		movePiece (heldPiece, s);
		heldPiece = null;
	}

	public static void dropHeldPiece() {
		moveHeldPiece (heldPiece.getSquare ());
	}

	public static Piece getHeldPiece() {
		return heldPiece;
	}

	public static void setHeldPiece(Piece p) {
		heldPiece = p;
	}
}
