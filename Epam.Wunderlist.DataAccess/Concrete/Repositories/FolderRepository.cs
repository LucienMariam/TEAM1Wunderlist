using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Concrete.Mappers;
using DAL.Concrete.Entities;
using DAL.Interfaces.Repositories;
using ORM;

namespace DAL.Concrete.Repositories
{
    public class FolderRepository: KeyRepository<Folder, FolderDal, FolderMapperDal>, IFolderRepository
    {
        public FolderRepository(DbContext context): base(context) { }

        public IEnumerable<FolderDal> GetFolderList(int parentFolderId)
        {
            Func<Folder, FolderDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<Folder>().AsNoTracking()
                .Where(x => x.ParentFolderId == parentFolderId).Select(f);
        }

        public IEnumerable<FolderDal> GetRootFolders(int userId)
        {
            Func<Folder, FolderDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<Folder>().AsNoTracking()
                .Where(x => (x.UserId == userId && x.ParentFolderId == null)).Select(f);
        } 
    }
}
