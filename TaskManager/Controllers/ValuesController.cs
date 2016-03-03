using BLL.Concrete.Entities;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TaskManager.Controllers
{
    public class ValuesController : ApiController
    {
        IUserService users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            string root = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/");
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] fileArray = await file.ReadAsByteArrayAsync();

                using (System.IO.FileStream fs = new System.IO.FileStream(root + filename, System.IO.FileMode.Create))
                {
                    await fs.WriteAsync(fileArray, 0, fileArray.Length);
                }
                var temp = users.GetUserEntityByEmail(User.Identity.Name);
                temp.Photo = "UploadedFiles/"+filename;
                var userForUpdate = new UserEntity()
                {
                    Id = temp.Id,
                    Email = temp.Email,
                    Login = temp.Login,
                    Password = temp.Password,
                    Photo = temp.Photo 
                };
                users.Edit(userForUpdate);
            }

            return Ok("OK");
        }
    }
}
