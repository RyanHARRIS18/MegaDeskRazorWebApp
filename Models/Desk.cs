using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using MegaDeskRazorPages.Models;

namespace MegaDeskRazorPages.Models
{
    public class Desk
    {
        public int DeskId { get; set; }

        [Range(24, 96)]
        [Required]
        public decimal Width { get; set; }

        [Range(12, 24)]
        [Required]
        public decimal Depth { get; set; }
        [Display(Name = "Number of Drawers")]


        [Range(0, 7)]
        public int Drawers { get; set; }

        /*   [Display(Name = "Desktop Materials")]*/
        /*        public int DesktopMaterial { get; set; }*/

        public int DesktopMaterialId { get; set; }

        /* NAVIGATIN PROPERTY*/
        [Display(Name = "Desktop Materials")]
        public DesktopMaterial DesktopMaterial { get; set; }

        //public decimal Area;

        //public decimal SurfaceArea()
        //{
        //    return Width * Depth;
        //}

    }
}
