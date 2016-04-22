Authors : 
	Nirdesh Kumar Saini
	Kumar Surni
Description : 
	This program takes 2 arguments at command line.
	Argument 1 : "PASSWORD String". Please provide the password in quotes.
	Argument 2 : Password dictionary file name (only the name if the password file is in the same directory else the complete path).
	This program parses the provided password once to determin the count of each of the Alphanumeric and special characters. Then it uses regular expression to determine Consequtive character count to differentiate Password strengths. At last uses the count of distinct special characters to finalize if its High or Strong password.
	After validating the password strength it looks for duplicate in password dictionary.

Possible Issues with code testing input:
	We have exhaustively tested this solution but there is a limitation when using automated batch file with multiple passwords. Sometimes the input password may contain string such as "AsEr%G234Der%&" the command prompt considers the part of the password %G234Der% as a variable name and makes it empty so this has to be taken into care during testing this code.
	Apart from this paarameter there is no known issue with the code.

IDE and Compilation:
	This code was written in VS2013 and compiled at command line as well to test using parameters.