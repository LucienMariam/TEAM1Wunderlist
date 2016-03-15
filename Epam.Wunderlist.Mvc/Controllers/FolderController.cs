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
            var folderList = folders.GetAll().Where(x => x.UserId == id).Select(x => new FolderModel() { Id = x.Id, ParentFolderId = x.ParentFolderId, UserId = x.UserId, Title = x.Title });
            return folderList;
        }

        [ActionName("GetFolderById")]
        public FolderModel GetFolderById(int id)
        {
            var folder = folders.GetById(id);
            return new FolderModel() { Id = folder.Id, ParentFolderId = folder.ParentFolderId, UserId = folder.UserId, Title = folder.Title };
        }
        [ActionName("GetByParentId")]
        public IEnumerable<FolderModel> GetByParentId(int id)
        {
            var folderList = folders.GetAll().Where(x => x.ParentFolderId == id).Select(x => new FolderModel() { Id = x.Id, ParentFolderId = x.ParentFolderId, UserId = x.UserId, Title = x.Title });
            return folderList;
        }

        [ActionName("DefaultAction")]
        public void Post(FolderModel value)
        {
            folders.Add(new FolderEntity() { ParentFolderId = value.ParentFolderId, Title = value.Title, UserId = value.UserId });
        }

        [ActionName("PostFolder")]
        public void PostFolder(FolderModel value)
        {


            var folderForUpdate = new FolderEntity()
            {
                Id = value.Id,
                UserId = int.Parse(User.Identity.Name),
                ParentFolderId = null,
                Title = value.Title
            };
            folders.Edit(folderForUpdate);

        }

        [ActionName("DefaultAction")]
        public void Put(int id, [FromBody]string value)
        {
        }


        [ActionName("DefaultAction")]
        public void Delete(int id)
        {
            folders.DeleteFolder(id);
        }
    }
}
