using Microsoft.AspNet.Identity;
using SongHub.DTOS;
using SongHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongHub.Controllers
{
   

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext  _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendences
                .Any(a=> a.AttendeeId == userId && a.GigId == dto.GigId);

            if(exists)
            {
                return BadRequest("Attendance already exists");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendences.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
