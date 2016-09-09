# TuringMachine
A turing machine simulator in c#
# Syntax
The first line is the "memory," the lines after that are state defining, and the last line concludes with the beginning state.<br />
To define a state, you need to define in the following format:<br />
name:state to be when memory is 0:state to be when memory is 1:operation to do if memory is 0:operation to do if memory is 1
# Operations
0 : Replace current memory block with 0 <br />
1 : Replace current memory block with 1 <br />
L : To go left a block<br />
R : To go right a block<br />
D : Delete the block<br />
N : No operation<br />
# Example
01000101010<br />
q0:q0:q0:R:0<br />
start:q0<br />

You should see "00000000000" printed in the stdout, that's because the code above basically just change all memories into 0.
# Ending
Whenever the program reached a state named "qH" or the instruction pointer is out of the memory. When the program ends, the simulator will print the current memory into stdout.
# Warnings
This simulator requires you to strictly type every word following it's format, not doing so will result in error or infinite loop with no outcomes.<br />
Remember to always check the logic of your code. Not doing so might ends up in a diaster.
# For the future
1. Making the input file and code file seperate
2. Syntax checking
