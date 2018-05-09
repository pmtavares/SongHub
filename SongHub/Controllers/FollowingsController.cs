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
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO dto)
        {
            var userId = User.Identity.GetUserId();

            if(_context.Followings.Any(f=> f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Following already Exists");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }

    }
}
