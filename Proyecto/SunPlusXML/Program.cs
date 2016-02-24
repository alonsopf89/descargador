using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace SunPlusXML
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
          
            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                if (args.Length > 0)
                {
                    if(args[0].Equals("2"))
                    {
                        //quiere entrar en modo ultrapesado, debemos de aniquilar cualquier otra instancia
                        var processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                        int cuantos = processes.Length;
                        int con = 0;
                        foreach (var process in processes)
                        {
                            con++;
                            if (con != cuantos)
                            {
                                process.CloseMainWindow();
                                process.Kill();
                            }
                        }
                    }
                    else
                    {//quiere entrar en modo ligero, pero ya hay otra instancia
                        return; 
                    }
                }
                else
                {
                    //quiere entrar en modo pesado, debemos de aniquilar cualquier otra instancia
                    //ATENCION! esto tambien elimina las instancias del modo ultrapesado, por lo tanto el modo ultra pesado
                    //debe de ejecutarse cuando no este programada la ejecucion de ninguno de los otros modos
                    var processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                    int cuantos = processes.Length;
                    int con = 0;
                    foreach (var process in processes)
                    {
                        con++;
                        if(con!=cuantos)
                        {
                            process.CloseMainWindow();
                            process.Kill();
                        }
                    }

                }
                

            }
                
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args.Length >0)
            {
                if(args.Length==1)
                {
                    Application.Run(new Form1(Convert.ToInt32(args[0])));//modo ligero = 1, modo ultrapesado=  2, modo ultrapesado ano anterior = 3
                }
                else
                {
                    Application.Run(new Form1(Convert.ToInt32(args[0]), args[1], args[2], args[3]));
                }
                
            }
            else
            {
                Application.Run(new Form1(0));//modo pesado
            }
           
        
        }
    }
}
