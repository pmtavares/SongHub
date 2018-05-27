using AutoMapper;
using Microsoft.AspNet.Identity;
using SongHub.DTOS;
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
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userid = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userid && !un.IsReady)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDTO>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userid = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
               .Where(un => un.UserId == userid && !un.IsReady)
               .ToList();

            notifications.ForEach(n => n.Read()); //Interact through list

            _context.SaveChanges();
            return Ok();

        }
    }
}
