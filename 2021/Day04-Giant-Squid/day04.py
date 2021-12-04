filename = 'day04.input'

def readlines(filename):
    with open(filename, 'r') as file:
        return [line.rstrip() for line in file.readlines()]


def getnumbers(s, sep=None):
    return [int(token) for token in s.split(sep)]


def partition(lst, n):
    return [lst[i:i+n] for i in range(0, len(lst), n)]


def getboards(lines):
    boards = [getnumbers(line) for line in lines]
    boards = [part[1:] for part in partition(boards, 6)]
    return boards


def readinput(filename):
    lines = readlines(filename)
    numbers = getnumbers(lines[0], ',')
    boards = getboards(lines[1:])
    return numbers, boards


def row_complete(board, i):
    for j in range(len(board[i])):
        if board[i][j] != -1:
            return False
    return True


def col_complete(board, j):
    for i in range(len(board[j])):
        if board[i][j] != -1:
            return False
    return True


def board_score(board, num):
    score = 0
    for i in range(len(board)):
        for j in range(len(board[i])):
            if (board[i][j] != -1):
                score += board[i][j]
    score *= num
    return score


def partone(numbers, boards):
    for num in numbers:
        for board in boards:
            for i in range(len(board)):
                for j in range(len(board[i])):
                    if board[i][j] == num:
                        board[i][j] = -1
                        if (row_complete(board, i) or col_complete(board, j)):
                            return board_score(board, num)



def parttwo(numbers, boards):
    marked_boards = set()
    for num in numbers:
        for bidx, board in enumerate(boards):
            if bidx in marked_boards:
                continue
            for i in range(len(board)):
                for j in range(len(board[i])):
                    if board[i][j] == num:
                        board[i][j] = -1
                        if (row_complete(board, i) or col_complete(board, j)):
                            marked_boards.add(bidx)
                            if len(marked_boards) == len(boards):
                                return board_score(board, num)


numbers, boards = readinput(filename)
print(partone(numbers, boards[:]))
print(parttwo(numbers, boards[:]))