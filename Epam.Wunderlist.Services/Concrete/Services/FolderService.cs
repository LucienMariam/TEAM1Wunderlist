using System;
using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Concrete.Services
{
    public class FolderService: KeyService<FolderDal, FolderEntity, IFolderRepository, FolderMapper>, IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger)
        {
            _folderRepository = Repository;
        }

        public IEnumerable<FolderEntity> GetFolderList(int parentFolderId)
        {
            return _folderRepository.GetFolderList(parentFolderId).Select(dal => EntityMapper.ToBll(dal));
        }

        public IEnumerable<FolderEntity> GetRootFolders()
        {
            return _folderRepository.GetRootFolders().Select(dal => EntityMapper.ToBll(dal));
        }

        public void Rename(int id, string newTitle)
        {
            FolderEntity folder = EntityMapper.ToBll(_folderRepository.GetById(id));
            folder.Title = newTitle;
            Edit(folder);
        }
        public void CreateFolder()
        {
            throw new NotImplementedException();
        }
        public void DeleteFolder(int id)
        {
            FolderEntity folder = EntityMapper.ToBll(_folderRepository.GetById(id));
            Delete(folder);
        }
    }
}
