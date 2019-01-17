using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVelhaConsoleApp {
	
	/// <summary>
	/// Jogo da velha Com console App
	/// Demo de Matrizes
	/// Autor Alexander Silva
	/// </summary>
	class Program {
		static void Main(string[] args) {
			//Matriz do Jogo da Velha
			const int plays = 9;
			char[,] matriz = new char[3, 3];
			char player = 'X'; //X sempre começa

			for (int played = 0; played < plays; played++) {
				Console.WriteLine("Digite a linha para player " + player);
				int line = int.Parse(Console.ReadLine());

				Console.WriteLine("Digite a coluna para player " + player);
				int column = int.Parse(Console.ReadLine());

				//Marca a posição escolhida
				matriz[line, column] = player;

				//Alterna o player atual
				if (player == 'X')
					player = 'O';
				else
					player = 'X';

				if (VerifyWinner(matriz) != '\0') {
					Console.WriteLine("Jogador " + VerifyWinner(matriz) + " ganhou!");
					break;
				}
			}
		}

		static char VerifyWinner(char[,] matriz) {
			//Verifico as linhas
			for (int line = 0; line < 3; line++) {
				char player = matriz[line, 0];
				bool winner = true;
				for (int column = 0; column < 3; column++) {
					if (matriz[line, column] != player) {
						winner = false;
						break;
					}
				}
				if (winner)
					return player;
			}

			//Verifica colunas
			for (int column = 0; column < 3; column++) {
				char player = matriz[0, column];
				bool winner = true;
				for (int line = 0; line < 3; line++) {
					if (matriz[line, column] != player) {
						winner = false;
						break;
					}
				}
				if (winner)
					return player;
			}

			//Verifica a Diagonal Principal
			char generalPlayer = matriz[0, 0];
			bool generalWinner = true;
			for (int i = 0; i < 3; i++) {
				if (matriz[i, i] != generalPlayer) {
					generalWinner = false;
					break;
				}
			}
			if (generalWinner)
				return generalPlayer;

			//Verifica a outra Diagonal 
			if (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
				return matriz[0, 2];

			bool old = true;
			for (int line = 0; line < 3; line++) {
				for (int column = 0; column < 3; column++) {
					if (matriz[line, column] == '\0'
						|| matriz[line, column] == ' ') {
						old = false;
						break;
					}
				}
			}
			if (old)
				return 'V';

			return '0'; //Ninguém ganhou mas o jogo ainda não acabou
		}
	}

}
