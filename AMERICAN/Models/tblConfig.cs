using System;
using System.Collections.Generic;

namespace AMERICAN.Models
{
    public partial class tblConfig
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string ImageLinkLogo { get; set; }
        public string Favicon { get; set; }
        public Nullable<bool> Popup { get; set; }
        public Nullable<bool> PopupSupport { get; set; }
        public string Footer { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Mobile1 { get; set; }
        public string Hotline1 { get; set; }
        public string Mobile2 { get; set; }
        public string Hotline2 { get; set; }
        public string PbxSell { get; set; }
        public string PbxGua { get; set; }
        public string PbxDen { get; set; }
        public string Email { get; set; }
        public string Slogan { get; set; }
        public string Authorship { get; set; }
        public string FanpageFacebook { get; set; }
        public string FanpageGoogle { get; set; }
        public string FanpageYoutube { get; set; }
        public string DMCA { get; set; }
        public string CodeChat { get; set; }
        public Nullable<bool> Coppy { get; set; }
        public Nullable<bool> Social { get; set; }
        public string UserEmail { get; set; }
        public string PassEmail { get; set; }
        public string Host { get; set; }
        public Nullable<int> Port { get; set; }
        public Nullable<int> Timeout { get; set; }
        public Nullable<int> Language { get; set; }
    }
}
