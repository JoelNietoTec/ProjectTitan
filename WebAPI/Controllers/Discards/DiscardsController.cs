using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Discards;

namespace WebAPI.Controllers.Discards
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscardsController : ControllerBase
    {
        private readonly DiscardsContext _context;

        public DiscardsController(DiscardsContext context)
        {
            _context = context;
        }


        [HttpGet("participant/{participantId}")]
        public IEnumerable<ParticipantDiscard> GetDiscards([FromRoute] int participantId)
        {
            return _context.ParticipantDiscards
                .Where(x => x.ParticipantId == participantId)
                .Include(x => x.Participant)
                .Include(x => x.SanctionList);
        }


        [HttpPost("participant/{participantId}")]
        public async Task<IActionResult> RunDiscard([FromRoute] int participantId)
        {
            var participant = await _context.Participants.FindAsync(participantId);
            List<ParticipantDiscard> discards = new List<ParticipantDiscard>();

            if (participant == null)
            {
                return BadRequest();
            }

            var lists = _context.SanctionLists.Where(x => x.ActiveSearch == true);

            foreach (var list in lists)
            {
                bool isMatch = false;
                var items = _context.SanctionedItems.Where(x => x.ListId.Equals(list.Id)).ToList();
                foreach (var item in items)
                {
                    int matchCount = 0;
                    var term = item.FullTerm.ToLower();

                    if (term.IndexOf(IsNull(participant.FirstName.ToLower())) != -1 && IsNull(participant.FirstName.ToLower()).Length > 1)
                    {
                        matchCount++;
                    }

                    if (term.IndexOf(IsNull(participant.SecondName.ToLower())) != -1 && IsNull(participant.SecondName.ToLower()).Length > 1)
                    {
                        matchCount++;
                    }

                    if (term.IndexOf(IsNull(participant.ThirdName.ToLower())) != -1 && IsNull(participant.ThirdName.ToLower()).Length > 1)
                    {
                        matchCount++;
                    }

                    if (matchCount > 1)
                    {
                        var match = new SanctionMatch();
                        match.ParticipantId = participant.Id;
                        match.SanctionListId = list.Id;
                        match.SanctionTerm = item.FullTerm;
                        match.SanctionComments = item.Comments;
                        match.Date = DateTime.Now;
                        match.Status = 'P';
                        _context.SanctionMatches.Add(match);
                        await _context.SaveChangesAsync();
                        isMatch = true;
                    }
                }
                var discard = new ParticipantDiscard();
                discard.ParticipantId = participantId;
                discard.SanctionListId = list.Id;
                discard.Date = DateTime.Now;
                discard.Match = isMatch;
                _context.ParticipantDiscards.Add(discard);
                await _context.SaveChangesAsync();
                discards.Add(discard);
            }
            return Ok(discards);
        }

        private string IsNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value;
        }
    }
}