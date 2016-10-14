﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace eFormRequest
{
    public class ReplyElement
    {
        #region var
        public string Id { get; set; }
        public string Label { get; set; }
        public int DisplayOrder { get; set; }
        public string CheckListFolderName { get; set; }
        public int Repeated { get; set; }

        #region public string/DateTime StartDate { get; set; }
        public string StartDate { get; set; }

        public DateTime GetStartDate()
        {
            return DateTime.Parse(StartDate);
        }

        public void SetStartDate(DateTime dateTime)
        {
            StartDate = dateTime.ToShortDateString();
        }
        #endregion

        #region public string/DateTime EndDate { get; set; }
        public string EndDate { get; set; }

        public DateTime GetEndDate()
        {
            return DateTime.Parse(EndDate);
        }

        public void SetEndDate(DateTime dateTime)
        {
            EndDate = dateTime.ToShortDateString();
        }
        #endregion
        public string Language { get; set; }
        public bool MultiApproval { get; set; }
        public bool FastNavigation { get; set; }
        public bool DownloadEntities { get; set; }
        public bool ManualSync { get; set; }

        [XmlArray("ElementList"), XmlArrayItem(typeof(Element), ElementName = "Element")]
        public List<Element> ElementList { get; set; }
        #endregion
    }
}