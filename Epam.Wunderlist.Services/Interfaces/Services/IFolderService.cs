﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Concrete.Entities;

namespace BLL.Interfaces.Services
{
    public interface IFolderService: IKeyService<FolderEntity>
    {
        IEnumerable<FolderEntity> GetFolderList(int parentFolderId);
        IEnumerable<FolderEntity> GetRootFolders();

        void Rename(int id, string newTitle);
        void CreateFolder(); // model or BllEntity
        void DeleteFolder(int id);
    }
}