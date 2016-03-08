using System.Collections.Generic;
using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IFolderRepository: IKeyRepository<FolderDal>
    {
        IEnumerable<FolderDal> GetFolderList(int parentFolderId);
        IEnumerable<FolderDal> GetRootFolders();
    }
}
