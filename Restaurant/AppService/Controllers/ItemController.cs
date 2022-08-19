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
    public class ItemController : ApiController
    {
        ItemBLL ItemBLL = new ItemBLL();

        [Route("api/Item/GetAll")]
        public HttpResponseMessage GetAllItem()
        {
            var items = ItemBLL.GetAllItem();
            if (items != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, items);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/Item/GetById/{id}")]
        public HttpResponseMessage GetItemById(int id)
        {
            var item = ItemBLL.GetItemById(id);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/Item/AddItem")]
        public HttpResponseMessage PostItem([FromBody] Item item)
        {
            var result = ItemBLL.AddItem(item);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/Item/RemoveItem/{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            var result = ItemBLL.RemoveItem(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/Item/UpdateItem")]
        public HttpResponseMessage PutItem([FromBody] Item item)
        {
            var result = ItemBLL.EditItem(item);
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

