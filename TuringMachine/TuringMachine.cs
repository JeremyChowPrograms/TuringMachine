using System;
using System.IO;
using System.Collections.Generic;

namespace TuringMachine
{
	class TuringMachine
	{
		private static List<bool> paper = new List<bool>();
		private static List<State> states = new List<State>();
		private static State currentState;
		public static void Main(string[] args)
		{
			if (args.Length != 1 && args.Length != 2)
			{
				Console.WriteLine("Turing Machine Interpreter\nBy Jeremy Chow");
			}
			else {
				if (File.Exists(args[0]))
				{
					string input = File.ReadAllText(args[0]);
					string[] lines = input.Split('\n');
					string tape = lines[0];
					foreach (char c in tape)
					{
						if (c == '0')
							paper.Add(false);
						else
							paper.Add(true);
					}
					int i = 1;
					while (!lines[i].StartsWith("start:"))
					{
						string cl = lines[i];
						string[] argus = cl.Split(':');
						State cs = new State(argus[1], argus[2], argus[0]);
						cs.o0 = getOpcode(argus[3].ToCharArray()[0]);
						cs.o1 = getOpcode(argus[4].ToCharArray()[0]);
						states.Add(cs);
						i++;
					}
					string startSeq = lines[i].Split(':')[1];
					currentState = getState(startSeq);
					int ip = 0;
					while (currentState.stateName != "qH" && ip < paper.Count)
					{
						//Console.WriteLine(ip+" "+paper[ip]);
						bool ep = paper[ip];
						State.OPCODE opc;
						if (ep)
							opc = currentState.o1;
						else
							opc = currentState.o0;
						switch (opc)
						{
							case State.OPCODE.DELETE:
								paper.RemoveAt(ip);
								if (ip == paper.Count)
									ip--;
								break;
							case State.OPCODE.LEFT:
								if (ip != 0)
									ip--;
								break;
							case State.OPCODE.RIGHT:
								ip++;
								break;
							case State.OPCODE.W0:
								paper[ip] = false;
								break;
							case State.OPCODE.W1:
								paper[ip] = true;
								break;
						}
						if (ep)
							currentState = getState(currentState.r1);
						else
							currentState = getState(currentState.r0);
					}
					foreach (bool b in paper)
					{
						if (b)
							Console.Write(1);
						else
							Console.Write(0);
					}
					Console.WriteLine();
				}
				else {
					Console.WriteLine("Sorry, file \"" + args[0] + "\" doesn't exist");
				}
			}
		}
		private static State getState(string stateName)
		{
			foreach (State s in states)
			{
				if (s.stateName == stateName)
					return s;
			}
			if (stateName == "qH")
				return new State("", "", "qH");
			throw new IndexOutOfRangeException();
		}
		private static State.OPCODE getOpcode(char op)
		{
			switch (op)
			{
				case 'R':
					return State.OPCODE.RIGHT;
				case 'L':
					return State.OPCODE.LEFT;
				case 'N':
					return State.OPCODE.NOP;
				case 'D':
					return State.OPCODE.DELETE;
				case '1':
					return State.OPCODE.W1;
				case '0':
					return State.OPCODE.W0;
				default:
					return State.OPCODE.NOP;
			}
		}
	}
}
