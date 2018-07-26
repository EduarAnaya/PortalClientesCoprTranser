using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.administracion
{
    public class Account
    {
        [Required]
        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }

        [Required]
        [Display(Name = "Direccion de Correo")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage="Por favor indique una contraseña")]
        [Display(Name = "Contraseña Actual")]
        
        public string CONTRASEÑA_ACTUAL { get; set; }

        [Required(ErrorMessage = "Por favor indique la nueva contraseña")]
        [Display(Name = "Nueva Contraseña")]
        public string NUEVA_CONTRASEÑA { get; set; }

        [Required(ErrorMessage = "Por favor confirme la contraseña")]
        [Display(Name = "Nueva Contraseña")]
        public string CONFIRM_CONTRASEÑA { get; set; }
    }
}