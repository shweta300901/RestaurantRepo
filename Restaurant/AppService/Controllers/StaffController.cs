using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Models;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace AppService.Controllers
{
    [EnableCors("http://localhost:62729/")]
    public class StaffController : ApiController
    {
        StaffBLL StaffBLL = new StaffBLL();

        [Route("api/staff/GetAll")]
        public HttpResponseMessage GetAllMember()
        {
            var members = StaffBLL.GetAllMember();
            if (members != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, members);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/staff/GetById/{id}")]
        public HttpResponseMessage GetMemberById(int id)
        {
            var member = StaffBLL.GetMemberById(id);
            if (member != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, member);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/staff/AddMember")]
        public HttpResponseMessage PostMember([FromBody] staff memb)
        {
            var result = StaffBLL.AddMember(memb);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/staff/RemoveMember/{id}")]
        public HttpResponseMessage DeleteMember(int id)
        {
            var result = StaffBLL.RemoveMember(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/staff/UpdateMember")]
        public HttpResponseMessage PutMember([FromBody] staff memb)
        {
            var result = StaffBLL.EditMember(memb);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    };
}
