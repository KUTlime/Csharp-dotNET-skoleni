using System;
using NoteApp.Lib;

namespace NoteApp.Program
{
	/* Požadavky na knihovnu
	 * 1. ✔ Vložit poznámku.
	 * 2. ✔ Přepsat poznámku.
	 * 3. ✔ Připsat text k poznámce.
	 * 3. ✔ Smazat poznámku.
	 * 4. ✔ Najít poznámku.
	 * 5. ✔ Najít text v poznámkách.
	 * 6. ✔ Zobrazit všechny poznámky.
	 */
	internal static class Host
	{
		private static readonly Notebook Notebook = new Notebook();

		private static void Main(string[] args)
		{
			do
			{
				PrintMenu();
			} while (ExecuteMenuOption());
		}

		private static bool ExecuteMenuOption()
		{
			switch (GetMenuItem("Enter your choise:"))
			{
				case 0:
					return false;
				case 1:
					PrintAllNotes();
					break;
				case 2:
					EntryNewNote();
					break;
				case 3:
					FindNote();
					break;
				case 4:
					FindTextInNotes();
					break;
				case 5:
					AppendToNote();
					break;
				case 6:
					OverrideTextNote("Enter note id to override");
					break;
				case 7:
					DeleteNote("Enter note id to delete");
					break;
				default:
					Console.WriteLine("Unknown option. Please repeate enter.");
					break;
			}
			return true;
		}

		private static void FindTextInNotes()
		{
			Console.WriteLine("Please, entry a text to find in notes");
			string textToFind = Console.ReadLine();
			Notebook.FindNotesWithText(textToFind);
		}

		private static void AppendToNote()
		{
			Int32 id = GetMenuItem("Entry note id to append");
			Console.WriteLine("Entry text to append");
			string newNoteText = Notebook.GetNoteById(id) + Console.ReadLine();
			Notebook.DeleteNoteById(id);
			Notebook.CreateNewNote(newNoteText);
		}

		private static void OverrideTextNote(string entryOverrideText)
		{
			DeleteNote(entryOverrideText);
			EntryNewNote();
		}

		private static void DeleteNote(string entryDeleteText)
		{
			Notebook.DeleteNoteById(GetMenuItem(entryDeleteText));
		}

		private static void FindNote()
		{
			Console.WriteLine(Notebook.GetNoteById(GetMenuItem("Enter note Id to find")));
		}

		private static void PrintAllNotes()
		{
			Notebook.PrintAllNotes();
		}

		private static void EntryNewNote()
		{
			Console.WriteLine("Enter your note text:");
			Notebook.CreateNewNote(Console.ReadLine());
		}

		private static void PrintMenu()
		{
			Console.WriteLine("Press 0 exit");
			Console.WriteLine("Press 1 to print all notes");
			Console.WriteLine("Press 2 to enter note");
			Console.WriteLine("Press 3 to find note");
			Console.WriteLine("Press 4 to find in notes");
			Console.WriteLine("Press 5 to append to note");
			Console.WriteLine("Press 6 to override text note");
			Console.WriteLine("Press 7 to delete note");
		}

		private static Int32 GetMenuItem(string entryText)
		{
			Int32 result;
			do
			{
				Console.WriteLine(entryText);
			} while (!Int32.TryParse(Console.ReadLine(), out result));
			return result;
		}
	}
}
