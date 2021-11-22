﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaNegocio
{
    public class N_Asignacion
    {
        Excel excel;
        int row = 0;
        int col = 0;
        List<Carga> cargas = new List<Carga>();

        public void Procesar(string path)
        {
            excel = new Excel(path, 1);
            while (row != -1 && row < excel.nroRows())
            {
                ActualizarIndexCarga();
                ProcesarCarga();
                Console.WriteLine("");
            }
        }
        private void ActualizarIndexCarga()
        {
            for (int i = row; i < excel.nroRows(); i++)
            {
                for (int j = 0; j < excel.nroCols(); j++)
                {
                    string cell = excel.ReadCell(i, j);
                    if (cell != null && cell.ToUpper() == "CARRERA")
                    {

                        row = i;
                        col = j-1;
                        return;
                    }
                }
            }
            row = -1;
        }
        private void ProcesarCarga()
        {
            // Nombre de docente
            string docente = excel.ReadCell(row, col+2);
            row++;
            // Carga
            for (int i = row; i < excel.nroRows(); i++)
            {
                bool nuevaCarga = true;
                List<string> lista = new List<string>();
                if (excel.ReadCell(i, col) == "")
                    nuevaCarga = false;

                for (int j = col; j < col+13; j++)
                {
                    string cell = excel.ReadCell(i, j);
                    if (cell.ToUpper() == "CARRERA")
                    {
                        row = i;
                        return;
                    }

                    lista.Add(cell);
                }
                if (nuevaCarga)
                {
                    Carga carga1 = new Carga
                    {
                        CodCurso = lista[0],
                        Coddocente = docente,
                        Carrera = lista[1],
                        NombreCurso = lista[2],
                        Creditos = lista[3],
                        Tipo = lista[4],
                        Grupo = lista[5],
                        HT = Int32.Parse(lista[6]),
                        HP = Int32.Parse(lista[7]),
                        Dia = lista[8],
                        HR_inicio = Int32.Parse(lista[9]),
                        HR_fin = Int32.Parse(lista[10]),
                        Aula = lista[11],
                        Matriculados = Int32.Parse(lista[12]),
                    };
                    cargas.Add(carga1);
                    carga1.Guardar();
                    Console.WriteLine(carga1);
                }
                if(i == excel.nroRows() - 1)
                    row = -1;
            }
        }
        public List<Carga> getCargas()
        {
            return cargas;
        }
    }
}
