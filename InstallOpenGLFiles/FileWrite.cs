using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InstallOpenGLFiles
{
    class FileWrite
    {
        public string Write(string source,string destination,string filename)
        {
            
           
                if (!Directory.Exists(destination))
                {
                    return "destination directory not existed";
                    
                }
            if (!File.Exists(destination + @"\" + filename))
            {
                File.Copy(source, destination + @"\" + filename);
                return "Copied Done" + "to " + destination+"   "+ "with File Name : "+filename ;
            }
            else
                return "FAE";


            
        }
    }
}
