using System.Collections.Generic;
using ServiceAbstraction;
using BLL.Entities;

namespace FolderService
{
    public interface IFolderService: IService<FolderEntity>
    {
        IEnumerable<FolderEntity> GetFolderList(int parentFolderId);
        IEnumerable<FolderEntity> GetRootFolders(int userId);

        void Rename(int id, string newTitle);
        void CreateFolder(FolderEntity newFolder);
        void DeleteFolder(int id);
    }
}
