﻿using System.Collections.Generic;
using Forge.UI.Interfaces;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class ActionDescription : IDescription
    {
        public string Name { get; private set; }

        public List<dynamic> Actions { get; } = new List<dynamic>();

        public void FromProperty(JProperty property)
        {
            Name = property.Name;
            Actions.AddRange(property.Value.Values<dynamic>());
        }
    }
}