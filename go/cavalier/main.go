package main

import (
	"fmt"
	"strconv"
	"time"
)

func main() {
	startTimer := time.Now()

	taillePlateau := 8
	plateau := genererPlateau(taillePlateau)

	move_x := make([]int, 0)
	move_y := make([]int, 0)
	move_x = append(move_x, 2, 1, -1, -2, -2, -1, 1, 2)
	move_y = append(move_y, 1, 2, 2, 1, -1, -2, -2, -1)
	// fmt.Println(move_x, move_y, plateau)
	// displayBoard(plateau)
	play(plateau, 0, 0, 1, taillePlateau)

	fmt.Println(time.Now().Sub(startTimer))
}

// Créer un plateau de x * x cases
func genererPlateau(largeur int) [][]int {
	plateau := make([][]int, 0)
	for i := 0; i < largeur; i++ {
		colonne := make([]int, largeur)
		for j := 0; j < largeur; j++ {
			colonne[j] = -1
		}
		plateau = append(plateau, colonne)
	}
	return plateau
}

func play(board [][]int, x int, y int, nbMoves int, taille int) bool {
	board[x][y] = nbMoves
	// fmt.Println("move : ", nbMoves)
	// displayBoard(board)
	moves := getMoves(board, x, y, taille)

	if len(moves) == 0 {
		win := nbMoves == taille*taille
		if !win {
			board[x][y] = -1
			return false
		} else {
			// displayBoard(board)
			// fmt.Println("VICTORY")
			return true
		}
	}

	for _, m := range moves {
		if play(board, m[0], m[1], nbMoves+1, taille) {
			return true
		}
	}

	board[x][y] = -1
	return false

}

func isMoveInvalid(board [][]int, x int, y int, n int) bool {
	return x < 0 || x >= n || y < 0 || y >= n || board[x][y] != -1
}

func getMoves(board [][]int, x int, y int, taillePlateau int) [][]int {
	move_x := make([]int, 0)
	move_y := make([]int, 0)
	move_x = append(move_x, 2, 1, -1, -2, -2, -1, 1, 2)
	move_y = append(move_y, 1, 2, 2, 1, -1, -2, -2, -1)

	moves := make([][]int, 0)

	for i := 0; i < len(move_x); i++ {
		tmp_x, tmp_y := move_x[i]+x, move_y[i]+y
		if !isMoveInvalid(board, tmp_x, tmp_y, taillePlateau) {
			move := make([]int, 0)
			move = append(move, tmp_x, tmp_y)
			moves = append(moves, move)
		}
	}
	return moves
}
func displayBoard(board [][]int) {
	for i := 0; i < len(board); i++ {
		s := ""
		for j := 0; j < len(board[i]); j++ {
			s += strconv.Itoa(board[i][j]) + " "
		}
		// fmt.Println(s)
	}
	// fmt.Println("-----")
}
