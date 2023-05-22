import random #for computer player

class Player(object):
    # Making a class for the Players - eventually instances called Player1 and Player2 will be made
    def __init__(self, counter):
        self.counter = counter #stores the player's counter
        self.positions = [] #stores positions players place counters
        self.hasWon = False #status of game

        
    def plot(self,board):
        #function that PLOTS points
        pos=0
        while (board[pos-1] != " ") or ((pos<1) or (pos>9)):
            try:
                pos = int(input("Which position 1-9, should your counter go? ")) #ask for counter position
            except ValueError:
                print("That is not a number. Let's try this again.") # calls user out if they don't input an integer 1-9
                self.plot(board)
        update_board(board,pos,self.counter,"Plot") #updates board
        self.positions.append(pos) #appends position to the player's list
        self.WinCheck(self.counter) #checks for a winning set of positions

    def move(self,board):
        pos=0
        while (board[pos-1] == " ") or ((pos<1) or (pos>9)):
            try:
                pos = int(input("Which counter do you wish to move? ")) #asks which counter to move
            except ValueError:
                print("That is not a number. Let's try again") #calls user out for not inputting integer, as before
                self.move(board)
            except pos not in self.positions:
                print("That is not your counter. Try again") # calls user out for trying to move a counter that isn't theirs
                self.move(board)
            except board[pos-1] == " ":
                print("That is an empty space! Please try again") # calls user out for trying to move an empty space
                self.move(board)
        self.positions.append(update_board(board,pos,self.counter,"Move")) #updates board AND appends the new position
        self.positions.remove(pos)
        self.WinCheck(self.counter)

    def WinCheck(self,counter):
        #checks for possible wins
        horizontal_soln = [[1, 2, 3], [4, 5, 6], [7, 8, 9]] #3D array of horizontal wins
        vertical_soln = [[1, 4, 7], [2, 5, 8], [3, 6, 9]] #3D array of vertical wins
        diagonal_soln = [[1, 5, 9], [3, 5, 7]] #3D array of diagonal wins
        #the following code
        #1. checks the members of each array
        #2. checks the members of the individual array in each 3D arrahy
        #3. if the player has counters in positions in the array, congratulate player and 
        for i in horizontal_soln:
            if all(j in self.positions for j in i):
                print("Player ",counter," has won horizontally! Congratulations")
                self.hasWon= True
        for i in vertical_soln:
            if all(j in self.positions for j in i):
                print("Player ",counter," has won vertically! Congratulations")
                self.hasWon=True
        for i in diagonal_soln:
            if all(j in self.positions for j in i):
                print("Player ",counter," has won diagonally! Congratulations")
                self.hasWon=True

    def strategy(self,board):
        #this procedure determines the player's strategy
        TurnChoice = input("Do you wish to move an existing piece to an empty place, or plot a new piece? (M/P) ")
        if TurnChoice.upper()=='P':
            self.plot(board) #allows user to plot board
        elif TurnChoice.upper()=='M':
            if board != [" "," "," "," "," "," "," "," "," "]:
                self.move(board) #allows user to move board if the board isn't empty and they have points
            elif self.positions==[]:
                print("Let's plot points first!") #calls user out if they try to move a point before placing one
                self.plot(board)
            else:
                print("Let's plot points first!") #calls user out for trying to move a point on an empty board
                self.plot(board)
        else:
            print("The only options are M or P (not case sensitive). Please pick one of those two")
            self.strategy(board)
#                                                                       END OF PLAYER CLASS

# Computer is a child class of Player, as the Computer plays differently to the Human but doesn't warrant its own class as it is still playing.
class Computer(Player):
    def __init__(self):
        Player.__init__(self,"o") #force the counter of the computer to be "o"

    def plot(self,board,opponent): #redefine plot for computer
        CompPosition = random.randint(1,9)
        while CompPosition in opponent.positions:
            CompPosition = random.randint(1,9)
        update_board(board,CompPosition,self.counter,"Plot")
        self.positions.append(CompPosition)
        self.WinCheck(self.counter)
#                                                                      END OF COMPUTER CLASS

# The following function print the current board to the command window.
def print_board(board):
    print()
    print(board[:3])
    print(board[3:6])
    print(board[6:])
    
# This function takes the existing board, position input from player, marker type (either x or o) and returns the updated board based on the arguments.
def draw_board(board,position,marker):
    board[position-1] = marker
    return board

def update_board(board,pos,counter,BoardOp):
    #this function has 2 options - to plot or to move a point
    if BoardOp=="Plot":
        #This plots a new point on the board. This is taken from the skeleton code, and is not original.
        draw_board(board,pos,counter)
        print_board(board)
    if BoardOp=="Move":
        #This moves a point on the board to an empty plot. This part of the function is my own work
        Movepos=0
        while (board[pos-1] != " ") and ((Movepos<1) or (Movepos>9)): #will loop until either an empty plot is decided on and the position given isn't 1-9
            try:
                Movepos = int(input("Which position 1-9, should your counter move to? "))
            except ValueError:
                print("That is not a number. Let's try this again.") #calls the user out for not inputting a number
                update_board(board,pos,counter,"Move")
            except board[Movepos-1] != " ": #calls the user out for not inputting an empty plot
                print("That is not empty. Try Again")
                update_board(board,pos,counter,"Move")
        board[pos-1] = " " #makes the board's position
        draw_board(board,Movepos,counter)
        print_board(board)
        return Movepos #if the player decides to move, return the position so it can be appended
        
        
def HumanPlayer():
    counter=input("What will be your counter: X or O? ") #player decides on counter
    if counter.lower()=='x':
        print("Your friend will be player O")
        Player1=Player(counter.lower()) #crates player object where the player 1 is whatever counter they pick
        Player2=Player('o') #uses the opposite one for player 2
    if counter.lower()=='o':
        #does same as previous chunk of code, but inverted
        print("Your friend will be player X")
        Player1=Player(counter.lower())
        Player2=Player('x')
    while (Player1.hasWon != True) or (Player2.hasWon != True):
        try: #tries below code if a tie isn't in place
            print("It is now Player 1's turn")
            Player1.strategy(board) #calls procedure to allow player to decide whether to move counter or plot new counter
            if Player1.hasWon != False:
                return #goes back to main program if player has won
            print("It is now player 2's turn")
            #does same as above for player 2
            Player2.strategy(board)
            if Player2.hasWon != False:
                return
            tiecheck = len(Player1.positions)+len(Player2.positions) #checks to see if there is a tie
        except tiecheck==9: #if a tie has occured
            print("There is a tie. Good game to you both") 
            return

def CompPlayer():
    ComPlayer=Computer()
    Human=Player('x')
    while (Human.hasWon != True) or (ComPlayer.hasWon != True):
        try:
            Human.strategy(board) #Human goes first as it is player X
            if Human.hasWon==True:
                return
            ComPlayer.plot(board,Human)
            if ComPlayer.hasWon==True:
                return
            tiecheck=len(ComPlayer.positions)+len(Human.positions)
        except tiecheck==9:
            print("There is a tie. Good game to you both")
            return
    

# Program main starts from here,
board = [" "," "," "," "," "," "," "," "," "]
position = ['1','2','3','4','5','6','7','8','9'] #board and positions set
print_board(board) #board printed
print_board(position) #positions printed - done only once
print("Hello there! You have two options: play with another Human (H), or play with the Computer (C)") #option to play with a human or computer
option=input("So. What's it gonna be? ") 
if option.upper()=='H': #if human picked
    HumanPlayer() #procedure for playing with a human
    print("Thank You for Playing!")
if option.upper()=='C':
    print("Hello. I'm the Computer and I want to play with you! I'll be O and you'll be X")
    CompPlayer() #Similar procedure for the computer player
    print("Thank you for playing with me.")
