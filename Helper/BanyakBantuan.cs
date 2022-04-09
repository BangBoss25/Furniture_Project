using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Helper
{
    public class BanyakBantuan
    {
        public int BuatOtp()
        {
            Random start = new Random();

            int valuenya = start.Next(1000, 9999);

            return valuenya;
        }

        public Object ResponAPI(int respon_code, string message, Object data)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "GAGAL",
                respon_code,
                message,
                data
            };
        }

        public int CodeOk = 200;

        public int CodeBadRequest = 400;

        public int CodeInternalServerError = 500;

        public string PesanGetSukses(string psn)
        {
            return "Berhasil ambil data " + psn;
        }

        public string PesanTambahSukses(string psn)
        {
            return "Berhasil menambah data " + psn;
        }

        public string PesanUbahSukses(string psn)
        {
            return "Berhasil ubah data " + psn;
        }

        public string PesanHapusSukses(string psn)
        {
            return "Berhasil hapus data " + psn;
        }

        public string PesanTidakDitemukan(string psn)
        {
            return "Data " + psn + " tidak ditemukan";
        }

        public string PesanInputanSalah(string psn)
        {
            return "Inputan untuk data " + psn + " salah";
        }
    }
}
