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
                p.Prodi = new Prodi() { Uid = item.Uid, IdProdi = item.IdProdi, NamaProdi = item.NamaProdi, Jenjang = item.Jenjang, KodeProgramReguler = item.KodeProgramReguler, SingkatanProdi = item.SingkatanProdi };
                p.Prodi.Fakultas = new Fakultas() { KodeFakultas = item.KodeFakultas, NamaFakultas = item.NamaFakultas };
                listProgram.Add(p);
                listProgram = listProgram.OrderBy(pr2 => pr2.Prodi.Jenjang).OrderBy(pr2 => pr2.NamaProgram).ToList();
            }

            listProgram.ForEach(delegate (Program program)
            {
                Prodi p = new Prodi();
                p.Uid = program.Prodi.Uid;
                p.IdProdi = program.Prodi.IdProdi;
                p.Jenjang = program.Prodi.Jenjang;
                p.SingkatanProdi = program.Prodi.SingkatanProdi;
                p.NamaProdi = string.Format("{0} - {1}", program.Prodi.NamaProdi.Split(';')[0], program.Prodi.Jenjang);
                p.KodeProgramReguler = program.Prodi.KodeProgramReguler;
                listProdi.Add(p);
                listProdi = listProdi
                            .OrderBy(pr1 => pr1.Jenjang).OrderBy(pr2 => pr2.NamaProdi).ToList();

                Fakultas f = new Fakultas();
                f.KodeFakultas = program.Prodi.Fakultas.KodeFakultas;
                f.NamaFakultas = program.Prodi.Fakultas.NamaFakultas;
                p.Fakultas = f;
                listFakultas.Add(f);
                listFakultas = listFakultas.OrderBy(f1 => f1.NamaFakultas).ToList();
            });
            listFakultas = listFakultas.GroupBy(f => f.KodeFakultas).Select(g => g.First()).ToList();
            listProdi = listProdi.GroupBy(f => f.IdProdi).Select(g => g.First()).ToList();

            Organisasi.listFakultas = listFakultas;
            Organisasi.listProdi = listProdi
                                    .Where(pr => pr.SingkatanProdi != "CSSE")
                                    .ToList();
            Organisasi.listProdiPlusStudentExchange = listProdi;
            Organisasi.listProdiStudentExchange = listProdi
                                    .Where(pr => pr.SingkatanProdi == "CSSE")
                                    .ToList();
            Organisasi.listProgram = listProgram;
        }
    }
}
