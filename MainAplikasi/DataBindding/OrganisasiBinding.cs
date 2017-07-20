using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MataKuliah.DataBindding
{
    public class OrganisasiBinding
    {
        private List<Program> listProgram;
        private List<Prodi> listProdi;
        private List<Fakultas> listFakultas;

        public OrganisasiBinding(List<dynamic> listSerialized)
        {
            listProgram = new List<Program>();
            listProdi = new List<Prodi>();
            listFakultas = new List<Fakultas>();

            foreach (var item in listSerialized)
            {
                Program p = new Program();
                p.KodeProgram = item.KodeProgram;
                p.NamaProgram = item.NamaProgram;
                p.Prodi = new Prodi() { Uid = item.Uid, IdProdi = item.IdProdi, NamaProdi = item.NamaProdi, Jenjang = item.Jenjang };
                p.Prodi.Fakultas = new Fakultas() { KodeFakultas = item.KodeFakultas, NamaFakultas = item.NamaFakultas };
                listProgram.Add(p);
            }

            listProgram.ForEach(delegate (Program program)
            {
                Prodi p = new Prodi();
                p.Uid = program.Prodi.Uid;
                p.IdProdi = program.Prodi.IdProdi;
                p.Jenjang = program.Prodi.Jenjang;
                p.NamaProdi = string.Format("{0} - {1}", program.Prodi.NamaProdi.Split(';')[0], program.Prodi.Jenjang);
                listProdi.Add(p);

                Fakultas f = new Fakultas();
                f.KodeFakultas = program.Prodi.Fakultas.KodeFakultas;
                f.NamaFakultas = program.Prodi.Fakultas.NamaFakultas;
                p.Fakultas = f;
                listFakultas.Add(f);
            });
            listFakultas = listFakultas.GroupBy(f => f.KodeFakultas).Select(g => g.First()).ToList();
            listProdi = listProdi.GroupBy(f => f.IdProdi).Select(g => g.First()).ToList();

            Organisasi.listFakultas = listFakultas;
            Organisasi.listProdi = listProdi;
            Organisasi.listProgram = listProgram;
        }
    }
}
