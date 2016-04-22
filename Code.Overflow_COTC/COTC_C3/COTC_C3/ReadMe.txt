Authors : 
	Nirdesh Kumar Saini
	Kumar Surni
Description : 
	This program takes 2 arguments at command line.
	Argument 1 : Size of string to be generated.
	Argument 2 : "Exclusion list of characters seperated by comma". Please provide the list in quotes to avoid runtime parameter issues.
	This program generates a random and unique alphanumeric character set everytime it is run. The random generator has been derived from Fisher–Yates shuffle algorithm.
	The program has been run with inputs from 2-7 length of strings and has been tested by generating around 100,000 times.
	Output file name has been hardcoded as "output.txt". Output will be appended to this file at every run.
	A batch file with the command "*.exe 7 "a,Z,e,7,D,O,w,8"" repeated 10000 times can be generated and run directly.

IDE and Compilation:
	This code was written in VS2013 and compiled at command line as well to test using parameters.