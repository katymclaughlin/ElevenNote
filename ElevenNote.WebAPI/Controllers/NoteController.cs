using Microsoft.AspNetCore.Mvc;
using ElevenNote.Services.Note;
using Microsoft.AspNetCore.Authorization;
using ElevenNote.Models.Note;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        // POST api/Note
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _noteService.CreateNoteAsync(request);
            if (response is not null)
                return Ok(response);

            return BadRequest("Could not create Note.");
        }   
        
        // GET api/Note
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }
    }
}