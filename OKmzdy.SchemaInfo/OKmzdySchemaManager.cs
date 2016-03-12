using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.SqlSchemaInfo;

namespace OKmzdy.OKmzdySchemaInfo
{
    public class OKmzdySchemaManager : BaseSchemaManager
    {
        public OKmzdySchemaManager(string lpszOwnerName, string lpszUsersName) : base(lpszOwnerName, lpszUsersName)
        {
            ALL_TABLES_DICT = CreateTablesDictionary();
        }
        public override IDictionary<string, TableDefInfo> CreateTablesDictionary()
        {
            return new Dictionary<string, TableDefInfo>()
            {
                { TablesDataStav.TableStavDatabazeInfo.GetNameKey(), TablesDataStav.TableStavDatabazeInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableFirmaInfo.GetNameKey(), TablesFirma.TableFirmaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableSvatekInfo.GetNameKey(), TablesFirma.TableSvatekInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableAdresaInfo.GetNameKey(), TablesFirma.TableAdresaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableBankSpojInfo.GetNameKey(), TablesFirma.TableBankSpojInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableOrganizaceInfo.GetNameKey(), TablesFirma.TableOrganizaceInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableUtvarInfo.GetNameKey(), TablesFirma.TableUtvarInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableDivizeStredInfo.GetNameKey(), TablesFirma.TableDivizeStredInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableStredCinzakInfo.GetNameKey(), TablesFirma.TableStredCinzakInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableStredRozpocetInfo.GetNameKey(), TablesFirma.TableStredRozpocetInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableStavSemaforInfo.GetNameKey(), TablesFirma.TableStavSemaforInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesFirma.TableUzivatelInfo.GetNameKey(), TablesFirma.TableUzivatelInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracInfo.GetNameKey(), TablesPrac.TablePracInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableOsdataInfo.GetNameKey(), TablesPrac.TableOsdataInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePojistitelInfo.GetNameKey(), TablesPrac.TablePojistitelInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableHlaseniZpInfo.GetNameKey(), TablesPrac.TableHlaseniZpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracNepritInfo.GetNameKey(), TablesPrac.TablePracNepritInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableDanInfo.GetNameKey(), TablesPrac.TableDanInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableSrazkaInfo.GetNameKey(), TablesPrac.TableSrazkaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerInfo.GetNameKey(), TablesPrac.TablePpomerInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerDovInfo.GetNameKey(), TablesPrac.TablePpomerDovInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerDovRokInfo.GetNameKey(), TablesPrac.TablePpomerDovRokInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerMesInfo.GetNameKey(), TablesPrac.TablePpomerMesInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerSumInfo.GetNameKey(), TablesPrac.TablePpomerSumInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerOzpInfo.GetNameKey(), TablesPrac.TablePpomerOzpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerPraxeInfo.GetNameKey(), TablesPrac.TablePpomerPraxeInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePpomerSluzbaInfo.GetNameKey(), TablesPrac.TablePpomerSluzbaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracVzdelavaniInfo.GetNameKey(), TablesPrac.TablePracVzdelavaniInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePrijmySspInfo.GetNameKey(), TablesPrac.TablePrijmySspInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePrijmyInfo.GetNameKey(), TablesPrac.TablePrijmyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableProhlaseniInfo.GetNameKey(), TablesPrac.TableProhlaseniInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableRodinaInfo.GetNameKey(), TablesPrac.TableRodinaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePrijmyMesInfo.GetNameKey(), TablesPrac.TablePrijmyMesInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableMzdaInfo.GetNameKey(), TablesPrac.TableMzdaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableNepritInfo.GetNameKey(), TablesPrac.TableNepritInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableUvazekInfo.GetNameKey(), TablesPrac.TableUvazekInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableUzivDataPpomerInfo.GetNameKey(), TablesPrac.TableUzivDataPpomerInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TableUzivReldpDavkaInfo.GetNameKey(), TablesPrac.TableUzivReldpDavkaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracReldpDataInfo.GetNameKey(), TablesPrac.TablePracReldpDataInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracReldpListekInfo.GetNameKey(), TablesPrac.TablePracReldpListekInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracReldp09DataPracInfo.GetNameKey(), TablesPrac.TablePracReldp09DataPracInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesPrac.TablePracReldp09DataPojInfo.GetNameKey(), TablesPrac.TablePracReldp09DataPojInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TablePlatbyKonfigInfo.GetNameKey(), TablesKonfig.TablePlatbyKonfigInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TablePlatbyUtvaryInfo.GetNameKey(), TablesKonfig.TablePlatbyUtvaryInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TablePopisSlozkaInfo.GetNameKey(), TablesKonfig.TablePopisSlozkaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TablePopisSlozkaHInfo.GetNameKey(), TablesKonfig.TablePopisSlozkaHInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TablePopisSlozkaTInfo.GetNameKey(), TablesKonfig.TablePopisSlozkaTInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableTarifniTridaInfo.GetNameKey(), TablesKonfig.TableTarifniTridaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableTarifniTridaHInfo.GetNameKey(), TablesKonfig.TableTarifniTridaHInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableTarifniTridaTInfo.GetNameKey(), TablesKonfig.TableTarifniTridaTInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableUcetniOsnovaInfo.GetNameKey(), TablesKonfig.TableUcetniOsnovaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableUcetniPredpisyInfo.GetNameKey(), TablesKonfig.TableUcetniPredpisyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableUcetniPolozkyInfo.GetNameKey(), TablesKonfig.TableUcetniPolozkyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableUzivCiselnikInfo.GetNameKey(), TablesKonfig.TableUzivCiselnikInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableValutaKurzInfo.GetNameKey(), TablesKonfig.TableValutaKurzInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableValutaKurzMesInfo.GetNameKey(), TablesKonfig.TableValutaKurzMesInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableZemePlatkoefInfo.GetNameKey(), TablesKonfig.TableZemePlatkoefInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableZemePlatkoefMesInfo.GetNameKey(), TablesKonfig.TableZemePlatkoefMesInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavKonfigInfo.GetNameKey(), TablesKonfig.TableStavKonfigInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavKonfigUcertInfo.GetNameKey(), TablesKonfig.TableStavKonfigUcertInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavKonfigSmtpInfo.GetNameKey(), TablesKonfig.TableStavKonfigSmtpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavKonfigVrepInfo.GetNameKey(), TablesKonfig.TableStavKonfigVrepInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavMesInfo.GetNameKey(), TablesKonfig.TableStavMesInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavMesDanInfo.GetNameKey(), TablesKonfig.TableStavMesDanInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavStatInfo.GetNameKey(), TablesKonfig.TableStavStatInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavDefaultInfo.GetNameKey(), TablesKonfig.TableStavDefaultInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavOzpInfo.GetNameKey(), TablesKonfig.TableStavOzpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableStavMessageInfo.GetNameKey(), TablesKonfig.TableStavMessageInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesKonfig.TableSestavyHtmlInfo.GetNameKey(), TablesKonfig.TableSestavyHtmlInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TablePoplatkyInfo.GetNameKey(), TablesSestavy.TablePoplatkyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableDetailMediaInfo.GetNameKey(), TablesSestavy.TableDetailMediaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableFiltrMediaInfo.GetNameKey(), TablesSestavy.TableFiltrMediaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableFiltrPmediaInfo.GetNameKey(), TablesSestavy.TableFiltrPmediaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableFiltrUmediaInfo.GetNameKey(), TablesSestavy.TableFiltrUmediaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSestavyFiltrInfo.GetNameKey(), TablesSestavy.TableSestavyFiltrInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSestavyLstInfo.GetNameKey(), TablesSestavy.TableSestavyLstInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSestavyUdataInfo.GetNameKey(), TablesSestavy.TableSestavyUdataInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSestavyUlstInfo.GetNameKey(), TablesSestavy.TableSestavyUlstInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSestavyUzivInfo.GetNameKey(), TablesSestavy.TableSestavyUzivInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableSberneMediumInfo.GetNameKey(), TablesSestavy.TableSberneMediumInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TablePlatebniMediumInfo.GetNameKey(), TablesSestavy.TablePlatebniMediumInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableUcetniMediumInfo.GetNameKey(), TablesSestavy.TableUcetniMediumInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableNavestiFiltrInfo.GetNameKey(), TablesSestavy.TableNavestiFiltrInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableNavestiUzivInfo.GetNameKey(), TablesSestavy.TableNavestiUzivInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TablePracUkazateleInfo.GetNameKey(), TablesSestavy.TablePracUkazateleInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TablePpomUkazateleInfo.GetNameKey(), TablesSestavy.TablePpomUkazateleInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableVrepPodaniDataInfo.GetNameKey(), TablesSestavy.TableVrepPodaniDataInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesSestavy.TableExcelUimpInfo.GetNameKey(), TablesSestavy.TableExcelUimpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestSoczdrPaymsInfo.GetNameKey(), TablesZSestav.TableZsestSoczdrPaymsInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDanZvyhodneInfo.GetNameKey(), TablesZSestav.TableZsestDanZvyhodneInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDanOznameniInfo.GetNameKey(), TablesZSestav.TableZsestDanOznameniInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestExtMzdlistInfo.GetNameKey(), TablesZSestav.TableZsestExtMzdlistInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDanPrijmyInfo.GetNameKey(), TablesZSestav.TableZsestDanPrijmyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDanPotvrzeniInfo.GetNameKey(), TablesZSestav.TableZsestDanPotvrzeniInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDanHlaseni5478Info.GetNameKey(), TablesZSestav.TableZsestDanHlaseni5478Info.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDavkaUcetniInfo.GetNameKey(), TablesZSestav.TableZsestDavkaUcetniInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestEldp2004Info.GetNameKey(), TablesZSestav.TableZsestEldp2004Info.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestMlmesiceInfo.GetNameKey(), TablesZSestav.TableZsestMlmesiceInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestMlnepritInfo.GetNameKey(), TablesZSestav.TableZsestMlnepritInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestMlnezdanInfo.GetNameKey(), TablesZSestav.TableZsestMlnezdanInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestMlpomeryInfo.GetNameKey(), TablesZSestav.TableZsestMlpomeryInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestMlpracovInfo.GetNameKey(), TablesZSestav.TableZsestMlpracovInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestNemDavkyInfo.GetNameKey(), TablesZSestav.TableZsestNemDavkyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPlatbyCrInfo.GetNameKey(), TablesZSestav.TableZsestPlatbyCrInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPlatbyEuroInfo.GetNameKey(), TablesZSestav.TableZsestPlatbyEuroInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPrijemSspInfo.GetNameKey(), TablesZSestav.TableZsestPrijemSspInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestRekapitInfo.GetNameKey(), TablesZSestav.TableZsestRekapitInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestSocialInfo.GetNameKey(), TablesZSestav.TableZsestSocialInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDsporHlascaInfo.GetNameKey(), TablesZSestav.TableZsestDsporHlascaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDsporHlasnaInfo.GetNameKey(), TablesZSestav.TableZsestDsporHlasnaInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDsporVyuctInfo.GetNameKey(), TablesZSestav.TableZsestDsporVyuctInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvrzDpInfo.GetNameKey(), TablesZSestav.TableZsestPotvrzDpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableMzvIisspPredpisyInfo.GetNameKey(), TablesZSestav.TableMzvIisspPredpisyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestUzivSestInfo.GetNameKey(), TablesZSestav.TableZsestUzivSestInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestVypDaneInfo.GetNameKey(), TablesZSestav.TableZsestVypDaneInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestVyplListinyInfo.GetNameKey(), TablesZSestav.TableZsestVyplListinyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestVyplListkyInfo.GetNameKey(), TablesZSestav.TableZsestVyplListkyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestVyuctZmenyInfo.GetNameKey(), TablesZSestav.TableZsestVyuctZmenyInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZdravInfo.GetNameKey(), TablesZSestav.TableZsestZdravInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZmenyZpInfo.GetNameKey(), TablesZSestav.TableZsestZmenyZpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetadInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetadInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetaoInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetaoInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvs2VetaoInfo.GetNameKey(), TablesZSestav.TableZsestDpzvs2VetaoInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetaeInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetaeInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvs2VetaeInfo.GetNameKey(), TablesZSestav.TableZsestDpzvs2VetaeInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetafInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetafInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetagInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetagInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetabInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetabInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestDpzvd2VetacInfo.GetNameKey(), TablesZSestav.TableZsestDpzvd2VetacInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPpomerPraxeInfo.GetNameKey(), TablesZSestav.TableZsestPpomerPraxeInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvrzHlavInfo.GetNameKey(), TablesZSestav.TableZsestPotvrzHlavInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPot313VedlInfo.GetNameKey(), TablesZSestav.TableZsestPot313VedlInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPot313NeschInfo.GetNameKey(), TablesZSestav.TableZsestPot313NeschInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPot313PohlInfo.GetNameKey(), TablesZSestav.TableZsestPot313PohlInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvrzZpInfo.GetNameKey(), TablesZSestav.TableZsestPotvrzZpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvrzSpInfo.GetNameKey(), TablesZSestav.TableZsestPotvrzSpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKontrZdrpInfo.GetNameKey(), TablesZSestav.TableZsestKontrZdrpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKontrSocpInfo.GetNameKey(), TablesZSestav.TableZsestKontrSocpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestOznamSocpInfo.GetNameKey(), TablesZSestav.TableZsestOznamSocpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPrehlSocpInfo.GetNameKey(), TablesZSestav.TableZsestPrehlSocpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPrilohaSocpInfo.GetNameKey(), TablesZSestav.TableZsestPrilohaSocpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestSlevySocpInfo.GetNameKey(), TablesZSestav.TableZsestSlevySocpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestNemDavky09Info.GetNameKey(), TablesZSestav.TableZsestNemDavky09Info.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadNemInfo.GetNameKey(), TablesZSestav.TableZsestZadNemInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadNemNeschInfo.GetNameKey(), TablesZSestav.TableZsestZadNemNeschInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadNemRozhobdInfo.GetNameKey(), TablesZSestav.TableZsestZadNemRozhobdInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadMatInfo.GetNameKey(), TablesZSestav.TableZsestZadMatInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadMatNeschInfo.GetNameKey(), TablesZSestav.TableZsestZadMatNeschInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadMatRozhobdInfo.GetNameKey(), TablesZSestav.TableZsestZadMatRozhobdInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvdavSspInfo.GetNameKey(), TablesZSestav.TableZsestPotvdavSspInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestReldp09PracInfo.GetNameKey(), TablesZSestav.TableZsestReldp09PracInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestReldp09PojInfo.GetNameKey(), TablesZSestav.TableZsestReldp09PojInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPrehvyuctfinInfo.GetNameKey(), TablesZSestav.TableZsestPrehvyuctfinInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotVptInfo.GetNameKey(), TablesZSestav.TableZsestPotVptInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotVptRozhobdInfo.GetNameKey(), TablesZSestav.TableZsestPotVptRozhobdInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPrehlZdrpInfo.GetNameKey(), TablesZSestav.TableZsestPrehlZdrpInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestZadostBonusmrInfo.GetNameKey(), TablesZSestav.TableZsestZadostBonusmrInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestPotvvrzOsr111Info.GetNameKey(), TablesZSestav.TableZsestPotvvrzOsr111Info.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKartazZaklInfo.GetNameKey(), TablesZSestav.TableZsestKartazZaklInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKartazPpozInfo.GetNameKey(), TablesZSestav.TableZsestKartazPpozInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKartazVzdvInfo.GetNameKey(), TablesZSestav.TableZsestKartazVzdvInfo.GetDictValue(m_strOwnerName, m_strUsersName) },
                { TablesZSestav.TableZsestKartazPpomInfo.GetNameKey(), TablesZSestav.TableZsestKartazPpomInfo.GetDictValue(m_strOwnerName, m_strUsersName) }
            };
        }

        public override IList<TableDefInfo> CreateServiceTableList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesDataStav.TableStavDatabazeInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableFirmaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableSvatekInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableAdresaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableBankSpojInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableOrganizaceInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableUtvarInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableDivizeStredInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredCinzakInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredRozpocetInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStavSemaforInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableUzivatelInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableOsdataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePojistitelInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableHlaseniZpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableDanInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableSrazkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovRokInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerMesInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSumInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerPraxeInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSluzbaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracVzdelavaniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmySspInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableProhlaseniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableRodinaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyMesInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableMzdaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUvazekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUzivDataPpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUzivReldpDavkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpDataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpListekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPracInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPojInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyUtvaryInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaTInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaTInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniOsnovaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPredpisyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPolozkyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUzivCiselnikInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableValutaKurzInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableValutaKurzMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigUcertInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigSmtpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigVrepInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesDanInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavStatInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavDefaultInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMessageInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableSestavyHtmlInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePoplatkyInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableDetailMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrPmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrUmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyFiltrInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyLstInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUdataInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUlstInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSberneMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePlatebniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableUcetniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiFiltrInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePracUkazateleInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePpomUkazateleInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableVrepPodaniDataInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableExcelUimpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSoczdrPaymsInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanZvyhodneInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanOznameniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestExtMzdlistInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanPrijmyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanPotvrzeniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanHlaseni5478Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDavkaUcetniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestEldp2004Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlmesiceInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlnepritInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlnezdanInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlpomeryInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlpracovInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestNemDavkyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPlatbyCrInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPlatbyEuroInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrijemSspInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestRekapitInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSocialInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporHlascaInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporHlasnaInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporVyuctInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzDpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableMzvIisspPredpisyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestUzivSestInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVypDaneInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyplListinyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyplListkyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyuctZmenyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZdravInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZmenyZpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetadInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetaoInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvs2VetaoInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetaeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvs2VetaeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetafInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetagInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetabInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetacInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPpomerPraxeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzHlavInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313VedlInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313NeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313PohlInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzZpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzSpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKontrZdrpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKontrSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestOznamSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehlSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrilohaSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSlevySocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestNemDavky09Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemNeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatNeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvdavSspInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestReldp09PracInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestReldp09PojInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehvyuctfinInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotVptInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotVptRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehlZdrpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadostBonusmrInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvvrzOsr111Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazZaklInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazPpozInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazVzdvInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazPpomInfo(lpszOwnerName, lpszUsersName)
            };
        }

        public override IList<TableDefInfo> CreateContextServiceList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesDataStav.TableStavDatabazeInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStavSemaforInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableUzivatelInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavDefaultInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMessageInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavStatInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesDanInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextCompanyList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesFirma.TableFirmaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableOrganizaceInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableAdresaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableBankSpojInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableSvatekInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextOrganizList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesFirma.TableUtvarInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableDivizeStredInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredCinzakInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredRozpocetInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyUtvaryInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextPersonaList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesPrac.TablePracInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovRokInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerPraxeInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSluzbaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracVzdelavaniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableOsdataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePojistitelInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableHlaseniZpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableProhlaseniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableRodinaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracVyberAggr(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePracUkazateleInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePpomUkazateleInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextPeriodsList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesPrac.TableMzdaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUvazekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableDanInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableSrazkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerMesInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSumInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmySspInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyMesInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextToolSetList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesSestavy.TableSberneMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePlatebniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableUcetniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableDetailMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePoplatkyInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrPmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrUmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableExcelUimpInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextWageSetList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesKonfig.TablePopisSlozkaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaTInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextTariffsList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesKonfig.TableTarifniTridaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaTInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextCurrSetList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesKonfig.TableValutaKurzInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableValutaKurzMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefMesInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextReportsList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesSestavy.TableSestavyLstInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUdataInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUlstInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyFiltrInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiFiltrInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextExportsList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesKonfig.TableUcetniOsnovaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPredpisyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPolozkyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUzivCiselnikInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigUcertInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigSmtpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigVrepInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableSestavyHtmlInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextImportsList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesDataImport.TableImpPnrInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImpDavkaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp01PracInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp51PracInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp02ZpVyplatyInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp03OsdataInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp31PrAdresaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp05ZdrPojInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp06SocPojInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp07PrijmyProhlInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp08ProhlMesInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp09DiteInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp17PomerInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp18UvazekInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp19MzdaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp20NepritInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp21SrazkaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp101UtvarInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp102StrczInfo(lpszOwnerName, lpszUsersName)
            };
        }
        public override IList<TableDefInfo> CreateContextRepDataList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesPrac.TableUzivReldpDavkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpListekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpDataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUzivDataPpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPracInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPojInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableVrepPodaniDataInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSoczdrPaymsInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanZvyhodneInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanOznameniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestExtMzdlistInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanPrijmyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanPotvrzeniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDanHlaseni5478Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDavkaUcetniInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestEldp2004Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlmesiceInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlnepritInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlnezdanInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlpomeryInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestMlpracovInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestNemDavkyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPlatbyCrInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPlatbyEuroInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrijemSspInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestRekapitInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSocialInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporHlascaInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporHlasnaInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDsporVyuctInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzDpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableMzvIisspPredpisyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestUzivSestInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVypDaneInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyplListinyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyplListkyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestVyuctZmenyInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZdravInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZmenyZpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetadInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetaoInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvs2VetaoInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetaeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvs2VetaeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetafInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetagInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetabInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestDpzvd2VetacInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPpomerPraxeInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzHlavInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313VedlInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313NeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPot313PohlInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzZpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvrzSpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKontrZdrpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKontrSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestOznamSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehlSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrilohaSocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestSlevySocpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestNemDavky09Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemNeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadNemRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatNeschInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadMatRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvdavSspInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestReldp09PracInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestReldp09PojInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehvyuctfinInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotVptInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotVptRozhobdInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPrehlZdrpInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestZadostBonusmrInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestPotvvrzOsr111Info(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazZaklInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazPpozInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazVzdvInfo(lpszOwnerName, lpszUsersName),
                new TablesZSestav.TableZsestKartazPpomInfo(lpszOwnerName, lpszUsersName)
            };
        }

        // CreateDatabaseList
        public override IList<TableDefInfo> CreateImportsTableList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                new TablesDataImport.TableImpPnrInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImpDavkaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp01PracInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp51PracInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp02ZpVyplatyInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp03OsdataInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp31PrAdresaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp05ZdrPojInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp06SocPojInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp07PrijmyProhlInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp08ProhlMesInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp09DiteInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp17PomerInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp18UvazekInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp19MzdaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp20NepritInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp21SrazkaInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp101UtvarInfo(lpszOwnerName, lpszUsersName),
                new TablesDataImport.TableImp102StrczInfo(lpszOwnerName, lpszUsersName)
            };
        }

        public override IList<TableDefInfo> CreateCompanyTableList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>();
        }

        public override IList<TableDefInfo> CreateCopyDataTableList(string lpszOwnerName, string lpszUsersName)
        {
            return new List<TableDefInfo>()
            {
                //new TablesDataStav.TableStavDatabazeInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableDetailMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableExcelUimpInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableFirmaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigVrepInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMessageInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableVrepPodaniDataInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableBankSpojInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePlatebniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePpomUkazateleInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePracUkazateleInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSberneMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyLstInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavDefaultInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigSmtpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavKonfigUcertInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavStatInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableSvatekInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniOsnovaInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPredpisyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUzivCiselnikInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableUzivatelInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableValutaKurzInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableAdresaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableDivizeStredInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrMediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrPmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableNavestiFiltrInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableOrganizaceInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePopisSlozkaTInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableSestavyHtmlInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TablePoplatkyInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyFiltrInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUdataInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUzivInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStavSemaforInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredCinzakInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaHInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableTarifniTridaTInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableUcetniPolozkyInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableValutaKurzMesInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableZemePlatkoefMesInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableStredRozpocetInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableSestavyUlstInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableUcetniMediumInfo(lpszOwnerName, lpszUsersName),
                new TablesSestavy.TableFiltrUmediaInfo(lpszOwnerName, lpszUsersName),
                new TablesFirma.TableUtvarInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TablePlatbyUtvaryInfo(lpszOwnerName, lpszUsersName),
                new TablesKonfig.TableStavMesDanInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUzivReldpDavkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableDanInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableOsdataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePojistitelInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpListekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmyMesInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePrijmySspInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableRodinaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableSrazkaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUzivDataPpomerInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableHlaseniZpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableMzdaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableNepritInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerDovRokInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerMesInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerOzpInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerPraxeInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSumInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldpDataInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracVzdelavaniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableProhlaseniInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TableUvazekInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePpomerSluzbaInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPracInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracReldp09DataPojInfo(lpszOwnerName, lpszUsersName),
                new TablesPrac.TablePracVyberAggr(lpszOwnerName, lpszUsersName),
            };
        }
        public override IList<TableDefInfo> CreateSubsetTableList(IList<string> filterList)
        {
            return filterList.Select((f) => (ALL_TABLES_DICT.Single((k) => (k.Key.Equals(f))).Value)).ToList();
        }

        public override string SchemaNamespace()
        {
            return "OKmzdySchemas";
        }
        public override string ContextName()
        {
            return "OKMZDY_CONTEXT";
        }
        public override string ContextFolder()
        {
            return "OKmzdy";
        }
    }
}
