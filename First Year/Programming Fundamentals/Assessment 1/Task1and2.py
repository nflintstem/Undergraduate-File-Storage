# Import random
import random

def sch_register():
    full_name = input("Please enter your full name: ")
    # Code to extract the first name
    i = 0
    for i in range(len(full_name)):
        if full_name[i]==' ':
            # Get first name from string, then get last name ready for later
            first_name = full_name[:i]
            last_name = full_name[i+1:]
            first_letter = full_name[0]
            break
    # Say Hello xx
    print("Hello ",first_name)
    # Ask the user to enter their age
    student_age = int(input("Please enter your age: "))
    # Validate their age for registration
    if student_age < 11:
	    print("Sorry, you are too young to be registered in the school")
    elif student_age > 18:
	    print ("Sorry, you are too old to be registered in the school")
    else:
            # Input date of birth
	    DoB = input("Enter your date of birth: ")
	    year_of_birth = DoB[6:]
    # Output year of birth
    print("You were born in the year ",year_of_birth)
    # Concatenate strings for email
    email_num = random.randint(10,99)
    email_num = str(email_num)
    email = first_letter+last_name+year_of_birth+email_num+"@school.ac.uk"
    return email
    
def pwd_validate(pwd):
    # Define pecial characters
    SpecialChars = ['%','$','£','@','>','<','?']
    # Check variables for special characters, numbers etc set to False
    special_check = False
    number_check = False
    upper_check = False
    lower_check = False
    # Validate the length of the password - nothing else gets checked if false
    if len(pwd) != 12:
        print("Invalid - Your password should be 12 characters long")
        pwd = input("\nPlease enter your new password, it should be 12 characters long: ")
        print("Your new password is: ",pwd_validate(pwd))
    # Check if password is strong
    else:
        # Goes through each character in the password
        i = 0
        while i != len(pwd):
            pwdchar = pwd[i]
            # Checks if the character is upper case
            if pwdchar.isupper:
                upper_check = True
            # Checks if the character is lower case
            if pwdchar.islower:
                lower_check = True
            # Checks if the character is a number
            if pwdchar.isdigit:
                number_check = True
            # Checks if the character is a special character
            if pwdchar in SpecialChars:
                special_check = True
            # Increment I
            i = i+1
        # Returns the password if the password is strong enough     
        if (upper_check == True) and (lower_check == True) and (number_check == True) and (special_check == True):
            return pwd
        else:
            # Calls user out on what is making password weak
            if not upper_check:
                print("Invalid - Your password should have upper case letters")
            if not lower_check:
                print("Invalid - Your password should have lower case letters")
            if not number_check:
                print("Invald - Your password should have numbers")
            if not special_check:
                print("Invalid - Your password should havea  special character")
                print(SpecialChars)
            # Make user re-enter their password
            pwd = input("\nPlease enter your new password, it should be 12 characters long: ")
            print("Your new password is: ",pwd_validate(pwd))

# Program main --- Do not change the code below but feel free to comment out 
# sections of code when working on individual functions. 
# Calling Task 1 function
email = sch_register()
print("Your new school email is: ", email)

# Calling Task 2 function
pwd = input("\nPlease enter your new password, it should be 12 characters long: ")
print("Your new password is: ")
print(pwd_validate(pwd))
