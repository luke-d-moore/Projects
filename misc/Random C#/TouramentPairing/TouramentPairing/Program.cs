using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouramentPairing
{
	class Program
	{
		static void Main(string[] args)
		{
			//values hard coded for testing the pairing system should pair from the top down for the first round
			//and then take into account the rule of not pairing to a previous played opponent for the rest of the rounds in the tournament
			Player player1 = new Player(1,"Alan",1800, new Dictionary<int, string>());
			Player player2 = new Player(2, "Bill", 1500, new Dictionary<int, string>());
			Player player3 = new Player(3, "Dave", 1549, new Dictionary<int, string>());
			Player player4 = new Player(4, "Ben", 1600, new Dictionary<int, string>());
			Player player5 = new Player(5, "Michael", 1659, new Dictionary<int, string>());
			Player player6 = new Player(6, "William", 1900, new Dictionary<int, string>());
			Player player7 = new Player(7, "blah", 1700, new Dictionary<int, string>());
			Player player8 = new Player(8, "8", 1450, new Dictionary<int, string>());
			Player player9 = new Player(9, "9", 1520, new Dictionary<int, string>());
			Player player10 = new Player(10, "10", 1390, new Dictionary<int, string>());
			Player player11 = new Player(11, "11", 1640, new Dictionary<int, string>());
			Player player12 = new Player(12, "12", 1750, new Dictionary<int, string>());
			Player player13 = new Player(13, "13", 2000, new Dictionary<int, string>());
			Player player14 = new Player(14, "14", 1100, new Dictionary<int, string>());
			List<Player> players = new List<Player>();
			players.Add(player1);
			players.Add(player2);
			players.Add(player3);
			players.Add(player4);
			players.Add(player5);
			players.Add(player6);
			players.Add(player7);
			players.Add(player8);
			players.Add(player9);
			players.Add(player10);
			players.Add(player11);
			players.Add(player12);
			players.Add(player13);
			players.Add(player14);

			//this is where the actual pairing code is being done
			int round = 1;
			bool endOfTournament = false;
			int maxRounds = Convert.ToInt32(Math.Round(players.Count / 2.0)-1);
			Console.WriteLine($"Maximum number of Rounds is {maxRounds}");
			while (endOfTournament != true)
			{

				RoundMatchup roundMatchup = new RoundMatchup();
				List<Player> newPlayers = new List<Player>();

				if (round <= maxRounds)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine("----------------------------");
					Console.WriteLine("----------------------------");

					Console.WriteLine($"Pairings for Round {round}");
					Console.WriteLine("Please Wait this may take a while...");

					if (players.Count % 2 != 0)
					{
						Player player = new Player(0, "Bye", 0, new Dictionary<int, string>());
						players.Add(player);
					}

					newPlayers = roundMatchup.ConvertToNewPlayerList(players);

					if (round == 1)
					{
						newPlayers = roundMatchup.FirstRound(newPlayers);
					}
					else
					{
						newPlayers = roundMatchup.NewRound(newPlayers, round);
					}

					players = roundMatchup.ConvertToNewPlayerList(newPlayers);
					endOfTournament = roundMatchup.NoMoreRounds(endOfTournament);
				}
				else
				{
					endOfTournament = true;
				}

				if (endOfTournament)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine("----------------------------");
					Console.WriteLine("----------------------------");

					Console.WriteLine("Final Standings");
					Console.WriteLine("----------------------------");
					Console.WriteLine($"The Average Rating of players in this Tournament was {players.Sum(o => o.playerRating) / players.Count}");
					int j = 1;

					foreach (Player player in players.OrderByDescending(o => o.wins).ThenByDescending(o => o.playerRating))
					{
						if (player.ID != 0)
						{
							Console.WriteLine("----------------------------");
							decimal averageOpponentRating = players.Where(o => player.previousOpponents.ContainsKey(o.ID)).Sum(o => o.playerRating) / player.previousOpponents.Count;
							Console.WriteLine($"Position {j} {player.playerName} {player.playerRating} with {player.wins} wins, {player.draws} draws and {player.losses} losses, Average Opponent Rating {averageOpponentRating}");
						}
						j++;
					}
					Console.WriteLine("----------------------------");
					Console.WriteLine("Tournament Finished press any key to close program");
					Console.ReadKey();
					endOfTournament = true;
				}
				round++;
			}
		}
	}
}
