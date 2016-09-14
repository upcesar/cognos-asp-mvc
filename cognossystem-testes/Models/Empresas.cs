using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cognossystem_testes.Models
{
    public class Empresas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public Status Status { get; set; }

        public DateTime? Data_Inclusao { get; set; }

        public DateTime? Data_Ultima_Alteracao { get; set; }
        public virtual List<Contatos> Contatos { get; set; }
    }

}