namespace NoteApp.Lib
{
    internal class Note
	{
		public override string ToString()
		{
			return Value;
		}
		public Note(string value)
		{
			Value = value ?? string.Empty;
		}
		public int Id { get; } = new Random().Next(1, 100);

		public string Value { get; set; }

		//public string Name { get; set; }

		//public DateTime Created { get; set; }
	}

	public class Notebook
	{
		Dictionary<Int32,Note> _notes = new Dictionary<int, Note>();
		public void CreateNewNote(string noteText)
		{
			var note = new Note(noteText);
			_notes[note.Id] = note;
		}

		public void PrintAllNotes()
		{
			PrintNotesToConsole(_notes.Values);
		}

		private void PrintNotesToConsole(IEnumerable<Note> notes)
		{
			foreach (var note in notes)
			{
				Console.WriteLine($"{note.Id} {note.Value}");
			}
		}

		public string GetNoteById(Int32 Id)
		{
			return _notes.TryGetValue(Id, out var note) ? note.Value : $"No note was found with id {Id}";
		}

		public bool DeleteNoteById(Int32 Id)
		{
			return _notes.Remove(Id);
		}

		public void FindNotesWithText(string searchText)
		{
			PrintNotesToConsole(_notes.Where(kvp => kvp.Value.Value.Contains(searchText)).Select(kvp => kvp.Value));
		}
	}
}
