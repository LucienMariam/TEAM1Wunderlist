using FolderService;
using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class FolderController : ApiController
    {
        IFolderService folders = (IFolderService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IFolderService));
        // GET: api/Task
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Task/5

        [ActionName("DefaultAction")]
        public IEnumerable<FolderModel> Get(int id)
        {
            var folderList = folders.GetAll().Where(x=>x.UserId==id).Select(x=>new FolderModel() { Id = x.Id, ParentFolderId = x.ParentFolderId,UserId = x.UserId, Title = x.Title});
            return folderList;
        }
        [ActionName("GetByParentId")]
        public IEnumerable<FolderModel> GetByParentId(int id)
        {
            var folderList = folders.GetAll().Where(x => x.ParentFolderId == id).Select(x => new FolderModel() { Id = x.Id, ParentFolderId = x.ParentFolderId, UserId = x.UserId, Title = x.Title });
            return folderList;
        }
        // POST: api/Task
        [ActionName("DefaultAction")]
        public void Post(FolderModel value)
        {
            folders.Add(new FolderEntity() { ParentFolderId= value.ParentFolderId, Title= value.Title, UserId= value.UserId});
        }

        // PUT: api/Task/5
        [ActionName("DefaultAction")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        [ActionName("DefaultAction")]
        public void Delete(int id)
        {
            folders.DeleteFolder(id);
        }
    }
}
