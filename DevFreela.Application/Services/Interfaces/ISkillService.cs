﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public class ISkillService
    {
        List<SkillViewModel> GetAll();

    }
}
