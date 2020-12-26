﻿using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public interface ICopyRepository
    {
        List<Copy> GetAllCopies(); // получить все публикации
        List<CopyInForm> GetAllCopiesInForm(int CopyId);
        List<Copy> GetAllCopiesByPublicationId(int PublicationId);
        Copy GetCopyDetails(int CopyId); // получить информацию о Copy по Id
        void CreateCopy(Copy copy); // создать новую Copy
        void UpdateCopy(Copy copy); // обновить запись в БД
        void DeleteCopy(Copy copy); // удалить запись из БД
    }
}