﻿using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IImportDetailService
    {
        List<ImportDetail> GetAllImportDetails();
        void InsertImportDetail(ImportDetail importDetail);
    }
}
