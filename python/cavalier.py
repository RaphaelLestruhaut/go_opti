import time

start_time = time.time()


def isMoveInvalid(board, x, y):
    return x < 0 or x >= n or y < 0 or y >= n or board[x][y] != -1


def getMoves(board, x, y):
    moves = []

    for i in range(len(move_x)):
        tmp_x, tmp_y = move_x[i] + x, move_y[i] + y
        if not (isMoveInvalid(board, tmp_x, tmp_y)):
            moves.append([tmp_x, tmp_y])
    return moves


def displayBoard(board):
    for x in board:
        s = ""
        for y in x:
            str_to_add = str(y)
            s += str_to_add + " " * (3 - len(str_to_add))
        print(s)


def play(board, x, y, nbMoves):
    board[x][y] = nbMoves
    # print("move : ", nbMoves)
    # displayBoard(board)
    moves = getMoves(board, x, y)
    if len(moves) == 0:
        win = nbMoves == n ** 2
        if not win:
            board[x][y] = -1
            return False
        else:
            displayBoard(board)
            print("VICTORY")
            return True
    for m in moves:
        if play(board, m[0], m[1], nbMoves + 1):
            return True
    board[x][y] = -1
    return False


n = 8

move_x = [2, 1, -1, -2, -2, -1, 1, 2]
move_y = [1, 2, 2, 1, -1, -2, -2, -1]
# moves : +2 +1, +1 +2, -1 +2 ...

board = [[-1 for i in range(n)]for i in range(n)]

play(board, 0, 0, 1)

print("--- %s seconds ---" % (time.time() - start_time))