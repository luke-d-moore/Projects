using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyChessBoard
{
	public partial class HomePage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack != true)
			{
				Setup();
			}
		}
		void Setup()
		{
			var ChessBoard = new ChessBoard();
			String EmptyBoardString = ChessBoard.MakeBoard();
			divChessBoard.InnerHtml = EmptyBoardString;
			EmptyBoard.Value = EmptyBoardString;
			var ChessPiece = new ChessPiece();
			String StartingChessPieces = ChessPiece.GetStartingChessPieces();
			StartChessPieces.Value = StartingChessPieces;
			CurrentChessPieces.Value = StartingChessPieces;
		}

	}
}