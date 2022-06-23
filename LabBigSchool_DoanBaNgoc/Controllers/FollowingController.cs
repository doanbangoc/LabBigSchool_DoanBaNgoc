using LabBigSchool_DoanBaNgoc.DTOs;
using LabBigSchool_DoanBaNgoc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabBigSchool_DoanBaNgoc.Controllers
{
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingController()
        {
            _dbContext = new ApplicationDbContext();

        }
        // GET: Followings
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!!!");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId

            };
            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
