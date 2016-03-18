using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Interfaces;
using ORM;
using DAL.Entities;
using DAL.Mappers;

namespace DataAccess.MsSql
{
    public class FolderRepository: BaseRepository<Folder, FolderDal, FolderMapperDal>, IFolderRepository
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
