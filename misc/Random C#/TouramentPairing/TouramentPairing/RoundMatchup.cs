using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouramentPairing
{
	class RoundMatchup
	{
		public List<Player> FirstRound(List<Player> players)
		{
			List<int> selectedPlayers = new List<int>();
			Dictionary<int, int> pairings = new Dictionary<int, int>();
			SetColours(players);
			while (selectedPlayers.Count < players.Count)
			{
				Player currentTopPlayer = players.OrderByDescending(o => o.playerRating).Where(o => !selectedPlayers.Contains(o.ID)).First();
				selectedPlayers.Add(currentTopPlayer.ID);

				Player currentopponentPlayer = players.OrderByDescending(o => o.playerRating).Where(o => !selectedPlayers.Contains(o.ID)).First();
				selectedPlayers.Add(currentopponentPlayer.ID);

				currentTopPlayer.previousOpponents.Add(currentopponentPlayer.ID, currentopponentPlayer.playerName);
				currentopponentPlayer.previousOpponents.Add(currentTopPlayer.ID, currentTopPlayer.playerName);
				pairings.Add(currentTopPlayer.ID, currentopponentPlayer.ID);
			}

			DisplayPairings(pairings, players);

			DisplayInstructions(1);

			GetResults(pairings, players);

			return players;
		}

		public List<Player> NewRound(List<Player> players, int round)
		{
			List<int> selectedPlayers = new List<int>();
			Dictionary<int, int> pairings = new Dictionary<int, int>();
			List<Player> whitePlayers = new List<Player>();
			List<Player> blackPlayers = new List<Player>();
			bool validMatchup = false;

			SwapColours(players, blackPlayers, whitePlayers);

			while (!validMatchup) {
				validMatchup = ValidMatchup(selectedPlayers, whitePlayers, pairings, players);
				if (validMatchup)
				{
					foreach (KeyValuePair<int, int> playersPairing in pairings)
					{
						Player currentWhitePlayer = new Player();
						Player currentBlackPlayer = new Player();
						currentWhitePlayer = players.Where(o => o.ID == playersPairing.Key).First();
						currentBlackPlayer = players.Where(o => o.ID == playersPairing.Value).First();
						currentWhitePlayer.previousOpponents.Add(currentBlackPlayer.ID, currentBlackPlayer.playerName);
						currentBlackPlayer.previousOpponents.Add(currentWhitePlayer.ID, currentWhitePlayer.playerName);
					}
				}
			}
			DisplayPairings(pairings, players);

			DisplayInstructions(round);

			GetResults(pairings, players);

			UpdatedResults(pairings, players);

			return players;
		}

		private List<Player> SetColours(List<Player> players)
		{
			string colour = "White";
			foreach (Player player in players.OrderByDescending(o => o.playerRating))
			{
				player.colour = colour;
				if (colour == "White")
				{
					colour = "Black";
				}
				else
				{
					colour = "White";
				}
			}
			return players;
		}

		private void SwapColours(List<Player> players, List<Player> blackPlayers, List<Player> whitePlayers)
		{
			foreach (Player player in players)
			{
				Player newPlayer = new Player(player.ID, player.playerName, player.playerRating, player.previousOpponents, player.wins, player.colour, player.draws, player.losses);
				if (newPlayer.colour == "White")
				{
					newPlayer.colour = "Black";
					blackPlayers.Add(newPlayer);
					player.colour = "Black";
				}
				else
				{
					newPlayer.colour = "White";
					whitePlayers.Add(newPlayer);
					player.colour = "White";
				}
			}
		}

		private bool ValidMatchup(List<int> selectedPlayers, List<Player> whitePlayers, Dictionary<int, int> pairings, List<Player> players)
		{
			List<List<Player>> possiblePlayersLists = new List<List<Player>>();
			List<List<Player>> prePossiblePlayersLists = new List<List<Player>>();
			try
			{
				foreach (Player player in whitePlayers)
				{
					List<Player> possibleOpponents = new List<Player>();
					possibleOpponents.AddRange(players.Where(o => !player.previousOpponents.ContainsKey(o.ID) && o.colour != player.colour));
					possiblePlayersLists.Add(possibleOpponents);
					prePossiblePlayersLists.Add(possibleOpponents);
				}

				int i = 0;
				List<int> preSelectedPlayers = new List<int>();
				Dictionary<int, int> prePairings = new Dictionary<int, int>();
				foreach (Player player in whitePlayers)
				{
					if (!preSelectedPlayers.Contains(player.ID))
					{
						preSelectedPlayers.Add(player.ID);

						List<Player> filteredPossiblePlayers = new List<Player>();
						Player opposition = new Player();
						Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
						filteredPossiblePlayers.AddRange(possiblePlayersLists[i].Where(o => !preSelectedPlayers.Contains(o.ID) && !player.previousOpponents.ContainsKey(o.ID)));
						opposition = filteredPossiblePlayers[randomNumberGenerator.Next(0, filteredPossiblePlayers.Count - 1)];
						preSelectedPlayers.Add(opposition.ID);

						foreach (List<Player> playerList in prePossiblePlayersLists)
						{
							List<Player> playersToBeRemoved = new List<Player>();
							playersToBeRemoved.AddRange(players.Where(o => preSelectedPlayers.Contains(o.ID)));
							playerList.RemoveAll(o => playersToBeRemoved.Contains(o));
						}
						prePairings.Add(player.ID, opposition.ID);
					}
					i++;
				}

				foreach (KeyValuePair<int, int> prepairing in prePairings)
				{
					pairings.Add(prepairing.Key, prepairing.Value);
				}

				selectedPlayers.AddRange(preSelectedPlayers);
				if (pairings.Count == (players.Count / 2.0))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}

		}

		private void DisplayPairings(Dictionary<int, int> pairings, List<Player> players)
		{
			int i = 1;
			foreach (KeyValuePair<int, int> pairing in pairings)
			{
				Console.WriteLine("----------------------------");
				Console.WriteLine($"Pairing {i} is; White : {players.Where(o => o.ID == pairing.Key).First().playerName} {players.Where(o => o.ID == pairing.Key).First().playerRating} with {players.Where(o => o.ID == pairing.Key).First().wins} Wins, {players.Where(o => o.ID == pairing.Key).First().draws} draws and {players.Where(o => o.ID == pairing.Key).First().losses} losses vs. Black : {players.Where(o => o.ID == pairing.Value).First().playerName} {players.Where(o => o.ID == pairing.Value).First().playerRating} with {players.Where(o => o.ID == pairing.Value).First().wins} Wins, {players.Where(o => o.ID == pairing.Value).First().draws} draws and {players.Where(o => o.ID == pairing.Value).First().losses} losses");
				i++;
			}
		}

		private void DisplayInstructions(int round)
		{
			Console.WriteLine("----------------------------");
			Console.WriteLine("Please Press Enter to begin Entering Results");
			//Console.ReadKey();
			Console.WriteLine("----------------------------");
			Console.WriteLine($"Enter Results for Round {round} relative to the player playing with White 1 for a win, 0.5 for a draw and 0 for a loss.");
		}

		private void GetResults(Dictionary<int, int> pairings, List<Player> players)
		{
			int i = 1;
			foreach (KeyValuePair<int, int> pairing in pairings)
			{
				string result = "";
				if (pairing.Key != 0 && pairing.Value != 0)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine($"Enter result for Pairing {i}; White : {players.Where(o => o.ID == pairing.Key).First().playerName} {players.Where(o => o.ID == pairing.Key).First().playerRating} with {players.Where(o => o.ID == pairing.Key).First().wins} Wins vs. Black : {players.Where(o => o.ID == pairing.Value).First().playerName} {players.Where(o => o.ID == pairing.Value).First().playerRating} with {players.Where(o => o.ID == pairing.Value).First().wins} Wins");
					//result = Console.ReadLine().ToString();
					result = "1";
				}
				else
				{
					if (pairing.Value == 0)
					{
						result = "1";
					}
					else
					{
						result = "0";
					}
				}
				if (result == "1")
				{
					players.Where(o => o.ID == pairing.Key).First().wins += 1;
					players.Where(o => o.ID == pairing.Value).First().losses += 1;
				}
				if (result == "0")
				{
					players.Where(o => o.ID == pairing.Key).First().losses += 1;
					players.Where(o => o.ID == pairing.Value).First().wins += 1;
				}
				if (result == "0.5")
				{
					players.Where(o => o.ID == pairing.Key).First().draws += 1;
					players.Where(o => o.ID == pairing.Value).First().draws += 1;
				}
				i++;
			}
		}
		private void UpdatedResults(Dictionary<int, int> pairings, List<Player> players)
		{
			int i = 1;
			Console.WriteLine("----------------------------");
			Console.WriteLine("Updated Pairings After Results were Entered");
			foreach (KeyValuePair<int, int> pairing in pairings)
			{
				if (pairing.Key != 0 && pairing.Value != 0)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine($"Result for Pairing {i}; White : {players.Where(o => o.ID == pairing.Key).First().playerName} {players.Where(o => o.ID == pairing.Key).First().playerRating} with {players.Where(o => o.ID == pairing.Key).First().wins} Wins vs. Black : {players.Where(o => o.ID == pairing.Value).First().playerName} {players.Where(o => o.ID == pairing.Value).First().playerRating} with {players.Where(o => o.ID == pairing.Value).First().wins} Wins");
					i++;
				}
			}
		}

		public List<Player> ConvertToNewPlayerList(List<Player> players)
		{
			List<Player> newPlayers = new List<Player>();
			foreach (Player player in players)
			{
				Player newPlayer = new Player(player.ID, player.playerName, player.playerRating, player.previousOpponents, player.wins, player.colour, player.draws, player.losses);
				newPlayers.Add(newPlayer);
			}
			return newPlayers;
		}

		public bool NoMoreRounds(bool endOfTournament)
		{
			if (endOfTournament != true)
			{
				Console.WriteLine("----------------------------");
				Console.WriteLine("would you like another Round? (Y/N)");
				string nextRound = "";
				//nextRound = Console.ReadLine().ToString();
				nextRound = "Y";
				if (nextRound == "Y")
				{
					endOfTournament = false;
				}
				else
				{
					endOfTournament = true;
				}
			}
			else
			{
				endOfTournament = true;
			}
			return endOfTournament;
		}

	}
}
