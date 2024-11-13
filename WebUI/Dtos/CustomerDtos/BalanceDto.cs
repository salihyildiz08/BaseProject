namespace WebUI.Dtos.CustomerDtos
{
    public class BalanceDto
    {
        public string kod { get; set; }
        public string Unvan { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public decimal BorcBakiye { get; set; }
        public decimal AlacakBakiye { get; set; }
        public string RiskTürü { get; set; }
        public string calisilan_doviz_turu { get; set; }
        public string CariTip { get; set; }
        public decimal Bakiye { get; set; }
        public string MüsteriTemsilcisi { get; set; }
        public string SatisBölgesi { get; set; }
        public string KODM { get; set; }
    }
}
