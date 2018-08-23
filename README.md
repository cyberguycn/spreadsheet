It's console program coding with C# language, it will create a basic spreadsheet and allow user to perform some basic spresheet operation as below.

Command   		Description

C w h     		Should create a new spread sheet of width w and height h (i.e. the spreadsheet can hold w * h amount of cells).

N x1 y1 v1  		Should insert a number in specified cell (x1,y1)

S x1 y1 x2 y2 x3 y3 	Should perform sum on top of all cells from x1 y1 to x2 y2 and store the result in x3 y3

Q			Should quit the program.

?			Help


as it's a console program, need to consider the format of command, and verify user's input if it's in correct format
and if parameter is valid for processing. the program also need to provide the help feature for easy reference.
for the parameter used for locate cell position, it must be positive integer, and the cell value can be any number but the lenght cannot exceed 3 characters.
