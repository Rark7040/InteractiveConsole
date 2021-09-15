using System;
using System.Threading;


namespace interactive_console{
	class TerminalThread{
		protected Boolean is_killed = false;
		protected static string header = "\n[Console] ";

		public void start(){
			Thread thread = new Thread(() => {onRun();});
			thread.Start();
			Console.WriteLine(header+"start");
		}

		protected void onRun(){
			while(!this.is_killed){
				string line = Console.ReadLine();
				this.is_killed = handleCommand(line);
			}
			Console.WriteLine(header+"End Progress");
		}

		public static bool handleCommand(string command){
			
			switch(command){
				case "bye":
					return true;

				case "hello":
					Console.WriteLine(header+"Hello World!");
					return false;

				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(header+"sorry, "+command+" is not a command");
					Console.ForegroundColor = ConsoleColor.Gray;
					return false;
			}
		}
	}

}