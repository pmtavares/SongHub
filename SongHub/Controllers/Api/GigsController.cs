using Microsoft.AspNet.Identity;
using SongHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SongHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {

        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g=> g.Attendances.Select(a=>a.Attendee)) // In order to remove getting list of attendees
                .Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.IsCanceled = true;

            //Send notification
            var notification = new Notification(NotificationType.GigCanceled, gig);

            /*var attendees = _context.Attendences
                .Where(a => a.GigId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            */
            foreach (var attendee in gig.Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
