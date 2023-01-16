namespace challengeAPI.Entities
{
    public class Firma
    {
        public int Id { get; set; }

        public string FirmaAdi { get; set; }

        public bool OnayDurumu { get; set; }

        public DateTime SiparisIzinBaslangic { get; set; }

        public DateTime SiparisIzinBitisSaat { get; set; }
    }
}
