using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private static Player player1 = new Player(Color.white);
	private static Player player2 = new Player(Color.black);

	public GameObject square_prefab;
	public static List<Square> board = new List<Square>();
	private static Piece heldPiece;

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
	}

	public static void placePiece(Piece p, Square s) {
		p.getSquare().setPiece (null); // remove this piece from it's current square
		s.setPiece (p); // set it to a new one
		p.setSquare (s); // set square to piece
	}

	void OnMouseDown() {
		RaycastHit hitInfo;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo, 50f)) {
			Square square = hitInfo.collider.GetComponent<Square>();
			if (square != null) {

				if (heldPiece == null) {
					setHeldPiece(square.getPiece());
				}
				else {
					// try to move piece here
				}

			}
		}
	}

	void OnMouseUp() {
		RaycastHit hitInfo;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo, 50f)) {
			Square square = hitInfo.collider.GetComponent<Square>();
			if (square != null) {
				
				if (heldPiece == null) {

				}
				else {
					if (square.getPiece == heldPiece) {
						
					}
				}
				
			}
		}
		setHeldPiece (null);
	}

	public static void setHeldPiece(Piece p) {
		heldPiece = p;
	}
}
