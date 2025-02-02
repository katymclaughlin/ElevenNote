using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models.Note;

namespace ElevenNote.Services.Note
{
    public interface INoteService
    {
        Task<NoteListItem?> CreateNoteAsync(NoteCreate request);

        Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
        Task<NoteDetail?> GetNoteByIdAsync(int noteId);
        Task<bool> UpdateNoteAsync(NoteUpdate request);

        Task<bool> DeleteNoteAsync(int noteId);

    }
}