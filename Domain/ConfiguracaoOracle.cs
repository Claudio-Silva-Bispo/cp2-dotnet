namespace UserApi.Domain
{
    public class ConfiguracaoOracle
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FornecedorCollectionName { get; set; } = null!;
        public string VendedorCollectionName { get; set; } = null!;
       
      
    }
}