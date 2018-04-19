using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFTOSQLSERVER.codigo
{
    public  class procesoDbf
    {
        public string convertirDBFtoText(string rutaArchivo,string nombreTabla) {
            
            DbfDataReader.DbfTable tabla = new DbfDataReader.DbfTable(rutaArchivo);
            DbfDataReader.DbfRecord filas = new DbfDataReader.DbfRecord(tabla);
            StreamWriter escribir = new StreamWriter(@"C:\Users\samv\Documents\Embarcadero\reporte.txt");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          SECRETARIA DE ADMINISTRACION                                                                                                                         OFICINA DE PENSIONES");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          NOMINA DE DIA DE LAS MADRES CORRESPONDIENTE AL EJERCICIO 2018");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          CLAVE PRESUPUESTAL:80100114301000001411135AEAAA0118                                                                                                              PAG:   1");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          R.F.C.       N O M B R E                             CATEG.NIV.//CVE.EMPL.");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("                                                                    PERCEPCIONES                           DEDUCCIONES           LIQUIDO          F I R M A");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            escribir.NewLine = "\r\n";
            escribir.WriteLine("-");
    
           
            int contador = 0;
            string temporal = string.Empty;
            int contador2 = 0;
            int numero = 7;
            int pagina = 2;
            while (tabla.Read(filas)) {
                contador = 0;
                foreach (var dbfValue in filas.Values)
                {
                    if (contador == 0)
                    {
                        var stringValue = dbfValue.ToString();
                        string obj =(string) dbfValue.GetValue();
                        
                        temporal = "          "+ obj + "   ";

                    }
                    if (contador == 1)
                    {
                        var stringValue = dbfValue.ToString();
                        string obj = (string)dbfValue.GetValue();
                        
                        temporal += obj+ "                  ";

                    }
                    if (contador == 2) {
                        var stringValue = dbfValue.ToString();
                        string obj =(string) dbfValue.GetValue();
                        
                        temporal += obj;
                        escribir.WriteLine(temporal);
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("                                                                     2S0101A-01A");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("                                              106 80100114301000001411135AEAAA0118    ESTIMULO DIA DE LAS MA   810.00");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("                                                                                                    ---------                   ---------               _________");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("                                                                                                       810.00                        0.00                  810.00    ______________");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("-");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("-");
                        escribir.NewLine = "\r\n";
                        escribir.WriteLine("-");
                    }
                    contador++;
                }
                temporal = "";
                contador2++;
                if (contador2 == numero) {
                    numero += 7;
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("-");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("-");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          SECRETARIA DE ADMINISTRACION                                                                                                                         OFICINA DE PENSIONES");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          NOMINA DE DIA DE LAS MADRES CORRESPONDIENTE AL EJERCICIO 2018");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          CLAVE PRESUPUESTAL:80100114301000001411135AEAAA0118                                                                                                              PAG:   "+pagina);
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          R.F.C.       N O M B R E                             CATEG.NIV.//CVE.EMPL.");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("                                                                    PERCEPCIONES                           DEDUCCIONES           LIQUIDO          F I R M A");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    escribir.NewLine = "\r\n";
                    escribir.WriteLine("-");
                  
                   
                    pagina++;
                }
            }
            escribir.Close();
            return temporal;
        }
    }
}
