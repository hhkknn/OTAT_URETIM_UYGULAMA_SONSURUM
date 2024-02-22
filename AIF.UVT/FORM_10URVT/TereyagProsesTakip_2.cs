using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class TereyagProsesTakip_2 : Form
    {
        //font start.tasarım
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public TereyagProsesTakip_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();
            //commit
            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = label4.Font.Size;
            label4.Resize += Form_Resize;

            initialFontSize = label5.Font.Size;
            label5.Resize += Form_Resize;

            initialFontSize = txtUretimTarihi.Font.Size;
            txtUretimTarihi.Resize += Form_Resize;

            initialFontSize = textBox2.Font.Size;
            textBox2.Resize += Form_Resize;

            initialFontSize = txtUretimSiparisNo.Font.Size;
            txtUretimSiparisNo.Resize += Form_Resize;

            initialFontSize = txtPartyNo.Font.Size;
            txtPartyNo.Resize += Form_Resize;

            initialFontSize = txtUrunTanimi.Font.Size;
            txtUrunTanimi.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = button5.Font.Size;
            button5.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = button8.Font.Size;
            button8.Resize += Form_Resize;

            initialFontSize = btnOzetEkraniDon.Font.Size;
            btnOzetEkraniDon.Resize += Form_Resize;

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            urunKodu = _urunKodu;

            txtUretimSiparisNo.Text = UretimFisNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtPartyNo.Text = partiNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            textBox2.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }

        private string tarih1 = "";

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label3.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label4.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            textBox2.Font = new Font(textBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox2.Font.Style);

            txtUretimSiparisNo.Font = new Font(txtUretimSiparisNo.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtUretimSiparisNo.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartyNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style); 

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);

            button8.Font = new Font(button8.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button8.Font.Style);

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkraniDon.Font.Style);
            ResumeLayout();
            //font end
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }
        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private SqlCommand cmd = null;
        private DataTable dtGramaj = new DataTable();
        public List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        private string urunKodu = "";
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }

        public bool Kontrol(string _kontroledilmesigerekenKolon, DataGridView dtg, DataGridView dtg2)
        {

            string temelkolon = kontrolListesis.Where(x => x.aktifKolon == _kontroledilmesigerekenKolon).Select(y => y.kontroledilmesigerekenKolon).FirstOrDefault();


            if (temelkolon != null)
            {
                string val = "";

                if (dtg2 != null)
                {
                    val = dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value.ToString();
                }
                else
                {
                    if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex > 0)
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value.ToString();
                    }
                    else if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex == 0)
                    {
                        val = "KontrolYok";
                    }
                    else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex > 0)
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value.ToString();
                    }
                    else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex == 0)
                    {
                        val = "KontrolYok";
                    }
                    else
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value.ToString();
                    }
                }

                if (val == "")
                {
                    CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                    return false;
                }
                else
                {
                    try
                    {
                        double val2 = 0;

                        if (dtg2 != null)
                        {
                            val2 = Convert.ToDouble(dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value);
                        }
                        else
                        {
                            if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex > 0)
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value);
                            }
                            else if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex == 0)
                            {
                                val2 = -1;
                            }
                            else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex > 0)
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value);
                            }
                            else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex == 0)
                            {
                                val2 = -1;
                            }
                            else
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value);
                            }
                        }
                        if (val2 == 0)
                        {
                            CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }



            return true;
        }

        private void TereyagProsesTakip_2_Load(object sender, EventArgs e)
        {
            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            //txtUretimTarihi.Text = dtTarih.ToString("dd/MM/yyyy");
            //textBox2.Text = dtTarih.ToString("dd/MM/yyyy");

            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            dtgGramaj.RowTemplate.Height = 60;

            dtgSarfMalzemeKullanim();
            //dtgDedektordenGecirme();//20230403 kapatıldı
            dtgGramajKontrol();
        }

        private void dtgSarfMalzemeKullanim()
        {
            try
            {
                string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzeme Marka ve Tedarikçi\",T1.\"U_SarfMalzemePartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS2_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgSarfMalzeme.DataSource = dt;

                dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgSarfMalzeme.EnableHeadersVisualStyles = false;
                dtgSarfMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dtgSarfMalzeme.ReadOnly = true;
                //dtgSarfMalzeme.Enabled = false;

                if (dt.Rows.Count == 0)
                {
                    //sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 inner join OITM T1 ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE where U_BatchNumber = '" + partiNo + "')";

                    #region old
                    //sql = "SELECT T1.dscription as \"Malzeme Adı\" ,(select TOP 1 CardName from IBT1 where BatchNum = t3.BatchNum and Direction = '0' order by DocDate desc) as \"Malzemenin Markası ve Tedarikçisi\",t3.BatchNum as \"Sarf Malzemesi Parti No\", sum(t3.Quantity) as \"Miktar\", T4.CntUnitMsr as \"Birim\"  FROM OWOR T0 WITH (NOLOCK)";
                    //sql += "INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.DocEntry = T1.BaseEntry ";
                    //sql += "INNER JOIN IBT1 T3 WITH (NOLOCK) ON T1.Docentry = T3.BaseEntry and T3.BaseLinNum = T1.LineNum ";
                    //sql += "INNER JOIN OITM T4 WITH (NOLOCK) ON T1.ItemCode = T4.ItemCode ";
                    //sql += "WHERE T0.[U_ISTASYON] = 'IST007' and T0.[PostDate] = '" + tarih1 + "' AND T1.BASETYPE = '202' and t3.BaseType = '60' and T4.\"ItmsGrpCod\" NOT IN('105','106','107') "; //old and T4.QryGroup1 = 'Y' ";
                    //sql += "group by T1.dscription ,t3.BatchNum,  T4.CntUnitMsr";
                    #endregion

                    #region old fth 20230403
                    //sql = "SELECT T1.dscription as \"Malzeme Adı\" ,ISNULL((select TOP 1  T09.CardName from IBT1_LINK as tt INNER JOIN OCRD T09 ON TT.CardCode = T09.CardCode where tt.BatchNum = T3.BatchNum and tt.ItemCode = T1.ItemCode  order by DocDate desc),'') as \"Malzemenin Markası ve Tedarikçisi\",t3.BatchNum as \"Sarf Malzemesi Parti No\", sum(t3.Quantity) as \"Miktar\", T4.CntUnitMsr as \"Birim\"  FROM OWOR T0 WITH (NOLOCK)";
                    //sql += "INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.DocEntry = T1.BaseEntry ";
                    //sql += "INNER JOIN OIGE T2  WITH (NOLOCK) ON T2.DocEntry = T1.DocEntry ";
                    //sql += "INNER JOIN IBT1_LINK T3 WITH (NOLOCK) ON T1.Docentry = T3.BaseEntry and T3.BaseLinNum = T1.LineNum and T3.ItemCode = T1.ItemCode ";
                    //sql += "INNER JOIN OITM T4 WITH (NOLOCK) ON T1.ItemCode = T4.ItemCode ";
                    //sql += "WHERE T0.[U_ISTASYON] = '"+istasyon+"' and T0.StartDate = '" + tarih1 + "' AND T1.BASETYPE = '202' and t3.BaseType = '60' AND T2.U_BatchNumber = '"+partiNo+"' and T4.\"ItmsGrpCod\" NOT IN('105','106','107') "; //old and T4.QryGroup1 = 'Y' ";
                    //sql += "group by T1.dscription ,t3.BatchNum,  T4.CntUnitMsr,T1.ItemCode";
                    #endregion

                    sql = "select T0.ItemName as \"Malzeme Adı\",ISNULL((SELECT TOP 1 TT.CardName FROM IBT1_LINK AS TT INNER JOIN OCRD T09 ON TT.CardCode = T09.CardCode WHERE TT.ItemCode = T0.ItemCode AND TT.BatchNum = T0.BatchNum ORDER BY TT.DocDate DESC ),'') AS \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1_LINK T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107') Order By T1.ItemName";


                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    sda = new SqlDataAdapter(cmd);
                    dttemp = new DataTable();
                    sda.Fill(dttemp);

                    foreach (DataRow dr1 in dttemp.Rows)
                    {
                        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                        DataRow dr = dt.NewRow();
                        dr["Malzeme Adı"] = dr1["Malzeme Adı"].ToString();
                        dr["Malzeme Marka ve Tedarikçi"] = dr1["Malzemenin Markası ve Tedarikçisi"].ToString();
                        dr["Sarf Malzemesi Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                        dr["Miktar"] = Convert.ToDouble(dr1["Miktar"].ToString());
                        dr["Birim"] = dr1["Birim"].ToString();

                        dt.Rows.Add(dr);
                    }

                    //DataRow dr = dt.NewRow();
                    //dr["Miktar"] = Convert.ToString("0", cultureTR);

                    //dt.Rows.Add(dr);
                }

                dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgSarfMalzeme.AutoResizeRows();
                //dtgProsesOzellikleri1.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

                foreach (DataGridViewColumn column in dtgSarfMalzeme.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgDedektordenGecirme()
        {
            try
            {
                string sql = "SELECT T1.\"U_DedektorGecirilmeKontrol\" as \"Dedektörden Geçirilme Kontrolü\" FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS2_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add();
                }

                //Commit
                dtgDedektordenKontrol.DataSource = dt;

                dtgDedektordenKontrol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgDedektordenKontrol.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgDedektordenKontrol.EnableHeadersVisualStyles = false;
                dtgDedektordenKontrol.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    //DataRow dr = dt.NewRow();
                    //dr["Parti No"] = partiNo;
                    //dr["Hamur Türü"] = txtUrunTanimi.Text;
                    //dr["Karışım Past. Sıcakligi"] = Convert.ToString("0", cultureTR);
                    //dr["Hammadde Yükleme Baş. Saat"] = Convert.ToString("0", cultureTR);
                    //dr["Hammadde Yükleme Bit. Saat"] = Convert.ToString("0", cultureTR);
                    //dr["Pişirme Mak. Indirilme Saati"] = Convert.ToString("0", cultureTR);
                    //dr["Hamurun Gramajlama Bitiş Saati"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add();
                }

                //dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                ////dtgProsesOzellikleri1.Columns["Hammadde Yükleme Bit. Saat"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                ////dtgProsesOzellikleri1.Columns["Hammadde Yükleme Bit. Saat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                ////dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                ////dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                ////dtgProsesOzellikleri1.Columns["Pişirme Mak. Indirilme Saati"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                ////dtgProsesOzellikleri1.Columns["Pişirme Mak. Indirilme Saati"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                ////dtgProsesOzellikleri1.Columns["Hamurun Gramajlama Bitiş Saati"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                ////dtgProsesOzellikleri1.Columns["Hamurun Gramajlama Bitiş Saati"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                //dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgProsesOzellikleri1.AutoResizeRows();
                ////dtgProsesOzellikleri1.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

                foreach (DataGridViewColumn column in dtgDedektordenKontrol.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgGramajKontrol()
        {
            try
            {
                string sql = "SELECT T1.\"U_UrunCesidi\" as \"Ürün Çeşidi\", T1.\"U_PartiNo\" as \"Parti No\", T1.\"U_BirinciOrnek\" as \"1.Örnek\", T1.\"U_IkinciOrnek\" as \"2.Örnek\", T1.\"U_UcuncuOrnek\" as \"3.Örnek\", T1.\"U_DorduncuOrnek\" as \"4.Örnek\", T1.\"U_BesinciOrnek\" as \"5.Örnek\", T1.\"U_AltinciOrnek\" as \"6.Örnek\", T1.\"U_YedinciOrnek\" as \"7.Örnek\"  FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS2_ANLZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);
                dtGramaj = dt;

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dtGramaj.NewRow();
                    dr["Ürün Çeşidi"] = txtUrunTanimi.Text;
                    dr["Parti No"] = txtPartyNo.Text;
                    dr["1.Örnek"] = 0;
                    dr["2.Örnek"] = 0;
                    dr["3.Örnek"] = 0;
                    dr["4.Örnek"] = 0;
                    dr["5.Örnek"] = 0;
                    dr["6.Örnek"] = 0;
                    dr["7.Örnek"] = 0;

                    dtGramaj.Rows.Add(dr);
                }

                //Commit
                dtgGramaj.DataSource = dt;

                dtgGramaj.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgGramaj.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgGramaj.EnableHeadersVisualStyles = false;
                dtgGramaj.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    //DataRow dr = dt.NewRow();
                    //dr["Parti No"] = partiNo;
                    //dr["Hamur Türü"] = txtUrunTanimi.Text;
                    //dr["Karışım Past. Sıcakligi"] = Convert.ToString("0", cultureTR);
                    //dr["Hammadde Yükleme Baş. Saat"] = Convert.ToString("0", cultureTR);
                    //dr["Hammadde Yükleme Bit. Saat"] = Convert.ToString("0", cultureTR);
                    //dr["Pişirme Mak. Indirilme Saati"] = Convert.ToString("0", cultureTR);
                    //dr["Hamurun Gramajlama Bitiş Saati"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add();
                }

                dtgGramaj.Columns["1.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["1.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["2.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["2.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["3.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["3.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["4.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["4.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["5.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["5.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["6.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["6.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.Columns["7.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramaj.Columns["7.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgGramaj.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgGramaj.AutoResizeRows();
                //dtgProsesOzellikleri1.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

                dtgGramaj.Columns["Ürün Çeşidi"].HeaderCell.Style.BackColor = Color.LimeGreen;
                dtgGramaj.Columns["Parti No"].HeaderCell.Style.BackColor = Color.LimeGreen;

                dtgGramaj.Columns["Ürün Çeşidi"].ReadOnly = true;
                dtgGramaj.Columns["Parti No"].ReadOnly = true;

                foreach (DataGridViewColumn column in dtgGramaj.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }


                #region Kontrol listesi oluşturma 

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Ürün Çeşidi",
                    kontroledilmesigerekenKolon = "7.Örnek"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Parti No",
                    kontroledilmesigerekenKolon = "Ürün Çeşidi"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "1.Örnek",
                    kontroledilmesigerekenKolon = "Parti No"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "2.Örnek",
                    kontroledilmesigerekenKolon = "1.Örnek"
                });

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "3.Örnek",
                    kontroledilmesigerekenKolon = "2.Örnek"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "4.Örnek",
                    kontroledilmesigerekenKolon = "3.Örnek"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "5.Örnek",
                    kontroledilmesigerekenKolon = "4.Örnek"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "6.Örnek",
                    kontroledilmesigerekenKolon = "5.Örnek"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "7.Örnek",
                    kontroledilmesigerekenKolon = "6.Örnek"
                });

                #endregion

                dtgGramaj.RowTemplate.Height = 60;

            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgGramaj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bool cvp = true;

                cvp = Kontrol(dtgGramaj.Columns[e.ColumnIndex].Name, dtgGramaj, null);

                if (!cvp)
                {
                    return;
                }

                if (dtgGramaj.Columns[e.ColumnIndex].Name == "1.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "2.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "3.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "4.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "5.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "6.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "7.Örnek")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgGramaj);
                    n.ShowDialog();

                    #region Süt Gönderim Saat Kontrolleri

                    //var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();
                    //var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Bitiş Saati"].Value.ToString();

                    //if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    //{
                    //    TimeSpan girisCikisFarki = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                    //}
                    //else
                    //{
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = "0";
                    //}

                    //ProsesOzellikleri1Topla();

                    #endregion Süt Gönderim Saat Kontrolleri
                }
                #region kapatıldı 20230403
                //else if (dtgGramaj.Columns[e.ColumnIndex].Name == "Ürün Çeşidi")
                //{
                //    string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='5'";
                //    cmd = new SqlCommand(sql_AnalizParam, Connection.sql);

                //    if (Connection.sql.State != ConnectionState.Open)
                //        Connection.sql.Open();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    DataTable dt_Sorgu = new DataTable();
                //    sda.Fill(dt_Sorgu);

                //    //dtgSecim.DataSource = dt;
                //    //dtSecim = dt;

                //    Connection.sql.Close();

                //    if (dt_Sorgu.Rows.Count > 0)
                //    {
                //        string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "' ";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                //        SelectList selectList = new SelectList(sql1, dtgGramaj, -1, 0, _autoresizerow: false);
                //        selectList.ShowDialog();

                //        var sonSatir = dtgGramaj.Rows[dtgGramaj.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                //        if (sonSatir != "")
                //        {
                //            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //            DataRow dr = dtGramaj.NewRow();
                //            dr["Ürün Çeşidi"] = "";
                //            dr["Parti No"] = "";
                //            dr["1.Örnek"] = 0;
                //            dr["2.Örnek"] = 0;
                //            dr["3.Örnek"] = 0;
                //            dr["4.Örnek"] = 0;
                //            dr["5.Örnek"] = 0;
                //            dr["6.Örnek"] = 0;
                //            dr["7.Örnek"] = 0;

                //            dtGramaj.Rows.Add(dr);
                //        }
                //    } 
                //}
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgDedektordenKontrol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql1 = "Select '0' as \"Kod\",'Uygun Değil' as \"Aciklama\" ";
            sql1 += " UNION ALL ";
            sql1 += "Select '1' as \"Kod\",'Uygun' as \"Aciklama\" ";

            SelectList selectList = new SelectList(sql1, dtgDedektordenKontrol, -1, e.ColumnIndex, _autoresizerow: false);
            selectList.ShowDialog();
        }

        private void btnOzetEkraniDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TereyagProsesTakipAnaliz2 nesne = new TereyagProsesTakipAnaliz2();

                Tereyag2SarfMalzemeKullanim tereyag2SarfMalzemeKullanim = new Tereyag2SarfMalzemeKullanim();
                List<Tereyag2SarfMalzemeKullanim> tereyag2SarfMalzemeKullanims = new List<Tereyag2SarfMalzemeKullanim>();

                //Tereyag2DedektorGecirilmeKontrol tereyag2DedektorGecirilmeKontrol = new Tereyag2DedektorGecirilmeKontrol();
                //List<Tereyag2DedektorGecirilmeKontrol> tereyag2DedektorGecirilmeKontrols = new List<Tereyag2DedektorGecirilmeKontrol>();

                Tereyag2GramajKontrol tereyag2GramajKontrol = new Tereyag2GramajKontrol();
                List<Tereyag2GramajKontrol> tereyag2GramajKontrols = new List<Tereyag2GramajKontrol>();

                nesne.PartiNo = txtPartyNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.KalemKodu = urunKodu;
                nesne.KalemTanimi = txtUrunTanimi.Text;

                nesne.UretimTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);
                nesne.PaketlemeTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);

                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    tereyag2SarfMalzemeKullanim = new Tereyag2SarfMalzemeKullanim();

                    tereyag2SarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tereyag2SarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzeme Marka ve Tedarikçi"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Marka ve Tedarikçi"].Value.ToString();
                    tereyag2SarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    tereyag2SarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tereyag2SarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tereyag2SarfMalzemeKullanims.Add(tereyag2SarfMalzemeKullanim);
                }

                nesne.tereyag2SarfMalzemeKullanims_Detay = tereyag2SarfMalzemeKullanims.ToArray();

                //foreach (DataGridViewRow dr in dtgDedektordenKontrol.Rows)
                //{
                //    tereyag2DedektorGecirilmeKontrol = new Tereyag2DedektorGecirilmeKontrol();
                //    tereyag2DedektorGecirilmeKontrol.UretilenMetalDedektördenGecirilmeKontrolu = dr.Cells["Dedektörden Geçirilme Kontrolü"].Value == DBNull.Value ? "" : dr.Cells["Dedektörden Geçirilme Kontrolü"].Value.ToString();

                //    tereyag2DedektorGecirilmeKontrols.Add(tereyag2DedektorGecirilmeKontrol);
                //}

                //nesne.tereyag2DedektorGecirilmeKontrols = tereyag2DedektorGecirilmeKontrols.ToArray();

                foreach (DataGridViewRow dr in dtgGramaj.Rows)
                {
                    tereyag2GramajKontrol = new Tereyag2GramajKontrol();
                    tereyag2GramajKontrol.UrunCesidi = dr.Cells["Ürün Çeşidi"].Value == DBNull.Value ? "" : dr.Cells["Ürün Çeşidi"].Value.ToString();
                    tereyag2GramajKontrol.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    tereyag2GramajKontrol.BirinciOrnek = dr.Cells["1.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Örnek"].Value);
                    tereyag2GramajKontrol.IkinciOrnek = dr.Cells["2.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Örnek"].Value);
                    tereyag2GramajKontrol.UcuncuOrnek = dr.Cells["3.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Örnek"].Value);
                    tereyag2GramajKontrol.DorduncuOrnek = dr.Cells["4.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Örnek"].Value);
                    tereyag2GramajKontrol.BesinciOrnek = dr.Cells["5.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Örnek"].Value);
                    tereyag2GramajKontrol.AltinciOrnek = dr.Cells["6.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["6.Örnek"].Value);
                    tereyag2GramajKontrol.YedinciOrnek = dr.Cells["7.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["7.Örnek"].Value);

                    tereyag2GramajKontrols.Add(tereyag2GramajKontrol);
                }

                nesne.tereyag2GramajKontrols = tereyag2GramajKontrols.ToArray();

                var resp = client.AddOrUpdateTereyagProsesAnalizTakip2(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkraniDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

    }
}