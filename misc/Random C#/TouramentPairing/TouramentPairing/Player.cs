using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouramentPairing
{
	class Player
	{
		private int _ID;
		private string _playerName;
		private int _playerRating;
		private int _wins;
		private string _colour;
		private Dictionary<int, string> _previousOpponents;
		private int _draws;
		private int _losses;

		public int ID
		{
			get
			{
				return _ID;
			}
		}

		public string playerName
		{
			get
			{
				return _playerName;
			}
		}

		public int playerRating
		{
			get
			{
				return _playerRating;
			}
		}

		public Dictionary<int, string> previousOpponents
		{
			get
			{
				return _previousOpponents;
			}
			set
			{
				_previousOpponents = value;
			}
		}
		public int wins
		{
			get
			{
				return _wins;
			}
			set
			{
				_wins = value;
			}
		}
		public int draws
		{
			get
			{
				return _draws;
			}
			set
			{
				_draws = value;
			}
		}
		public int losses
		{
			get
			{
				return _losses;
			}
			set
			{
				_losses = value;
			}
		}
		public string colour
		{
			get
			{
				return _colour;
			}
			set
			{
				_colour = value;
			}
		}
		public Player()
		{

		}
		public Player(int ID, string playerName, int playerRating, Dictionary<int, string> previousOpponents)
		{
			_ID = ID;
			_playerName = playerName;
			_playerRating = playerRating;
			_previousOpponents = previousOpponents;
		}
		public Player(int ID, string playerName, int playerRating, Dictionary<int, string> previousOpponents, int wins, string colour, int draws, int losses)
		{
			_ID = ID;
			_playerName = playerName;
			_playerRating = playerRating;
			_previousOpponents = previousOpponents;
			_wins = wins;
			_colour = colour;
			_draws = draws;
			_losses = losses;
		}
	}
}
