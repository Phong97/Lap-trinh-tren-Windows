//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrangBi
    {
        public int MaPhong { get; set; }
        public int MaThietBi { get; set; }
        public Nullable<System.DateTime> ThoiDiem { get; set; }
    
        public virtual PhongTro PhongTro { get; set; }
        public virtual ThietBi ThietBi { get; set; }
    }
}
