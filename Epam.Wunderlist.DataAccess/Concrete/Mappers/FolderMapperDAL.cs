using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;
using ORM;

namespace DAL.Concrete.Mappers
{
    public class FolderMapperDal: IMapperDal<Folder, FolderDal>
    {
        public Folder ToOrm(FolderDal item)
        {
            return new Folder()
            {
                Id = item.Id,
                UserId = item.UserId,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }

        public FolderDal ToDal(Folder item)
        {
            return new FolderDal()
            {
                Id = item.Id,
                UserId = item.UserId,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }
    }
}
