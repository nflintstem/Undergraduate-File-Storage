import random # This is the only module you can import for this task


# Define guess_my_number 
def guess_my_number():
    # Set number of tries to 0
    number_of_guesses = 0
    # Introduce the game to the user
    print("Let's play a game. You're thinking of a number and I have to guess it...")
    # Ger values for lower end of range and higher end
    min_value = int(input("What is the smallest number it could be?: "))
    max_value = int(input("What is the largest number it could be?: "))
    # Make Guess
    guess = random.randint(min_value,max_value)
    print("My guess is ",str(guess))
    # Check if the guess was right
    response = input("Was I too high (H), too low (L), or Correct(C): ")
    # While he computer is not correct
    while response != "C":
        # If guess is too low...
        if response == "L":
            number_of_guesses += 1 # increment number of guesses
            min_value = guess+1 # set the lower value of the range to be the guess add 1
            # Make guess again, but this time with the new range
            guess = random.randint(min_value, max_value)
            print("My guess is ",str(guess))
            response = input("Was I too high (H), too low (L), or Correct(C): ")
        # If guess is too high...
        if response == "H":
            number_of_guesses += 1 # increment the number of guesses
            max_value = guess-1 # the upper value of the range is the guess subtracted by 1
            # Make guess again, but this time with the new range
            guess = random.randint(min_value, max_value)
            print("My guess is ",str(guess))
            response = input("Was I too high (H), too low (L), or Correct(C): ")
    # If guess is correct, print number of tries to get it
    print("Hooray! I got it. It took me ",str(number_of_guesses)," tries to get it!")
 


# Program main -- Do not change code below
guess_my_number()
    
