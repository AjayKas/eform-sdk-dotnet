﻿using System;
using System.Xml;
using System.Xml.Serialization;

namespace eFormRequest
{
    [Serializable()]
    public class Entity
    {
        #region con
        internal Entity()
        {

        }

        public Entity(string identifier, string description, string km, string colour, string radiocode, string id)
        {
            EntityTypeId = "Not created yet";
            Identifier = identifier;
            Description = new CDataValue();
            Description.InderValue = description;
            Km = km;
            Colour = colour;
            Radiocode = radiocode;
            Id = id;
        }
        #endregion

        #region var
        public string EntityTypeId { get; set; }
        public string Identifier { get; set; }

        [XmlElement("Description")]
        public CDataValue Description { get; set; }

        public string Km { get; set; }
        public string Colour { get; set; }
        public string Radiocode { get; set; }
        public string Id { get; set; }
        public string MicrotingUUId { get; set; }
        #endregion
    }

    #region Nested type: NodeType

    public class CDataValue
    {
        [XmlIgnore]
        public string InderValue { get; set; }

        [XmlText]
        public XmlNode[] CDataWrapper
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(InderValue) };
            }
            set
            {
                if (value == null)
                {
                    InderValue = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                        String.Format(
                            "Invalid array length {0}", value.Length));
                }

                InderValue = value[0].Value;
            }
        }
    }

    #endregion
}