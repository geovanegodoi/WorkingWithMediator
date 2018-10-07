﻿using System;

namespace WWM.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public long Population { get; set; }

        public Guid CountryId { get; set; }
    }
}