using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChessBoard
{
	public class ChessBoard
	{
		public String MakeBoard()
		{
			string colour = "White";
			string Board = string.Empty;
			foreach (int rank in Enumerable.Range(1, 8).OrderByDescending(x => x))
			{
				System.Text.StringBuilder BoardRow = new System.Text.StringBuilder();
				BoardRow.AppendFormat("<div id = divBoardRank_{0}>", rank);
				foreach (string file in Enumerable.Range('a', 8).Select(x => (char)x).Select(x => x.ToString()))
				{
					string square = file + rank;
					BoardRow.AppendFormat("<div class=\"inline\" id = {0} onclick=\"movepiece({1});\"style=\"Background-color:{2};\"></div>", square, square, colour);
					if (colour == "White" && file != "h")
					{
						colour = "Black";
					}
					else if (colour == "Black" && file != "h")
					{
						colour = "White";
					}
				}
				BoardRow.AppendFormat("</div>");
				Board += BoardRow.ToString();
			}

			return Board;
		}

	}
}