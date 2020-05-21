using Microsoft.AspNet.Identity;
using MyNote.Api.DTO;
using MyNote.Api.Extensions;
using MyNote.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MyNote.Api.Controllers
{
    [Authorize]
    public class NotesController : BaseApiController
    {
        public string UserId => User.Identity.GetUserId();
        [HttpGet]
        public IEnumerable<NoteDto> List()
        {
            return db.Notes.Where(x => x.AuthorId == UserId).ToList().Select(x => x.ToNoteDto());
        }

        [HttpGet]
        public IHttpActionResult GetNote(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var note = db.Notes.FirstOrDefault(x => x.Id == id && x.AuthorId == UserId);

            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public IHttpActionResult New(NewNoteDto nDto)
        {
            if (nDto == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var note = (new Note
                {
                    AuthorId = User.Identity.GetUserId(),
                    Title = nDto.Title,
                    Content = nDto.Content,
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now
                }); ;
                db.Notes.Add(note);
                db.SaveChanges();

                //Todo Created Yap
                return CreatedAtRoute("DefaultApi", new { action = "GetNote", id = note.Id }, note.ToNoteDto());
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult Update(int? id, UpdateNoteDto uDto)
        {
            if (id == null || id != uDto.Id || id != null)
            {
                return BadRequest();
            }
            var note = db.Notes.FirstOrDefault(x => x.Id == id && x.AuthorId == UserId);

            if (note == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                note.Title = uDto.Title;
                note.Content = uDto.Content;
                note.ModificationTime = DateTime.Now;
                db.SaveChanges();
                return Ok(note.ToNoteDto());
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var note = db.Notes.FirstOrDefault(x => x.Id == id && x.AuthorId == UserId);

            if (note == null)
            {
                return NotFound();
            }
            db.Notes.Remove(note);
            db.SaveChanges();
            return Ok(note.ToNoteDto());
        }

    }
}
