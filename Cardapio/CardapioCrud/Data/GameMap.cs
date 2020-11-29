﻿using CardapioCrud.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioCrud.Data
{
    public class GameMap
    {
        public GameMap(EntityTypeBuilder<Game> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.name).IsRequired();

        }
    }
}
