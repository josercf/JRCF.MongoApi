using System;
using System.Collections.Generic;
using System.Text;

namespace JRCF.MongoApi
{
	public class RequestModel
	{
		public string telefone { get; set; }
		public bool cliente { get; set; }
		public string satisfacao { get; set; }
		public string justificativa { get; set; }
		public string sessao { get; set; }
		public string identificador { get; set; }
    }
}
