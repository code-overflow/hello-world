Authors : 
	Nirdesh Kumar Saini
	Kumar Surni
Description : 
	This program takes 2 arguments at command line.
	Argument 1 : Input bin file name (only the name if the password file is in the same directory else the complete path).
	Argument 2 : Output bin file name (only the name if the password file is in the same directory else the complete path) that needs to be generated.
	This program simply reads byte data from input file and reallocates the bytes to new transposed location. The output bytes are written to output bin file provided as parameter.
	The output generated has been cross verified with output.bin provided as reference and it matches perfectly.
	The size of input bin file has been hardcoded as height = 4000 and width = 6000. Since these are not accepted as parameters from user.

IDE and Compilation:
	This code was written in VS2013 and compiled at command line as well to test using parameters.