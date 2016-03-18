using System.Collections.Generic;
using DAL.Entities;

namespace DataAccess.Interfaces
{
    public interface IFolderRepository: IRepository<FolderDal>
    {
        IEnumerable<FolderDal> GetFolderList(int parentFolderId);
        IEnumerable<FolderDal> GetRootFolders(int userId);
    }
}
