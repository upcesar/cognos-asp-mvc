using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cognossystem_testes.Models
{
    public class Contatos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nome { get; set; }
        
        public Cargos Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Status Status { get; set; }
        public DateTime? Data_Inclusao { get; set; }
        public DateTime? Data_Ultima_alteracao { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresas Empresa { get; set; }
    }
}