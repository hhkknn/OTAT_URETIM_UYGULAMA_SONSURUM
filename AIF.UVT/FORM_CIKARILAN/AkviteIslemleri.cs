using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AkviteIslemleri : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public AkviteIslemleri(string _type, string _kullaniciid, string _rota, string _stageid, string _uretimFisNo, string _btnType, string _partiNo, string _urunKodu, string _uretimdengirisYap, int _row, int _width, int _height)
        {
            type = _type;
            kullaniciid = _kullaniciid;
            rota = _rota;
            stageid = _stageid;
            uretimfisNo = _uretimFisNo;
            btnType = _btnType;
            partiNo = _partiNo;
            urunKodu = _urunKodu;
            //width = _width;
            //height = _height;
            row = _row;
            //partimiktari = _partiMiktari;
            //belgeMiktari = _belgemiktar;
            uretimdengirisYap = _uretimdengirisYap;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            // Değişkenlerin başlangıç boyutunu ayarlar
            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            //font end
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Geçerli yazı tipi boyutunu hesaplar
            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button3.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button4.Font.Style);
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

        private string type;
        private string kullaniciid;
        private string rota;
        private string stageid;
        private string uretimfisNo;
        private string partiNo;
        private string uretimdengirisYap;
        private string urunKodu;
        private int width = 0;
        private int height = 0;
        private int row = 0;

        //private double partimiktari = 0;
        //private double belgeMiktari = 0;
        private string btnType; //1-Başlat 2-Duraklat

        private DataTable dt = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt99 = new DataTable();
        private DataTable dt88 = new DataTable();
        private DataTable dtAktiviteCalisanlari = new DataTable();
        private DataTable dtDevamEdenAktiviteCalisanlari = new DataTable();
        private string personelid = "";
        private string queryaktivite = "";
        private string sql = "";
        private SqlCommand cmd = null;
        private SqlDataAdapter sda = null;
        private DataGridViewCheckBoxColumn checkColumn = null;
        private DataGridViewCheckBoxColumn checkColumn2 = null;

        private DataTable BekleyenlerdeCalisanKisileriSil(DataTable data)
        {
            DataTable tempdt = data.Copy();
            tempdt.Rows.Clear();
            foreach (DataRow dataRow in data.Rows)
            {
                personelid = dataRow["Personel No"].ToString();

                queryaktivite = "Select * from \"OCLG\" where \"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and (\"Status\" = '2' or \"Status\" = '1') and \"AttendEmpl\" = '" + personelid + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";

                cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt99);

                if (dt99.Rows.Count == 0)
                {
                    tempdt.Rows.Add(dataRow.ItemArray);
                }

                dt99 = new DataTable();
            }

            return tempdt;
        }

        private DataTable AktifCalisanlariGetir(DataTable data)
        {
            DataTable tempdt = data.Copy();
            tempdt.Rows.Clear();
            string status = "2";
            foreach (DataRow dataRow in data.Rows)
            {
                personelid = dataRow["Personel No"].ToString();

                queryaktivite = "Select * from \"OCLG\" where \"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"Status\" = '" + status + "' and \"AttendEmpl\" = '" + personelid + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";

                cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt99);

                if (dt99.Rows.Count > 0)
                {
                    var saat = dt99.Rows[0]["BeginTime"].ToString().PadLeft(4, '0');
                    var AktiviteNo = dt99.Rows[0]["ClgCode"].ToString();
                    tempdt.Rows.Add(dataRow.ItemArray);

                    tempdt.Rows[tempdt.Rows.Count - 1]["Saat"] = saat.Substring(0, 2);
                    tempdt.Rows[tempdt.Rows.Count - 1]["Dakika"] = saat.Substring(2, 2);
                    tempdt.Rows[tempdt.Rows.Count - 1]["AktiviteNo"] = AktiviteNo;
                }

                dt99 = new DataTable();
            }

            return tempdt;
        }

        private DataTable DuraklatilmisCalisanlariGetir(DataTable data)
        {
            DataTable tempdt = data.Copy();
            tempdt.Rows.Clear();
            string status = "1";

            //foreach (DataRow dataRow in data.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            queryaktivite = "Select * from \"OCLG\" as T0 INNER JOIN OHEM T1 ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T0.\"Status\" = '" + status + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "' order by \"ClgCode\" desc";

            cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt99);

            foreach (DataRow item in dt99.Rows)
            {
                var clgCode = item["ClgCode"].ToString();
                queryaktivite = "Select * from \"OCLG\" as T0 INNER JOIN OHEM T1 ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"AttendEmpl\" = '" + item["AttendEmpl"].ToString() + "' and \"ClgCode\" > '" + clgCode + "'";
                cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt88);

                if (dt88.Rows.Count == 0)
                {
                    var saat = item["BeginTime"].ToString().PadLeft(4, '0');
                    var AktiviteNo = item["ClgCode"].ToString();
                    var PersonelNo = item["empID"].ToString();
                    var PersonelAdi = item["firstName"].ToString() + " " + item["lastName"].ToString();

                    DataRow dr = tempdt.NewRow();
                    dr["AktiviteNo"] = AktiviteNo;
                    dr["Saat"] = saat.Substring(0, 2);
                    dr["Dakika"] = saat.Substring(2, 2);
                    dr["Personel No"] = PersonelNo;
                    dr["Personel Adı"] = PersonelAdi;

                    tempdt.Rows.Add(dr);
                }
            }

            dt99 = new DataTable();
            //}

            return tempdt;
        }

        private DataTable AktifCalisanlariGetir_2(DataTable data)
        {
            DataTable tempdt = data.Copy();
            tempdt.Rows.Clear();
            string status = "2";
            //foreach (DataRow dataRow in data.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            queryaktivite = "Select * from \"OCLG\" as T0 INNER JOIN OHEM T1 ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T0.\"Status\" = '" + status + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt99);

            foreach (DataRow dataRow in dt99.Rows)
            {
                var saat = dataRow["BeginTime"].ToString().PadLeft(4, '0');
                var AktiviteNo = dataRow["ClgCode"].ToString();
                var PersonelNo = dataRow["empID"].ToString();
                var PersonelAdi = dataRow["firstName"].ToString() + " " + dataRow["lastName"].ToString();

                DataRow dr = tempdt.NewRow();
                dr["AktiviteNo"] = AktiviteNo;
                dr["Saat"] = saat.Substring(0, 2);
                dr["Dakika"] = saat.Substring(2, 2);
                dr["Personel No"] = PersonelNo;
                dr["Personel Adı"] = PersonelAdi;

                tempdt.Rows.Add(dr);
            }

            dt99 = new DataTable();
            //}

            return tempdt;
        }

        private DataTable TamamlananlariGetir(DataTable data)
        {
            DataTable tempdt = data.Copy();
            tempdt.Rows.Clear();
            string status = "-3";
            //foreach (DataRow dataRow in data.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            queryaktivite = "Select * from \"OCLG\" as T0 INNER JOIN OHEM T1 ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T0.\"Status\" = '" + status + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt99);

            foreach (DataRow dataRow in dt99.Rows)
            {
                var saat = dataRow["EndTime"].ToString().PadLeft(4, '0');
                var AktiviteNo = dataRow["ClgCode"].ToString();
                var PersonelNo = dataRow["empID"].ToString();
                var PersonelAdi = dataRow["firstName"].ToString() + " " + dataRow["lastName"].ToString();

                DataRow dr = tempdt.NewRow();
                dr["AktiviteNo"] = AktiviteNo;
                dr["Saat"] = saat.Substring(0, 2);
                dr["Dakika"] = saat.Substring(2, 2);
                dr["Personel No"] = PersonelNo;
                dr["Personel Adı"] = PersonelAdi;

                tempdt.Rows.Add(dr);
            }

            dt99 = new DataTable();
            //}

            return tempdt;
        }

        private int SaatGetir(string clgCode)
        {
            queryaktivite = "Select \"BeginTime\" from \"OCLG\" where \"ClgCode\" = '" + clgCode + "'";

            cmd = new SqlCommand(queryaktivite, Giris.sqlConnection_Uvt);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt99);

            if (dt99.Rows.Count > 0)
            {
                string aaaa = dt99.Rows[0]["BeginTime"].ToString().PadLeft(4, '0');
                int saat = Convert.ToInt32(aaaa);
                return saat;
            }

            return 0;
        }

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.FalseValue = true;
            checkColumn.HeaderText = "Seçim";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dataGridView2.Columns.Add(checkColumn);

            checkColumn2 = new DataGridViewCheckBoxColumn();

            checkColumn2.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn2.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn2.FalseValue = true;
            checkColumn2.HeaderText = "Seçim";
            checkColumn2.Name = "ScmCheck";
            checkColumn2.TrueValue = true;
            checkColumn2.FalseValue = false;
            dataGridView1.Columns.Add(checkColumn2);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns["ScmCheck"].DisplayIndex = 0;
            dataGridView2.Columns["Personel No"].DisplayIndex = 1;
            dataGridView2.Columns["Personel Adı"].DisplayIndex = 2;
            dataGridView2.Columns["Saat"].DisplayIndex = 3;
            dataGridView2.Columns["Dakika"].DisplayIndex = 4;
            dataGridView2.Columns["AktiviteNo"].DisplayIndex = 5;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["ScmCheck"].DisplayIndex = 0;
            dataGridView1.Columns["Personel No"].DisplayIndex = 1;
            dataGridView1.Columns["Personel Adı"].DisplayIndex = 2;
            dataGridView1.Columns["Saat"].DisplayIndex = 3;
            dataGridView1.Columns["Dakika"].DisplayIndex = 4;
            dataGridView1.Columns["AktiviteNo"].DisplayIndex = 5;
        }

        private void AkviteIslemleri_Load(object sender, EventArgs e)
        {
            try
            {
                if (btnType == "1")
                {
                    #region Başlatma

                    string field = "U_" + type;
                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                    cmd = new SqlCommand(sql, Giris.sqlConnection_Uvt);

                    if (Giris.sqlConnection_Uvt.State != ConnectionState.Open)
                        Giris.sqlConnection_Uvt.Open();

                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    dt2 = AktifCalisanlariGetir(dt);
                    dataGridView1.DataSource = dt2;

                    dt = BekleyenlerdeCalisanKisileriSil(dt);

                    dataGridView2.DataSource = dt;
                    //dt2 = dt.Copy();
                    //dt2.Rows.Clear();

                    Checkboxolustur();

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);

                    #endregion Başlatma
                }
                else if (btnType == "2")
                {
                    string field = "U_" + type;
                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                    cmd = new SqlCommand(sql, Giris.sqlConnection_Uvt);

                    if (Giris.sqlConnection_Uvt.State != ConnectionState.Open)
                        Giris.sqlConnection_Uvt.Open();

                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    dt2 = AktifCalisanlariGetir(dt);
                    dataGridView1.DataSource = dt2;

                    dt = dt2.Copy();
                    dt.Rows.Clear();

                    dt = DuraklatilmisCalisanlariGetir(dt);

                    dataGridView2.DataSource = dt;

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].ReadOnly = true;
                    }

                    Checkboxolustur();

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);
                }
                else if (btnType == "3")
                {
                    string field = "U_" + type;
                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                    cmd = new SqlCommand(sql, Giris.sqlConnection_Uvt);

                    if (Giris.sqlConnection_Uvt.State != ConnectionState.Open)
                        Giris.sqlConnection_Uvt.Open();

                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    dt2 = AktifCalisanlariGetir(dt);
                    dataGridView1.DataSource = dt2;

                    dt = dt2.Copy();
                    dt.Rows.Clear();

                    dt = DuraklatilmisCalisanlariGetir(dt);

                    dataGridView2.DataSource = dt;

                    Checkboxolustur();

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);
                }
                else if (btnType == "4")
                {
                    string field = "U_" + type;
                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                    cmd = new SqlCommand(sql, Giris.sqlConnection_Uvt);

                    if (Giris.sqlConnection_Uvt.State != ConnectionState.Open)
                        Giris.sqlConnection_Uvt.Open();

                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    dt2 = AktifCalisanlariGetir_2(dt);
                    dataGridView1.DataSource = dt2;

                    //dt = BekleyenlerdeCalisanKisileriSil(dt);

                    dt = dt2.Copy();
                    dt.Rows.Clear();

                    dt = TamamlananlariGetir(dt);

                    dataGridView2.DataSource = dt;

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].ReadOnly = true;
                    }

                    //dataGridView2.DataSource = dt;
                    Checkboxolustur();

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Aktivite ekranı açılırken hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void setFormatGrid(DataGridView dtg, int value)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            for (int i = 0; i <= dtg.Rows.Count - 1; i++)
            {
                var aa = dtg.RowTemplate.Height;
                dtg.Rows[i].Height = aa + value;
                if (i % 2 == 0)
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

                dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
            for (int i = 0; i <= dtg.Columns.Count - 1; i++)
            {
                dtg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnType == "1") //Yalnızca başlatma işleminde kontrol ediliyor.
                {
                    DataGridViewCheckBoxCell cell = this.dataGridView1.CurrentCell as DataGridViewCheckBoxCell;

                    if (cell != null && !cell.ReadOnly)
                    {
                        cell.Value = cell.Value == null || !((bool)cell.Value);
                        string aktiviteno = dataGridView1.Rows[e.RowIndex].Cells["AktiviteNo"].Value.ToString();
                        if (aktiviteno != "" && (bool)cell.Value == true)
                        {
                            CustomMsgBtn.Show("Devam edilen çalışanlar için seçim gerçekleştirilemez.", "UYARI", "TAMAM");
                            dataGridView1.CurrentRow.Cells["ScmCheck"].Value = false;
                            this.dataGridView1.RefreshEdit();
                            this.dataGridView1.NotifyCurrentCellDirty(true);
                            //cell.Value = cell.FalseValue;
                            //dataGridView1.Rows[e.RowIndex].Cells["ScmCheck"].e
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Devam eden çalışanlar için işlem gerçekleştirilirken hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnType == "1" || btnType == "3")
                {
                    #region Başlat

                    List<Tuple<int, string, string, string, string>> bekleyenPersonels = new List<Tuple<int, string, string, string, string>>();
                    for (int rows = 0; rows < dataGridView2.Rows.Count; rows++)
                    {
                        string check = dataGridView2.Rows[rows].Cells["ScmCheck"].Value != null ? dataGridView2.Rows[rows].Cells["ScmCheck"].Value.ToString() : "False";
                        if (check == "True")
                        {
                            string personeid = dataGridView2.Rows[rows].Cells["Personel No"].Value.ToString();
                            string adi = dataGridView2.Rows[rows].Cells["Personel Adı"].Value.ToString();
                            bekleyenPersonels.Add(Tuple.Create(rows, personeid, adi, "", ""));
                        }
                    }

                    //SaatTarihGirisi f = new SaatTarihGirisi(bekleyenPersonels);
                    //f.ShowDialog();

                    if (SaatTarihGirisi.dialogResult == "Ok")
                    {
                        //Soldaki dtg'den sağdakine gönderme
                        for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                        {
                            string check = dataGridView2.Rows[i].Cells["ScmCheck"].Value != null ? dataGridView2.Rows[i].Cells["ScmCheck"].Value.ToString() : "False";
                            if (check == "True")
                            {
                                DataRow dr = dt2.NewRow();
                                dr["Personel No"] = dataGridView2.Rows[i].Cells["Personel No"].Value;
                                dr["Personel Adı"] = dataGridView2.Rows[i].Cells["Personel Adı"].Value;
                                dr["Saat"] = SaatTarihGirisi.saat;
                                dr["Dakika"] = SaatTarihGirisi.dakika;

                                dt2.Rows.Add(dr);

                                DataRow[] drr = dt.Select("[Personel No]='" + dataGridView2.Rows[i].Cells["Personel No"].Value + "' ");
                                drr[0].Delete();
                            }
                        }

                        dt.AcceptChanges();
                        dataGridView2.DataSource = dt;

                        dataGridView1.DataSource = dt2;

                        setFormatGrid(dataGridView1, 30);
                        setFormatGrid(dataGridView2, 30);
                    }

                    #endregion Başlat
                }
                else if (btnType == "2")
                {
                    #region Duraklat

                    //Soldaki dtg'den sağdakine gönderme
                    for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                    {
                        string check = dataGridView2.Rows[i].Cells["ScmCheck"].Value != null ? dataGridView2.Rows[i].Cells["ScmCheck"].Value.ToString() : "False";
                        if (check == "True")
                        {
                            DataRow dr = dt2.NewRow();
                            dr["Personel No"] = dataGridView2.Rows[i].Cells["Personel No"].Value;
                            dr["Personel Adı"] = dataGridView2.Rows[i].Cells["Personel Adı"].Value;
                            dr["AktiviteNo"] = dataGridView2.Rows[i].Cells["AktiviteNo"].Value;

                            int saat = SaatGetir(dataGridView2.Rows[i].Cells["AktiviteNo"].Value.ToString());
                            dr["Saat"] = saat.ToString().PadLeft(4, '0').Substring(0, 2);
                            dr["Dakika"] = saat.ToString().PadLeft(4, '0').Substring(2, 2);

                            dt2.Rows.Add(dr);

                            DataRow[] drr = dt.Select("[Personel No]='" + dataGridView2.Rows[i].Cells["Personel No"].Value + "' ");
                            drr[0].Delete();
                        }
                    }

                    dt.AcceptChanges();
                    dataGridView2.DataSource = dt;

                    dataGridView1.DataSource = dt2;

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);

                    #endregion Duraklat
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata Kodu: AKT001 Hata açıklaması " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight);
            banaAitİsler.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Response response = new Response();
            //    if (btnType == "1" || btnType == "3")
            //    {
            //        UVTServiceSoapClient client = new UVTServiceSoapClient();
            //        UVTService.Contacts contacts = new UVTService.Contacts();
            //        RotaDurum rotaDurum = new RotaDurum();
            //        foreach (DataRow dataRow in dt2.Rows)
            //        {
            //            string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

            //            if (aktiviteNo == "")
            //            {
            //                string id = dataRow["Personel No"].ToString();
            //                string saat = dataRow["Saat"].ToString();
            //                string dakika = dataRow["Dakika"].ToString();
            //                //var a = oContats.GetByKey(Convert.ToInt32(id));

            //                DateTime baslangic = DateTime.Now;
            //                TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
            //                baslangic = baslangic.Date + t;

            //                contacts.ContactType = "2";
            //                contacts.ContactSubType = "-1";
            //                contacts.StartTime = baslangic;
            //                contacts.Status = "2";
            //                contacts.ContactId = id;
            //                contacts.PartiNo = partiNo;
            //                contacts.RotaKodu = rota;

            //                response = client.AddContacts(contacts, Giris.dbName, Giris.mKodValue);

            //                rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
            //                rotaDurum.RotaKodu = rota;
            //                rotaDurum.PartiNo = partiNo;
            //                rotaDurum.DurumKodu = "2";
            //                rotaDurum.DurumAciklamasi = "Devam Ediyor";

            //                var resp = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);

            //                CustomMsgBtn.Show(response.Description, "UYARI", "TAMAM");
            //            }
            //        }
            //        if (response.Value == 0)
            //        {
            //            button1.PerformClick();
            //        }
            //    }
            //    else if (btnType == "2" || btnType == "4")
            //    {
            //        UVTService.UVTServiceSoapClient client = new UVTService.UVTServiceSoapClient();
            //        UVTService.Contacts contacts = new UVTService.Contacts();
            //        RotaDurum rotaDurum = new RotaDurum();
            //        foreach (DataRow dataRow in dt.Rows)
            //        {
            //            string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

            //            if (aktiviteNo != "")
            //            {
            //                string id = dataRow["Personel No"].ToString();
            //                string saat = dataRow["Saat"].ToString();
            //                string dakika = dataRow["Dakika"].ToString();

            //                DateTime bitis = DateTime.Now;
            //                TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
            //                bitis = bitis.Date + t;

            //                contacts.ClgCode = aktiviteNo;
            //                contacts.EndTime = bitis;
            //                if (btnType == "2")
            //                    contacts.Status = "1";
            //                else if (btnType == "4")
            //                    contacts.Status = "-3";

            //                contacts.Closed = "Y";

            //                var resp = client.UpdateContacts(contacts, Giris.dbName, Giris.mKodValue);

            //                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            //                if (btnType == "4")
            //                {
            //                    rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
            //                    rotaDurum.RotaKodu = rota;
            //                    rotaDurum.PartiNo = partiNo;
            //                    rotaDurum.DurumKodu = "3";
            //                    rotaDurum.DurumAciklamasi = "Tamamlandı";

            //                    resp = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);
            //                }
            //            }
            //        }

            //        if (uretimdengirisYap == "Y")
            //        {
            //            UretimdenGirisMiktari f = new UretimdenGirisMiktari(uretimfisNo, 0, partiNo, 0, 0, initialWidth, initialHeight, "", "", "","");
            //            f.ShowDialog();

            //            if (UretimdenGirisMiktari.dialogResult == "Ok")
            //            {
            //            }
            //        }

            //        if (response.Value == 0)
            //        {
            //            button1.PerformClick();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CustomMsgBtn.Show("Onaylama işlemi sırasında hata oluştu. Hata Kodu : AKT002 " + ex.Message, "UYARI", "TAMAM");
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnType == "1" || btnType == "3")
                {
                    //Sağdaki Dtg'den Soldakine gönderme
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        string check = dataGridView1.Rows[i].Cells["ScmCheck"].Value != null ? dataGridView1.Rows[i].Cells["ScmCheck"].Value.ToString() : "False";
                        if (check == "True")
                        {
                            DataRow dr = dt.NewRow();
                            dr["Personel No"] = dataGridView1.Rows[i].Cells["Personel No"].Value;
                            dr["Personel Adı"] = dataGridView1.Rows[i].Cells["Personel Adı"].Value;

                            dt.Rows.Add(dr);

                            DataRow[] drr = dt2.Select("[Personel No]='" + dataGridView1.Rows[i].Cells["Personel No"].Value + "' ");
                            drr[0].Delete();
                        }
                    }

                    dt2.AcceptChanges();
                    dataGridView1.DataSource = dt2;

                    dataGridView2.DataSource = dt;

                    setFormatGrid(dataGridView1, 30);
                    setFormatGrid(dataGridView2, 30);
                }
                else if (btnType == "2" || btnType == "4")
                {
                    bool secili = false;
                    List<Tuple<int, string, string, string, string>> bekleyenPersonels = new List<Tuple<int, string, string, string, string>>();
                    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                    {
                        string check = dataGridView1.Rows[rows].Cells["ScmCheck"].Value != null ? dataGridView1.Rows[rows].Cells["ScmCheck"].Value.ToString() : "False";
                        if (check == "True")
                        {
                            string personeid = dataGridView1.Rows[rows].Cells["Personel No"].Value.ToString();
                            string adi = dataGridView1.Rows[rows].Cells["Personel Adı"].Value.ToString();
                            bekleyenPersonels.Add(Tuple.Create(rows, personeid, adi, "", ""));
                            secili = true;
                        }
                    }

                    if (secili)
                    {
                        //SaatTarihGirisi f = new SaatTarihGirisi(bekleyenPersonels);
                        //f.ShowDialog();

                        if (SaatTarihGirisi.dialogResult == "Ok")
                        {
                            //Sağdaki Dtg'den Soldakine gönderme
                            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                            {
                                string check = dataGridView1.Rows[i].Cells["ScmCheck"].Value != null ? dataGridView1.Rows[i].Cells["ScmCheck"].Value.ToString() : "False";
                                if (check == "True")
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["Personel No"] = dataGridView1.Rows[i].Cells["Personel No"].Value;
                                    dr["Personel Adı"] = dataGridView1.Rows[i].Cells["Personel Adı"].Value;
                                    dr["Saat"] = SaatTarihGirisi.saat;
                                    dr["Dakika"] = SaatTarihGirisi.dakika;
                                    dr["AktiviteNo"] = dataGridView1.Rows[i].Cells["AktiviteNo"].Value;

                                    dt.Rows.Add(dr);

                                    DataRow[] drr = dt2.Select("[Personel No]='" + dataGridView1.Rows[i].Cells["Personel No"].Value + "' ");
                                    drr[0].Delete();
                                }
                            }

                            dt2.AcceptChanges();
                            dataGridView1.DataSource = dt2;

                            dataGridView2.DataSource = dt;

                            setFormatGrid(dataGridView1, 30);
                            setFormatGrid(dataGridView2, 30);
                        }
                    }
                    secili = false;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. AKT004 " + ex.Message, "UYARI", "TAMAM");
            }
        }
    }
}