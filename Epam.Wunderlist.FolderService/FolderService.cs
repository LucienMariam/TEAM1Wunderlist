using System;
using ServiceAbstraction;
using DAL.Entities;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using BLL.Entities;

namespace FolderService
{
    public class FolderService: BaseService<FolderDal, FolderEntity, IFolderRepository, FolderMapper>, IFolderService
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

        public IEnumerable<FolderEntity> GetRootFolders(int userId)
        {
            throw new NotImplementedException();
        }

        public void Rename(int id, string newTitle)
        {
            FolderEntity folder = EntityMapper.ToBll(_folderRepository.GetById(id));
            folder.Title = newTitle;
            Edit(folder);
        }
        public void CreateFolder(FolderEntity newFolder)
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
