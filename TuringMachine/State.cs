using System;
namespace TuringMachine
{
	public class State
	{
		public enum OPCODE {NOP, LEFT, RIGHT, DELETE, W0, W1};
		public string r0;
		public OPCODE o0;
		public string r1;
		public OPCODE o1;
		public string stateName;
		public State(string r0, string r1, string name)
		{
			this.r0 = r0;
			this.r1 = r1;
			stateName = name;
		}
	}
}

