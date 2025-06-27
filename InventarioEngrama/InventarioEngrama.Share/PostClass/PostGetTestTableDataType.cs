using InventarioEngrama.Share.Entity;

namespace InventarioEngrama.Share.PostClass
{
	public class PostGetTestTableDataType
	{
		public string vchEmail { get; set; }
		public DateTime dtRegistered { get; set; }
		public IEnumerable<DTParameterType> Parameters { get; set; }
	}
}
